using AIRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.DataLoader
{
    public interface IDataLoader
    {
        BookDetails Load();
    }
}
