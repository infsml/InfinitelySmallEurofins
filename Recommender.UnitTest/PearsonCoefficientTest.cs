using AIRecommendationEngine.CoreRecommender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Recommender.UnitTest
{
    [TestClass]
    public class PearsonCoefficientTest
    {
        IRecommender recommender;
        [TestInitialize]
        public void Init()
        {
            recommender = new PearsonCorrelation();
        }
        [TestCleanup]
        public void Cleanup()
        {
            recommender = null;
        }
        [TestMethod]
        public void PearsonCorrelation_EqualLengthLists_ValidOutput()
        {
            List<int> baseData = new List<int> { 6, 3, 3, 8, 1, 10, 7, 5, 4, 5, 4, 1, 2, 10, 8, 10, 7, 6, 4, 6 };
            List<int> otherData = new List<int>() { 3, 9, 9, 3, 8, 10, 5, 2, 4, 4, 1, 10, 7, 10, 8, 6, 2, 1, 6, 6 };

            double result = recommender.GetCorrelation(baseData, otherData);
            
            string expected = String.Format("%.5f", -0.06028889722486411);
            string actual = String.Format("%.5f", result);
            
            Assert.AreEqual(expected,actual);
            
        }

        [TestMethod]
        public void PearsonCorreleation_EqualListWithZeros_ValidOutput()
        {
            List<int> baseData  = new List<int>() { 6, 3, 3, 8, 0, 10, 7, 5, 4, 5, 4, 0,  2, 10, 8, 10, 7, 5, 4, 6 };
            List<int> otherData = new List<int>() { 3, 9, 9, 3, 7, 10, 5, 2, 4, 4, 0, 10, 7, 10, 8, 6,  2, 0, 6, 6 };

            double result = recommender.GetCorrelation(baseData, otherData);

            string expected = String.Format("%.5f", -0.06028889722486411);
            string actual = String.Format("%.5f", result);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PearsonCorrelation_SmallerBaseList_ValidOutput()
        {
            List<int> baseData  = new List<int>() { 6, 3, 3, 8, 0, 10, 7, 5, 4, 5, 4, 0, 2, 10, 8, 10, 7, 5, 4, 6 };
            List<int> otherData = new List<int>() { 3, 9, 9, 3, 7, 10, 5, 2, 4, 4, 0, 10, 7, 10, 8, 6, 2, 0, 6, 6, 2, 3, 9, 5 };

            double result = recommender.GetCorrelation(baseData, otherData);

            string expected = String.Format("%.5f", -0.06028889722486411);
            string actual = String.Format("%.5f", result);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PearsonCorrelation_LargerBaseList_ValidOutput()
        {
            List<int> baseData = new List<int>() { 6, 3, 3, 8, 0, 10, 7, 5, 4, 5, 4, 0, 2, 10, 8, 10, 7, 5, 4, 6 };
            List<int> otherData = new List<int>() { 3, 9, 9, 3, 7, 10, 5, 2, 4, 4, 0, 10, 7, 10, 8 };

            double result = recommender.GetCorrelation(baseData, otherData);

            string expected = String.Format("%.5f", -0.20099954538980036);
            string actual = String.Format("%.5f", result);

            Assert.AreEqual(expected, actual);
        }
    }
}
