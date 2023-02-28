using AIRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Aggregator
{
    public interface IRatingsAggregator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference);
    }
}
