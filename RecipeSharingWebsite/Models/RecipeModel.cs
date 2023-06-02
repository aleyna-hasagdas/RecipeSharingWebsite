using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public DateTime date_added { get; set; }
    }



}