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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Player/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Player/5
        public void Delete(int id)
        {
        }
    }
}
