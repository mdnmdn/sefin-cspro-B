﻿using Sefin.CsProB.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sefin.CsProB.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var categoryService = new CategoryServices())
            {
                ViewBag.NumCategories = categoryService.CountCategories();
            }
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