using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowLedgeHub.Web.Models
{
    public class SubmitArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}