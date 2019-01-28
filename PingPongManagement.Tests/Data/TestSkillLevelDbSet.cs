using PingPongManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagement.Tests.Data
{
    public class TestSkillLevelDbSet : TestDbSet<SkillLevel>
    {
        public override SkillLevel Find(params object[] keyValues)
        {
            return this.SingleOrDefault(player => player.Id == (int)keyValues.Single());
        }
    }
}
