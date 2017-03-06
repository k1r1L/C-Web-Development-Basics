namespace ForumMVC.App.Ninject
{
    using Data;
    using Data.Contracts;
    using global::Ninject.Modules;

    public class Binder : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IForumContext>().To<ForumContext>();
        }
    }
}
