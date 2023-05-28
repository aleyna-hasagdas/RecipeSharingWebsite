using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models;
public class RecipesModel
{
    public int RecipeId { get; set; }
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? Category { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public string? Instructions { get; set; }
    [Required]
    public string? Ingredient { get; set; }
    [Required]
    public string? DateAdded { get; set; }
    [Required]
    public string? RecipeName { get; set; }

}