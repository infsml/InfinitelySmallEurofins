using Humanizer;
using KnowLedgeHub.Data;
using KnowLedgeHub.Domain;
using KnowLedgeHub.Domain.Entities;
using KnowLedgeHub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowLedgeHub.Web.Controllers
{
    public class ArticlesController : Controller
    {
        IArticleManager mgr;// = new ArticleManager(new ArticleRepository());
        ICategoriesManager mgr2;// = new CatagoriesManager(new CategoryRepository());
        public ArticlesController(IArticleManager mgr, ICategoriesManager mgr2)
        {
            this.mgr = mgr;
            this.mgr2 = mgr2;
        }
        public ActionResult Index(string searchterm)
        {
            var articles = from a in mgr.GetArticlesForBrowse()
                           select new BrowseArticleViewModel() { 
                               CategoryName = a.Category.Name,
                               Description = a.Description,
                               Title = a.Title,
                               URL = a.URL,
                               PostedBy = a.PostedBy,
                               PostedOn = a.Created.Humanize(true)
                           };
            if(searchterm!=null)articles = from a in articles
                       where a.Title.Contains(searchterm) ||
                       a.URL.Contains(searchterm) ||
                       a.CategoryName.Contains(searchterm) ||
                       a.PostedBy.Contains(searchterm)
                       select a;
            return View(articles);
        }
        [HttpGet]
        [Authorize]
        public ActionResult SubmitArticle()
        {
            var cats = from c in mgr2.ListCategories()
                       select new SelectListItem { Text = c.Name,Value=c.CategoryId.ToString() };
            ViewBag.CategoryId = cats;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult SubmitArticle(SubmitArticleViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Article a = new Article();
            a.Title = model.Title;
            a.Description = model.Description;
            a.URL = model.URL;
            a.Category = mgr2.GetById(model.CategoryId);

            a.IsApproved = false;
            a.Created = DateTime.Now;
            if (User.Identity.IsAuthenticated)
            {
                a.PostedBy = User.Identity.Name;
            }
            else
            {
                a.PostedBy = "Unknown";
            }

            mgr.SubmitArticle(a);
            TempData["Message"] = "Article submitted";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ReviewArticle()
        {
            var articles = from a in mgr.GetArticlesForReview()
                           select new BrowseArticleViewModel()
                           {
                               Id = a.Id,
                               CategoryName = a.Category.Name,
                               Description = a.Description,
                               Title = a.Title,
                               URL = a.URL,
                               PostedBy = a.PostedBy,
                               PostedOn = a.Created.Humanize(true)
                           };
            return View(articles);
        }
        public ActionResult ApproveArticles(List<int> articleIds)
        {
            if(articleIds!= null)
            {
                mgr.ApproveArticles(articleIds);
            }
            TempData["Message"] = "Article approved";
            return RedirectToAction("ReviewArticle");
        }
        public ActionResult RejectArticles(List<int> articleIds)
        {
            if (articleIds != null)
            {
                mgr.RejectArticles(articleIds);
            }
            TempData["Message"] = "Article rejected";
            return RedirectToAction("ReviewArticle");
        }
    }
}