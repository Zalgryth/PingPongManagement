using PingPongManagement.Data;
using PingPongManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            ValidateSkillLevelExists(player.SkillLevelId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.Id }, player);
        }

        // PUT: api/Player/5
        public IHttpActionResult Put(int id, Player player)
        {
            ValidateSkillLevelExists(player.SkillLevelId);
            player.SkillLevel = null;

            if (id != player.Id)
            {
                ModelState.AddModelError("player.Id", "The Id field does not match the Id provided in the request URL.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.Id)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(player);
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

        private void ValidateSkillLevelExists(int id)
        {
            if (db.SkillLevels.Find(id) == null)
            {
                ModelState.AddModelError("player.SkillLevelId", "The SkillLevelId field does not correspond to a valid SkillLevel.");
            }
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(i => i.Id == id) > 0;
        }
    }
}
