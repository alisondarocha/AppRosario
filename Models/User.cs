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
        public DateOnly Birthdate { get; set; }
        [Required, MaxLength(128)]
        public string Email { get; set; }
    }
}