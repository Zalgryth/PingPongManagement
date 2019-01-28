using PingPongManagement.Models;
using System.Linq;

namespace PingPongManagement.Tests.Data
{
    public class TestPlayerDbSet : TestDbSet<Player>
    {
        public override Player Find(params object[] keyValues)
        {
            return this.SingleOrDefault(player => player.Id == (int)keyValues.Single());
        }
    }
}
