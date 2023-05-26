using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;


namespace RecipeAleyna.Controllers;
[ApiController]
[Route("(UserController)")]
public class UserController : Controller
{
    // GET action for displaying the recipe submission form
    [HttpGet]
    public IActionResult RecipeSubmissionForm()
    {
        // Create a new instance of the RecipeViewModel and pass it to the view
        var recipe = new RecipesModel();
        return View(Create); //tarif sayfası
    }
        
    // GET action for displaying the success page or the newly submitted recipe
    [HttpGet]
    public IActionResult RecipeSubmitted(int id)
    {
        // Retrieve the submitted recipe from the database or any other storage based on the id
            
        // Pass the recipe to the view for displaying
        var recipe = new RecipesModel(); // Replace with actual retrieval logic
        return View(recipe);
    }
}