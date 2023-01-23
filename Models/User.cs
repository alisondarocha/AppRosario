using System.ComponentModel.DataAnnotations;

namespace RosaryCrusadeAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }


    }
}