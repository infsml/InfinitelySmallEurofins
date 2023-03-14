using KnowLedgeHub.Data;
using KnowLedgeHub.Domain;
using KnowLedgeHub.Domain.Data;
using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowLedgeHub.Web.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Message = "Error macha";
                return View();
            }
            ViewBag.Message = "Added Successfully";
            CatagoriesManager manager = new CatagoriesManager(new CategoryRepository());
            manager.CreateCategory(category);
            return View();
        }
    }
}