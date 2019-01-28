using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongManagement;
using PingPongManagement.Controllers;
using PingPongManagement.Models;
using PingPongManagement.Tests.Data;

namespace PingPongManagement.Tests.Controllers
{
    [TestClass]
    public class SkillLevelControllerTests
    {
        private const int BAD_ID = 999;

        [TestMethod]
        public void GetReturnsAllSkillLevels()
        {
            var context = new TestPingPongDbContext();
            context.AddDefaultSkillLevels();

            var controller = new SkillLevelController(context);
            var result = controller.Get() as TestSkillLevelDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Local.Count);
        }

        [TestMethod]
        public void GetReturnsSkillLevelWithSameId()
        {
            var context = new TestPingPongDbContext();
            context.AddDefaultSkillLevels();
            var skillLevel = context.SkillLevels.Find(1);

            var controller = new SkillLevelController(context);
            var result = controller.Get(skillLevel.Id) as OkNegotiatedContentResult<SkillLevel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(skillLevel.Id, result.Content.Id);
            Assert.AreEqual(skillLevel.Name, result.Content.Name);
        }

        [TestMethod]
        public void GetWithWrongIdReturnsNotFound()
        {
            var context = new TestPingPongDbContext();
            context.AddDefaultSkillLevels();

            var controller = new SkillLevelController(context);
            var result = controller.Get(BAD_ID);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
