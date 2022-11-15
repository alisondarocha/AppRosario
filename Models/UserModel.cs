using System.ComponentModel.DataAnnotations;

namespace AppRosario.Models
{
    public class UserModel
    {
        public int IdUser { get; set; }
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required, MaxLength(128)]
        public string Email {get; set; }
    }
}