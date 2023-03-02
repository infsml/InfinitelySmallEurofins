using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace AIRecommendationEngine.Common.Entities
{
    public class BookDetails
    {
        /*public Dictionary<string,Book> Books { get; set; } = new Dictionary<string,Book>();
        public Dictionary<string,User> Users { get; set; } = new Dictionary<string,User>();
        public List<BookUserRating> UserRating { get; set; } = new List<BookUserRating>();*/
        public ConcurrentDictionary<string,Book> Books { get; set; } = new ConcurrentDictionary<string,Book>();
        public ConcurrentDictionary<string,User> Users { get; set; } = new ConcurrentDictionary<string,User>();
        public ConcurrentQueue<BookUserRating> UserRating { get; set; } = new ConcurrentQueue<BookUserRating>();
    }
}
