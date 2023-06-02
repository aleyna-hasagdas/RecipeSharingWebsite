using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$", ErrorMessage = "Password must have at least one non-alphanumeric character, one uppercase letter, and be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
}
