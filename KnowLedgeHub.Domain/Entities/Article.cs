using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Domain.Entities
{
    public class Article
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Url]
        public string URL { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        [Required]
        public int CategoryId;
        public string PostedBy { get; set; }
        public bool IsApproved { get; set; }
        public DateTime Created { get; set; }
    }
}
