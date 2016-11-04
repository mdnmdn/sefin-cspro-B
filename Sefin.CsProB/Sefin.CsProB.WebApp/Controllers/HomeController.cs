using Sefin.CsProB.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace Sefin.CsProB.WebApp.Controllers
{
    public class HomeController : ControllerBase
    {
        private CategoryServices _categoryService;
        private ProductServices _productServices;

        public HomeController(CategoryServices categoryService)
        {
            _categoryService = categoryService;
            

        }

        public ActionResult Index()
        {
            ViewBag.NumCategories = _categoryService.CountCategories();

            var prodService = Kernel.Get<ProductServices>();

            var prodServic1e = ResolveObject<ProductServices>();     

            prodService.CountProducts();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}