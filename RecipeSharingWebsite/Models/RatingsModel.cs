using System.ComponentModel.DataAnnotations;

namespace RecipeAleyna.Models;

public class RatingsModel 
{
    [Key]
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
}
