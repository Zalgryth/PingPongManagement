using PingPongManagement.Data;
using PingPongManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PingPongManagement.Controllers
{
    public class PlayerController : ApiController
    {
        private PingPongDbContext db = new PingPongDbContext();

        // GET: api/Player
        public IQueryable<Player> Get()
        {
            return db.Players.Include(i => i.SkillLevel);
        }

        // GET: api/Player/5
        public IHttpActionResult Get(int id)
        {
            var player = db.Players
                .Include(i => i.SkillLevel)
                .FirstOrDefault(i => i.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // POST: api/Player
        public IHttpActionResult Post([FromBody]Player player)
        {
            if (db.SkillLevels.Find(player.SkillLevelId) == null)
            {
                ModelState.AddModelError("SkillLevelId", "SkillLevelId does not correspond to a valid SkillLevel.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
        }

        // PUT: api/Player/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Player/5
        public IHttpActionResult Delete(int id)
        {
            var player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }
    }
}
