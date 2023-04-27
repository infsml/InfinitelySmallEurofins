using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowLedgeHub.Web.Models
{
    public class ListArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string PostedBy { get; set; }
        public DateTime Created { get; set; }
    }
}