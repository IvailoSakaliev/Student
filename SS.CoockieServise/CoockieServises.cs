using SS.EncriptServise;
using System;
using System.Web;

namespace SS.CoockieServise
{
    public class CoockieServises
    {
        private EncriptServises _cript;

        public CoockieServises()
        {
            _cript = new EncriptServises();
        }
        public void AddCoockiesForLogin(string username, string password)
        {
            HttpCookie cookie = new HttpCookie("UserInformation");
            cookie.Values["username"] = _cript.EncryptData(username);
            cookie.Values["password"] = _cript.EncryptData(password);
            cookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public void DeleteCoockie(string nameOfCookie)
        {
            if (HttpContext.Current.Response.Cookies[nameOfCookie] != null)
            {
                HttpCookie cookie = new HttpCookie(nameOfCookie);
                cookie.Expires = DateTime.Now.AddDays(-30);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

    }
}
