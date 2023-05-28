using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RecipeAleyna.Models
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Instructions { get; set; }

        public List<IngredientModel> Ingredients { get; set; }

        [Required]
        public string DateAdded { get; set; }

        [Required]
        public string RecipeName { get; set; }
    }

    public class IngredientModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}