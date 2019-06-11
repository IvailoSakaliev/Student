using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentSystem.Servise.ProjectServise
{
    public class CookieServise
    {
        private IEncriptServises _enript;

        public CookieServise()
        {
            _enript = new EncriptServises();
        }

        public void AddCookie(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name);
            //cookie.Value[] = _enript.DencryptData(value);

        }
    }
}
