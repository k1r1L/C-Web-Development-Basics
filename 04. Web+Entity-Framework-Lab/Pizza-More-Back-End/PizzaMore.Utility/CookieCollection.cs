 namespace PizzaMore.Utility
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CookieCollection : ICookieCollection
    {
        private Dictionary<string, Cookie> cookieCollection;

        public CookieCollection()
        {
            this.cookieCollection = new Dictionary<string, Cookie>();
        }


        public Cookie this[string key]
        {
            get
            {
                return this.cookieCollection[key];
            }

            set
            {
                this.cookieCollection[key] = value;
            }
        }

        public Dictionary<string, Cookie> Cookies
        {
            get
            {
                return this.cookieCollection;
            }
        }

        public int Count
        {
            get
            {
                return this.cookieCollection.Count;
            }
        }

        public void AddCookie(Cookie cookie)
        {
            if (ContainsKey(cookie.Name))
            {
                this.cookieCollection[cookie.Name] = cookie;
            }
            else
            {
                this.cookieCollection.Add(cookie.Name, cookie);
            }
        }

        public bool ContainsKey(string key)
        {
            bool containsKey = this.cookieCollection.ContainsKey(key);

            return containsKey;
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            foreach (var kvp in this.cookieCollection)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void RemoveCookie(string cookieName)
        {
            this.cookieCollection.Remove(cookieName);
        }
    }
}
