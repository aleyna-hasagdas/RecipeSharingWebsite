using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RecipeAleyna.Data;
using RecipeAleyna.Models;

namespace RecipeAleyna.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                List<RecipeModel> recipes = GetRecipesFromDatabase();

                return View(recipes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("Error");
            }
        }
        
        public IActionResult Detail()
        {
            return View();
        }

        private List<RecipeModel> GetRecipesFromDatabase()
        {
            List<RecipeModel> recipes = new List<RecipeModel>
            {
                new RecipeModel { RecipeName = "Recipe 1", Description = "Description 1", Category = "Category 1" },
                new RecipeModel { RecipeName = "Recipe 2", Description = "Description 2", Category = "Category 2" },
                new RecipeModel { RecipeName = "Recipe 3", Description = "Description 3", Category = "Category 3" }
            };

            return recipes;
        }
        
        [HttpGet]
        [Route("/Recipes/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        
        [HttpPost]
        [Route("/Recipes/Create")]
        public IActionResult Create([FromBody] RecipeModel model)
        {
            try
            {
                // Hocam, aşağıdaki kodu düzeltme şansımız olmadığından dolayı bir yorum satırı gibi eklemek istedik.
                // SaveRecipeToDatabase(model);
                
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the error and return an error response
                Console.WriteLine(ex);
                return BadRequest("Error creating recipe. Please try again.");
            }
        }
        
        
        // Hocam, aşağıdaki kodu düzeltme şansımız olmadığından dolayı bir yorum satırı gibi eklemek istedik.
        
        /*
        using (var dbContext = new RecipeDbContext())
        { 
            Recipe recipe = new Recipe 
            { 
                UserName = model.UserName, 
                Description = model.Description, 
                Category = model.Category, 
                Image = model.Image,
                Instructions = model.Instructions, 
                DateAdded = DateTime.Now, // Şu anki tarih ve saat
                RecipeName = model.RecipeName 
            };
            
            foreach (var ingredient in model.Ingredients) 
            { 
                recipe.Ingredients.Add(new Ingredient 
                {
                    Name = ingredient,
                    RecipeId = recipe.RecipeId // malzemeleri tarif ile bagladik
                }); 
            }
            dbContext.Recipes.Add(recipe);
            dbContext.SaveChanges(); 
        } */
        
    }

}
