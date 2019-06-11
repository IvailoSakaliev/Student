using DataAcsess.Models;
using StudentSystem.Servise.EntityServise;
using StudentSystem.Servise.ProjectServise;
using StudentSystem2016.VModels.Models.Contacts;
using StudentSystem2016.VModels.Models.Products;
using System;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{
    public class HomeController : Controller
    {

        private IEncriptServises _encript = new EncriptServises();
        private ContactServise _contact = new ContactServise();
        private ProductServise _product = new ProductServise();
       

        public ActionResult Index()
        {


            //LoginServise _login = new LoginServise();
            //if (!_login.CheckForAdmin())
            //{
            //    return Redirect("Login/Registration");
            //}

            ProducLIst itemVM = new ProducLIst();
            itemVM = PopulateIndex(itemVM);

            return View(itemVM);
        }

        private ProducLIst PopulateIndex(ProducLIst itemVM)
        {
            //itemVM.Items = _product.GetAll(x => x.Front == 1);
            return itemVM;
        }

        public ActionResult About()
        {

            return Redirect("Error");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactVm model)
        {
            Contact entity = new Contact();
            entity.Email = _encript.EncryptData(model.Email);
            entity.Name = _encript.EncryptData(model.Subject);
            entity.Message = _encript.EncryptData(model.Message);
            entity.Date = DateTime.Today.ToString("dd/MM/yyyy");
            _contact.Save(entity);
            return Redirect("SuccessSendEmail");
        }

        public ActionResult SuccessSendEmail()
        {
            return View();
        }

       
       
        [HttpPost]
        public JsonResult CookieAcsept(int id)
        {
            if (id != 0)
            {
                HttpCookie cookie = new HttpCookie("CookieUsing");
                cookie.Values["cookieUsing"] = "1";
                HttpContext.Response.Cookies.Add(cookie);
            }
            return Json("ok");
        }
    }
}