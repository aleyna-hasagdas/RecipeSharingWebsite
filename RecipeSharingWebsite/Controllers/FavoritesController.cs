using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;
using System.Linq;


namespace RecipeAleyna.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly RecipeDbContext _dbContext;

        public FavoritesController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddToFavorites(int recipeId, int userId)
        {
            bool exists = _dbContext.Favorites.Any(f => f.RecipeId == recipeId && f.UserId == userId);

            if (exists)
            {
                return BadRequest("Recipe already in favorites.");
            }

            var favoritesModel = new FavoritesModel
            {
                RecipeId = recipeId,
                UserId = userId
            };

            _dbContext.Favorites.Add(favoritesModel);
            _dbContext.SaveChanges();

            return Ok("Recipe added to favorites.");
        }

        [HttpPost]
        public IActionResult RemoveFromFavorites(int recipeId, int userId)
        {
            var favoritesModel = _dbContext.Favorites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);

            if (favoritesModel == null)
            {
                return NotFound();
            }

            _dbContext.Favorites.Remove(favoritesModel);
            _dbContext.SaveChanges();

            return Ok("Recipe removed from favorites.");
        }
    }
}