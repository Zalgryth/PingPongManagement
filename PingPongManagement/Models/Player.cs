using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PingPongManagement.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [Required]
        [ForeignKey("SkillLevel")]
        public int SkillLevelId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public virtual SkillLevel SkillLevel { get; set; }
    }
}
