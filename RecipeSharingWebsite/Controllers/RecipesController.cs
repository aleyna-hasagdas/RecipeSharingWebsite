using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;

namespace RecipeAleyna.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeDbContext _dbContext;

        public RecipesController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipesModel recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.DateAdded = DateTime.Now.ToString();
                _dbContext.Recipes.Add(recipe);
                await _dbContext.SaveChangesAsync();

                // Tarif başarıyla kaydedildiyse, kullanıcıyı tarifin ayrıntılar sayfasına yönlendiriyoruzz
                return RedirectToAction("RecipePage", new { id = recipe.RecipeId });
            }

            // ModelState.IsValid false ise, hatalı bir giriş olduğunu varsayalım ve Create view'ini tekrar gösterelim
            return View("Create", recipe);
        }

        public IActionResult RecipePage(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();//error sayfası
            }

            return View("RecipePage", recipe);
        }

        public IActionResult Search(string searchTerm)
        {
            var recipes = _dbContext.Recipes.Where(r => r.Ingredient != null && r.RecipeName != null 
                                                                             && (r.RecipeName.Contains(searchTerm) 
                                                                                 || r.Ingredient.Contains(searchTerm))).ToList();
            return View("Search", recipes); 
        }

        public IActionResult Details(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View("Details", recipe);
        }

        public IActionResult Submit()
        {
            return View();//Submit isimli sayfayı döndürür
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(RecipesModel recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.DateAdded = DateTime.Now.ToString();
                _dbContext.Recipes.Add(recipe);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("RecipePage", new { id = recipe.RecipeId });
            }

            return View(recipe);
        }

        public IActionResult Edit(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RecipesModel editedRecipe)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // güncelleme
                recipe.RecipeName = editedRecipe.RecipeName;
                recipe.Description = editedRecipe.Description;
                recipe.Category = editedRecipe.Category;
                recipe.Image = editedRecipe.Image;
                recipe.Instructions = editedRecipe.Instructions;
                recipe.Ingredient = editedRecipe.Ingredient;

                await _dbContext.SaveChangesAsync();

                return RedirectToAction("RecipePage", new { id });
            }

            return View(editedRecipe);
        }

        public IActionResult Delete(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
