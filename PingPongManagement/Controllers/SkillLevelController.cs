using PingPongManagement.Data;
using PingPongManagement.Models;
using System.Linq;
using System.Web.Http;

namespace PingPongManagement.Controllers
{
    public class SkillLevelController : ApiController
    {
        private IPingPongDbContext db = new PingPongDbContext();

        public SkillLevelController() { }

        public SkillLevelController(IPingPongDbContext context)
        {
            db = context;
        }

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
