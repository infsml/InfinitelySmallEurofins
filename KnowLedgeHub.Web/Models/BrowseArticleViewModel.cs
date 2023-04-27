using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowLedgeHub.Web.Models
{
    public class BrowseArticleViewModel
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string PostedBy { get; set; }
        public string PostedOn { get; set; }
    }
}