using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PingPongManagement.Models
{
    public class SkillLevel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }
}
