using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodayIveLearned.Controllers.Api;

namespace TodayIveLearned.Tests.Controllers
{
    [TestClass]
    public class TopicControllerTest
    {
        [TestMethod]
        public void Triggers()
        {
            var topicsController = new TopicController();
            var result = topicsController.Triggers("Set up routes in angular");
            Assert.AreEqual(1, result.Count());
        }
    }
}
