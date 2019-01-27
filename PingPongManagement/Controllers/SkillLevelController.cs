using PingPongManagement.Data;
using PingPongManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PingPongManagement.Controllers
{
    public class SkillLevelController : ApiController
    {
        private PingPongDbContext db = new PingPongDbContext();

        // GET: api/SkillLevel
        public IQueryable<SkillLevel> Get()
        {
            return db.SkillLevels;
        }

        // GET: api/SkillLevel/5
        public IHttpActionResult Get(int id)
        {
            var skillLevel = db.SkillLevels.FirstOrDefault(i => i.Id == id);
            if (skillLevel == null)
            {
                return NotFound();
            }

            return Ok(skillLevel);
        }
    }
}
