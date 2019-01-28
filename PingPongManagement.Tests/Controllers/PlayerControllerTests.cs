using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongManagement.Controllers;
using PingPongManagement.Models;
using PingPongManagement.Tests.Data;

namespace PingPongManagement.Tests.Controllers
{
    [TestClass]
    public class PlayerControllerTests
    {
        private const int BAD_ID = 999;

        [TestMethod]
        public void GetReturnsAllPlayers()
        {
            var context = new TestPingPongDbContext();
            var players = GetSamplePlayers();
            players.ForEach(i => context.Players.Add(i));

            var controller = new PlayerController(context);
            var result = controller.Get() as TestPlayerDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(players.Count, result.Local.Count);
        }

        [TestMethod]
        public void GetReturnsPlayerWithSameId()
        {
            var context = new TestPingPongDbContext();
            var player = GetSamplePlayer();
            context.Players.Add(player);

            var controller = new PlayerController(context);
            var result = controller.Get(player.Id) as OkNegotiatedContentResult<Player>;

            Assert.IsNotNull(result);
            Assert.AreEqual(player.Id, result.Content.Id);
        }

        [TestMethod]
        public void GetWithWrongIdReturnsNotFound()
        {
            var context = new TestPingPongDbContext();
            var players = GetSamplePlayers();
            players.ForEach(i => context.Players.Add(i));

            var controller = new PlayerController(context);
            var result = controller.Get(BAD_ID);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostReturnsSamePlayer()
        {
            var context = new TestPingPongDbContext();
            context.AddDefaultSkillLevels();

            var controller = new PlayerController(context);

            var player = GetSamplePlayer();

            var result = controller.Post(player) as CreatedAtRouteNegotiatedContentResult<Player>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.FirstName, player.FirstName);
        }

        [TestMethod]
        public void PutReturnsStatusCode()
        {
            var context = new TestPingPongDbContext();
            context.AddDefaultSkillLevels();

            var controller = new PlayerController(context);

            var player = GetSamplePlayer();

            var result = controller.Put(player.Id, player) as OkNegotiatedContentResult<Player>;
            Assert.IsNotNull(result);
            Assert.AreEqual(player.FirstName, result.Content.FirstName);
        }

        [TestMethod]
        public void PutFailsWhenDifferentId()
        {
            var context = new TestPingPongDbContext();
            context.AddDefaultSkillLevels();

            var controller = new PlayerController(context);

            var badresult = controller.Put(BAD_ID, GetSamplePlayer());
            Assert.IsInstanceOfType(badresult, typeof(InvalidModelStateResult));
        }
        
        [TestMethod]
        public void DeleteReturnsOK()
        {
            var context = new TestPingPongDbContext();
            var player = GetSamplePlayer();
            context.Players.Add(player);

            var controller = new PlayerController(context);
            var result = controller.Delete(player.Id) as OkNegotiatedContentResult<Player>;

            Assert.IsNotNull(result);
            Assert.AreEqual(player.Id, result.Content.Id);
        }

        /// <summary>
        /// Returns a few sample valid Players.
        /// </summary>
        /// <returns>A few sample valid Players.</returns>
        private List<Player> GetSamplePlayers()
        {
            return new List<Player>
            {
                new Player { Id = 1, FirstName = "FirstName", LastName = "LastName", Age = 5, EmailAddress = "123@example.com", SkillLevelId = 1 },
                new Player { Id = 2, FirstName = "FirstName2", LastName = "LastName", Age = 50, EmailAddress = "234@example.com", SkillLevelId = 2 },
                new Player { Id = 3, FirstName = "FirstName3", LastName = "LastName", EmailAddress = "567@example.com", SkillLevelId = 3 }
            };
        }

        /// <summary>
        /// Returns a single sample Player.
        /// </summary>
        /// <returns>A single sample Player.</returns>
        private Player GetSamplePlayer()
        {
            return new Player { Id = 7, FirstName = "FirstName", LastName = "LastName", Age = 25, EmailAddress = "123@example.com", SkillLevelId = 4 };
        }
    }
}
