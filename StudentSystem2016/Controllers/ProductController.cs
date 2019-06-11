using DataAcsess.Models;
using StudentSystem.Servise.EntityServise;
using StudentSystem2016.Filters.EntityFilter;
using StudentSystem2016.VModels.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Controllers
{

    public class ProductController
   : Controller
    {
        ProductServise _productServise = new ProductServise();
        public static string _search { get; set; }
        public static List<Product> _priceFrom { get; set; }
        public static List<Product> _priceTo { get; set; }
        public static List<Product> _baseType { get; set; }
        public static List<Product> _subType { get; set; }
        public static List<Product> _list { get; set; }
        public static ProducLIst itemVM = new ProducLIst();
        public static int _sort;

        [HttpGet]
        public ActionResult Index(int Curentpage)
        {
            itemVM = new ProducLIst();
            itemVM.Filter = new PruductFilter();
            itemVM = GetElement(itemVM, Curentpage);
            HttpCookie cookie = HttpContext.Request.Cookies["ViewProduct"];
            if (cookie["ViewProduct"] == null
                || cookie["ViewProduct"] == "")
            {
                cookie["ViewProduct"] =  "2";
            }
            return View(itemVM);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            ProducLIst itemVM = new ProducLIst();
            if (search != null)
            {
                _search = search;
                string[] keys = search.Split(' ');
                List<Product> list = new List<Product>();

                list = _productServise.GetAll(x => x.Title.ToLower().Contains(keys[0].ToLower()));
                itemVM.Filter = new PruductFilter();
                if (keys.Length == 1)
                {
                    foreach (var item in list)
                    {
                        itemVM.Items.Add(item);
                    }
                }
                else
                {
                    itemVM = Check(keys, list, 1, itemVM);
                }

                return View(itemVM);
            }

            return View(itemVM);
        }

        public ProducLIst Check(string[] keys, List<Product> list, int i, ProducLIst itemVM)
        {
            try
            {
                List<Product> newResult = new List<Product>();
                newResult = list.Where(x => x.Title.ToLower().Contains(keys[i].ToLower())).ToList();
                if (i == keys.Length - 1)
                {
                    foreach (var item in newResult)
                    {
                        itemVM.Items.Add(item);
                    }
                    return itemVM;
                }
                i++;
                Check(keys, newResult, i, itemVM);


            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            return itemVM;

        }



        public ActionResult GaleryProduct(string Curentpage)
        {
            itemVM = new ProducLIst();
            itemVM.Filter = new PruductFilter();
            itemVM = GetElement(itemVM, int.Parse(Curentpage));
            return View(itemVM);
        }
        public ActionResult ListProduct(string Curentpage)
        {
            itemVM = new ProducLIst();
            itemVM.Filter = new PruductFilter();
            itemVM = GetElement(itemVM, int.Parse(Curentpage));
            return View(itemVM);
        }


        private ProducLIst GetElement(ProducLIst itemVM, int curentPage)
        {
            string controllerName = GetControlerName();
            string actionname = GetActionName();

            itemVM.ControllerName = controllerName;
            itemVM.ActionName = actionname;
            List<Product> list = new List<Product>();
            list = FilterProducts();


            if (_sort == 1)
            {
                if (list == null)
                {
                    itemVM.AllItems = _productServise.GetAll().OrderBy(x => x.Price).ToList();
                }
                else
                {
                    itemVM.AllItems = list.OrderBy(x => x.Price).ToList();
                }
            }
            else if (_sort == 2)
            {
                if (list == null)
                {
                    itemVM.AllItems = _productServise.GetAll().OrderByDescending(x => x.Price).ToList();
                }
                else
                {
                    itemVM.AllItems = list.OrderByDescending(x => x.Price).ToList();
                }
            }
            else
            {
                if (list == null)
                {
                    itemVM.AllItems = _productServise.GetAll().OrderBy(x => x.Date).ToList();
                }
                else
                {
                    itemVM.AllItems = list.OrderBy(x => x.Date).ToList();
                }
            }





            itemVM.Pages = itemVM.AllItems.Count / 12;
            double doublePages = itemVM.AllItems.Count / 12.0;
            if (doublePages > itemVM.Pages)
            {
                itemVM.Pages++;
            }
            itemVM.StartItem = 12 * curentPage;
            try
            {
                for (int i = itemVM.StartItem - 12; i < itemVM.StartItem; i++)
                {
                    itemVM.Items.Add(itemVM.AllItems[i]);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }



            return itemVM;
        }


        private string GetActionName()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }

        private string GetControlerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        public List<Product> FilterProducts()
        {
            List<Product> priceToFrom = new List<Product>();
            List<Product> bacetypeTorazvitieNaUmeniqta = new List<Product>();
            List<Product> _intersectlist = new List<Product>();
            priceToFrom = InterSect(_priceFrom, _priceTo);
            //bacetypeTorazvitieNaUmeniqta = InterSect(_baseType, _razvitie);
            bacetypeTorazvitieNaUmeniqta = InterSect(_baseType, _subType);
            return InterSect(priceToFrom, bacetypeTorazvitieNaUmeniqta);

        }

        private List<Product> InterSect(List<Product> firstList, List<Product> SecondList)
        {
            if (firstList == null && SecondList == null)
            {
                return null;
            }
            else if (firstList == null)
            {
                return SecondList;
            }
            else if (SecondList == null)
            {
                return firstList;
            }
            else
            {
                List<Product> intersect = new List<Product>();
                foreach (var first in firstList)
                {
                    foreach (var second in SecondList)
                    {
                        if (second.Code == first.Code)
                        {
                            intersect.Add(first);
                            break;
                        }
                    }

                }
                return intersect;
            }

        }

        [HttpPost]
        public JsonResult ChangeViewProducts(int id)
        {
            HttpCookie cookie = new HttpCookie("ViewProduct");
            if (id == 1)
            {
                cookie["ViewProduct"] = "1";
            }
            else
            {
                cookie["ViewProduct"] = "2";
            }
            cookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Response.Cookies.Add(cookie);
            return Json(id);
        }

        [HttpPost]
        public JsonResult FilterPriceTo(string element)
        {
            if (element == null || element == "")
            {
                _priceTo = null;
            }
            else
            {
                _priceTo = _productServise.GetAll(x => x.Price < int.Parse(element));
            }
            return Json(Request.Cookies["ViewProducr"]);
        }


        [HttpPost]
        public JsonResult FilterPriceFrom(string element)
        {
            if (element == null || element == "")
            {
                _priceFrom = null;
            }
            else
            {
                _priceFrom = _productServise.GetAll(x => x.Price > int.Parse(element));
            }
            return Json(Request.Cookies["ViewProducr"]);
        }
        [HttpPost]
        public JsonResult ChangeFiltredResult(int id)
        {
            return Json(Request.Cookies["ViewProducr"]);
        }
        [HttpPost]
        public JsonResult RestorePage(int id)
        {
            Restore();
            return Json(true);
        }

        private void Restore()
        {
            _priceFrom = null;
            _priceTo = null;
            _subType = null;
            _baseType = null;
            _sort = 0;
        }

        [HttpPost]
        public JsonResult ChangBaseTypeValue(int id)
        {
            _baseType = _productServise.GetAll(x => x.Basetype == id);
            return Json(Request.Cookies["ViewProducr"]);
        }

        [HttpPost]
        public JsonResult ChangeType(int id)
        {
            Restore();
            _subType = _productServise.GetAll(x => x.Type == id);
            return Json("ok");
        }

        [HttpPost]
        public JsonResult ChangeSortOfProduct(int id)
        {
            _sort = id;
            return Json(Request.Cookies["ViewProducr"]);
        }

        [HttpPost]
        public JsonResult RestoreFilter()
        {
            Restore();
            return Json(Request.Cookies["ViewProducr"]);
        }


    }

}