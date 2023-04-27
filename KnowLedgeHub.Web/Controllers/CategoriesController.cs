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
        ICategoriesManager manager;// = new CatagoriesManager(new CategoryRepository());
        public CategoriesController(ICategoriesManager manager)
        {
            this.manager = manager;
        }
        public ActionResult Index()
        {
            return View(manager.ListCategories());
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
            manager.CreateCategory(category);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(manager.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            manager.ListCategories();
            manager.EditCategory(category);
            /*Category c = new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };
            manager.EditCategory(c);*/
            TempData["Message"] = $"Catagory edited successfully..";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(manager.GetById(id));
        }
        public ActionResult DeleteConfirm(int id)
        {
            manager.DeleteCategory(id);
            TempData["Message"] = $"Catagory deleted successfully..";
            return RedirectToAction("Index");

        }
    }
}