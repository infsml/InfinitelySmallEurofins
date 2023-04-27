using KnowLedgeHub.Domain.Data;
using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Domain
{
    public class ArticleManager : IArticleManager
    {
        IArticleRepository repo;
        public ArticleManager(IArticleRepository repo)
        {
            this.repo = repo;
        }
        public void ApproveArticles(List<int> articleIds)
        {
            repo.ApproveArticles(articleIds);
        }

        public List<Article> GetArticlesForBrowse()
        {
            return repo.GetArticlesForBrowse();
        }

        public List<Article> GetArticlesForBrowseByCategory(int categoryId)
        {
            return repo.GetArticlesForBrowseByCategory(categoryId);
        }

        public List<Article> GetArticlesForReview()
        {
            return repo.GetArticlesForReview();
        }

        public List<Article> GetArticlesForReviewByCategory(int categoryId)
        {
            return repo.GetArticlesForReviewByCategory(categoryId);
        }

        public void RejectArticles(List<int> articleIds)
        {
            repo.RejectArticles(articleIds);
        }

        public void SubmitArticle(Article article)
        {
            repo.SubmitArticle(article);
        }
    }
}
