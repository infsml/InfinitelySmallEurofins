using AIRecommendationEngine.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStuff
{
    public class Tesiting
    {
        static void Main(string[] args)
        {
            IDataLoader loader = new CSVDataLoader();
            loader.Load();
        }
    }
}
