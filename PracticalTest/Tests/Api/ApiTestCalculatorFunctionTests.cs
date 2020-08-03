using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalTest.Common;
using PracticalTest.Common.Utils;
using PracticalTest.Interfaces;
using PracticalTest.Objects;

namespace PracticalTest.Tests.Api
{
    [TestClass]
    [TestCategory("API")]
    public class ApiTestCalculatorFunctionTests : TestBase
    {
        private ICalculator _calculator;
        
        [TestInitialize]
        public void Setup()
        {
            _calculator = new ApiCalculator(ApiUrl);
        }

        [TestMethod]
        //Test all operators plus some boundary tests
        [DataRow(int.MaxValue, 1, '+', int.MinValue)]
        [DataRow(int.MaxValue, int.MaxValue, '-', 0)]
        [DataRow(int.MaxValue, 3, '/', int.MaxValue / 3)]
        [DataRow(int.MaxValue / 3, 3, '*', int.MaxValue / 3 * 3)]
        [DataRow(int.MinValue, int.MaxValue, '+', int.MinValue + int.MaxValue)]
        [DataRow(-100, 5, '/', -20)]
        [DataRow(-99, 99, '-', -198)]
        public void ApiTest_PositiveTests(int leftNumber, int rightNumber, char operatorUsed, int expectedResult)
        {
            var actualResult = _calculator.Calculate(leftNumber, rightNumber, operatorUsed);
            Assert.AreEqual(expectedResult, actualResult, 
                $"Api calculator returned unexpected result with {leftNumber} {operatorUsed} {rightNumber} = {actualResult}");
        }

        [TestMethod]
        //API may need to return a customized error other then throws 500 internal server error. Bug?
        public void ApiTest_NegativeTest_DividedByZero()
        {
            var leftNumber = 1;
            var rightNumber = 0;
            var operatorUsed = '/';
            var ex = Assert.ThrowsException<AutomationException>(
                () => _calculator.Calculate(leftNumber, rightNumber, operatorUsed));
            Assert.AreEqual(ex.Message, "Server replied failure, please check response in test log.");
        }

        [TestMethod]
        public void ApiTest_PositiveTests_RandomTest()
        {
            var allowedOperators = new[] {'+', '-', '*', '/'};
            var random = new Random();
            var leftNumber = random.Next(int.MinValue, int.MaxValue);
            var rightNumber = random.Next(1, int.MaxValue);
            var operatorUsed = allowedOperators[random.Next(3)];
            var expectedResult = Calculator.Caculate(leftNumber, rightNumber, operatorUsed);
            var actualResult = _calculator.Calculate(leftNumber, rightNumber, operatorUsed);
            Assert.AreEqual(expectedResult, actualResult,
                $"Api calculator returned unexpected result with {leftNumber} {operatorUsed} {rightNumber} = {actualResult}");
        }
    }
}