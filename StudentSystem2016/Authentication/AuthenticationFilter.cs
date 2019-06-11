using StudentSystem.Servise.ProjectServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Authentication
{
    public class AuthenticationFilter
        : ActionFilterAttribute
    {
        private IEncriptServises _encript = new EncriptServises();
        public override void OnActionExecuting(ActionExecutingContext context)


        {
            if (HttpContext.Current.Session["LoggedUser"] == null)
            {
                context.HttpContext.Response.Redirect("../Error/Login");
            }
            else
            {
                string id = _encript.DencryptData(HttpContext.Current.Session["LoggedUser"].ToString());
                if (id != "1")
                {
                    context.HttpContext.Response.Redirect("../Home/Index");
                }
            }
            base.OnActionExecuting(context);

        }
    }
}