using KnowLedgeHub.Domain.Data;
using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Data
{
    public class ArticleRepository : IArticleRepository
    {
        KnowLedgeHubDBContext db = new KnowLedgeHubDBContext();

        public void ApproveArticles(List<int> articleIds)
        {
            HashSet<int> articleIdsSet = new HashSet<int>(articleIds);
            foreach(int id in articleIds)
            {
                var a = db.articles.Find(id);
                if (a != null) a.IsApproved = true;
            }
            db.SaveChanges();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return (from a in db.articles
                    where a.IsApproved
                    select a).ToList();
        }

        public List<Article> GetArticlesForBrowseByCategory(int categoryId)
        {
            return (from a in db.articles
                    where a.IsApproved && a.CategoryId == categoryId
                    select a).ToList();
        }

        public List<Article> GetArticlesForReview()
        {
            return (from a in db.articles
                    where !a.IsApproved
             select a).ToList();
        }

        public List<Article> GetArticlesForReviewByCategory(int categoryId)
        {
            return (from a in db.articles
             where !a.IsApproved && a.CategoryId == categoryId
             select a).ToList();
        }

        public void RejectArticles(List<int> articleIds)
        {
            foreach(int id in articleIds)
            {
                var a = db.articles.Find(id);
                db.articles.Remove(a);
            }
            db.SaveChanges();
        }

        public void SubmitArticle(Article article)
        {
            db.articles.Add(article);
            db.SaveChanges();
        }
    }
}
