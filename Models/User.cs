using System.ComponentModel.DataAnnotations;

namespace AppRosario.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateOnly Birthdate { get; set; }
        [Required, MaxLength(128)]
        public string Email {get; set; }        
    }
}