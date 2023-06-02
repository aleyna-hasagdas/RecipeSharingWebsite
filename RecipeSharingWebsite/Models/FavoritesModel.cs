using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models;

public class FavoritesModel
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RecipeId { get; set; }
}