using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Domain.Data
{
    public interface IArticleRepository
    {
        void SubmitArticle(Article article);
        void ApproveArticles(List<int> articleIds);
        void RejectArticles(List<int> articleIds);
        List<Article> GetArticlesForReviewByCategory(int categoryId);
        List<Article> GetArticlesForBrowseByCategory(int categoryId);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();
    }
}
