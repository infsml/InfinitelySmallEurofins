using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Common.Entities
{
    public class BookUserRating
    {
        public int Rating { get; set; }
        public string ISBN { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
