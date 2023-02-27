using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalcUnitDataAccess;
using System;

using Moq;

namespace SimpleCalcUnitLibrary.UnitTest
{
    //class MockCalculatorRepo : ICalculatorRepo
    //{
    //    public bool Save(string data)
    //    {
    //        return true;
    //    }
    //}
    [TestClass]
    public class CalculatorUnitTest
    {
        private Calculator target;
        private Mock<ICalculatorRepo> mock;

        [TestInitialize]
        public void Init()
        {
            //Do all arrangements here
            //ICalculatorRepo mock = new MockCalculatorRepo();
            mock = new Mock<ICalculatorRepo>();
            //mock.Setup(m => m.Save("hehelamoXD")).Returns(true);

            target = new Calculator(mock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            target = null;
            mock = null;
        }

        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult() // Test Case
        {
            // do not use conditional statement
            // do not use iterative statement
            // do not use try...catch statement
            // only simp statements

            // AAA
            // A - Arange
            // Prepare data
            int fno = 10;
            int sno = 20;
            int expected = 30;
            
            // A - Act
            int actual = target.Sum(fno, sno);
            // A - Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(NumberNegativeException))]
        public void Sum_WithNegativeInput_ShouldThrowException()
        {
            target.Sum(-1, -1);
        }
        [TestMethod]
        [ExpectedException(typeof(NumberOddException))]
        public void Sum_WithOddInput_ShouldThrowException()
        {
            
            target.Sum(1, 1);
        }
        [TestMethod]
        public void Sum_WithValidInput_ShouldCallSaveMethod()
        {
            target.Sum(10, 20);
            mock.Verify(m => m.Save("10+20=30"),Times.Once());
        }
    }
}
