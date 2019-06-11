using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Authentication
{
    public class UserFilter
      : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string url = context.HttpContext.Request.Path;
            int substring = url.LastIndexOf('/');
            int idlenght = url.Length - substring;
            string urlID = url.Substring(substring, idlenght);
            string id = HttpContext.Current.Session["User_ID"].ToString();
            if (id != urlID)
            {
                context.HttpContext.Response.Redirect("../Home/Index");
            }
            base.OnActionExecuting(context);
        }
    }
}