using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Common.Entities
{
    public class Book
    {
        public string BookTitle {get; set;}
        public string BookAuthor {get; set;}
        public string ISBN {get; set;}
        public string Publisher {get; set;}
        public int YearOfPublication {get; set;}
        public string ImageUrlSmall {get; set;}
        public string ImageUrlMedium {get; set;}
        public string ImageUrlLarge { get; set; }

        public ConcurrentQueue<BookUserRating> UserRating { get; set; } = new ConcurrentQueue<BookUserRating>();
    }
}
