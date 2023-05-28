using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;
using Microsoft.EntityFrameworkCore;


namespace RecipeAleyna.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RecipeDbContext _dbContext;

        public RatingsController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Rate(int id, int rating)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }
    
            var ratingModel = new RatingsModel()
            {
                RecipeId = id,
                Rating = rating
            };

            _dbContext.Set<RatingsModel>().Add(ratingModel);
            _dbContext.SaveChanges();

            return RedirectToAction("RecipePage", new { id });
        }

        public IActionResult RecipePage(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View("RecipeDetail", recipe);
        }
    }
}