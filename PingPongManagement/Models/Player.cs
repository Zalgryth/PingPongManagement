using System.ComponentModel.DataAnnotations;

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
        public SkillLevel SkillLevel { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
