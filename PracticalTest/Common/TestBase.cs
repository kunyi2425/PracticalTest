using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace PracticalTest.Common
{
    public class TestBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected string WebUrl;
        protected string ApiUrl;

        [TestInitialize]
        public void SetupTest()
        {
            WebUrl = ConfigurationManager.AppSettings["WebUrl"];
            ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

            Logger.Info(DateTime.Now + $" - Test started on web ({WebUrl}) and api ({ApiUrl})");
        }
    }
}
