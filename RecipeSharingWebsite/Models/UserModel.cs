using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models;

public class UserModel
{
        public int UserId { get; set; }
        [Required]
        public string? Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Required]
        public string? Email { get; set; }
        
        [Required]
        public string? UserImageLink { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Surname { get; set; }
        
        [Required]
        public string? Description { get; set; }
    
}