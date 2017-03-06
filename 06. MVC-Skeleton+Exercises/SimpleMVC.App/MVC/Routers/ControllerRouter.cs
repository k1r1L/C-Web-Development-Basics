namespace SimpleMVC.App.MVC.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using Controllers;
    using Attributes.Methods;
    using Interfaces;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Enums;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string[] urlParams = UrlParser.RetrieveUrlParams(request.Url);
            if (urlParams[2] == "logout")
            {
                urlParams[2] = "index";
            }

            if (request.Method == RequestMethod.GET && request.Url.IndexOf('?') != -1)
            {
                this.getParams = UrlParser.RetrieveRequestParams(request.Url.Substring(request.Url.IndexOf('?') + 1));
            }

            if (request.Method == RequestMethod.POST && request.Content != null && request.Content != string.Empty)
            {
                this.postParams = UrlParser.RetrieveRequestParams(request.Content);
            }

            this.requestMethod = request.Method.ToString();
            this.controllerName = UrlParser.ReturnWithCapitalLetter(urlParams[1]) + "Controller";
            this.actionName = UrlParser.ReturnWithCapitalLetter(urlParams[2]);

            MethodInfo method = this.GetMethod();
            if (method == null)
            {
                throw new NotSupportedException("No such method");
            }

            IEnumerable<ParameterInfo> parameters =
                method.GetParameters();

            this.methodParams = new object[parameters.Count()];
            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive)
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(
                        value,
                        param.ParameterType);
                    index++;
                }
                else if (param.ParameterType == typeof(HttpRequest))
                {
                    this.methodParams[index] = request;
                    index++;
                }
                else if (param.ParameterType == typeof(HttpSession))
                {
                    this.methodParams[index] = request.Session;
                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);
                    IEnumerable<PropertyInfo> properties =
                        bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                postParams[property.Name],
                                property.PropertyType)
                                );
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel, bindingModelType);
                    index++;
                }
            }

            IInvocable actionResult = (IInvocable)this.GetMethod()
                  .Invoke(this.GetController(), this.methodParams);
            string content = actionResult.Invoke();

            HttpResponse response = new HttpResponse();
            if (!string.IsNullOrEmpty(actionResult.Location))
            {
                response.StatusCode = ResponseStatusCode.Found;
                response.Header.OtherParameters.Add("Location", actionResult.Location);
            }
            else
            {
                response.StatusCode = ResponseStatusCode.Ok;
                response.ContentAsUTF8 = content;
            }

            return response;
        }

        private MethodInfo GetMethod()
        {
            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            string controllerType = string.Format(
                "{0}.{1}.{2}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ControllersFolder,
                this.controllerName);

            Controller controller = (Controller)Activator.CreateInstance
                (Type.GetType(controllerType));

            return controller;
        }
    }
}
