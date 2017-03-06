namespace SimpleHttpServer.Utilities
{
    using Models;
    using System;

    public static class SessionCreator
    {
        public static HttpSession Create()
        {
            string sessionId = new Random().Next().ToString();
            HttpSession session = new HttpSession(sessionId);

            return session;
        }
    }
}
