using AIRecommendationEngine.Common.Entities;
using AIRecommendationEngine.DataLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataLoader.UnitTest
{
    [TestClass]
    public class DataLoaderTest
    {
        BookDetails details;
        [TestInitialize]
        public void Init()
        {
            IDataLoader loader = new CSVDataLoader();
            details = loader.Load();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
