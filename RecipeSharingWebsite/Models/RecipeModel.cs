using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public DateTime date_added { get; set; }
    }
}