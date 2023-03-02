using AIRecommendationEngine.Aggregator;
using AIRecommendationEngine.Common.Entities;
using AIRecommendationEngine.CoreRecommender;
using AIRecommendationEngine.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Integrator
{
    public class AIRecommendationEngine
    {
        IDataLoader loader;
        IRecommender recommender;
        IRatingsAggregator aggregator;

        BookDetails details;
        public AIRecommendationEngine()//IDataLoader loader, IRecommender recommender, IRatingsAggregator aggregator)
        {
            this.loader = new CSVDataLoader();
            this.recommender = new PearsonCorrelation();
            this.aggregator = new RatingsAggrigator(new AgeGroup());
            this.details = loader.Load();
        }

        public IList<Book> Recommend(Preference preference, int limit)
        {
            List<Book> result = new List<Book>();

            Dictionary<string,List<int>> bookRatings = aggregator.Aggrigate(details, preference);
            List<int> baseData;
            if (bookRatings.ContainsKey(preference.ISBN))
            {
                baseData = bookRatings[preference.ISBN];
                bookRatings.Remove(preference.ISBN);
            }
            else
            {
                baseData = new List<int>(Enumerable.Repeat(10,bookRatings.Values.First().Count));
            }
            List<BookValueHolder> values = new List<BookValueHolder>();
            foreach(string ISBN in  bookRatings.Keys)
            {
                List<int> newBaseData = new List<int>();
                foreach(int i in baseData) { newBaseData.Add(i); }
                List<int> newBookRatings = new List<int>();
                foreach(int i in bookRatings[ISBN]) { newBookRatings.Add(i); }

                double correlationValue = recommender.GetCorrelation(newBaseData, newBookRatings);
                values.Add(new BookValueHolder() { ISBN=ISBN,value= correlationValue});
            }
            values.Sort();
            for(int i=0;i<limit && i < values.Count; i++)
            {
                result.Add(details.Books[values[i].ISBN]);
            }
            return result;
        }
    }
    class BookValueHolder : IComparable<BookValueHolder>
    {
        public string ISBN { get; set; }
        public double value { get; set; }
        public int CompareTo(BookValueHolder other)
        {
            return -value.CompareTo(other.value);
        }
    }
}
