using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;
using System;

namespace RecipeAleyna.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeDbContext _dbContext;

        public RecipesController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET: /Recipes/Index
        public ActionResult RedirectRecipes()
        {
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Index()
        {
            List<Recipe> recipes = _dbContext.Recipes.ToList();
            return View(recipes);
        }


        // GET: /Recipes/Detail/5
        public IActionResult Detail(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // GET: /Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.date_added = DateTime.Now;
                _dbContext.Recipes.Add(recipe);
                _dbContext.SaveChanges();
                return RedirectToAction("Detail", new { recipe.Id });
            }

            return View();
        }

        
        // GET: /Recipe/Edit/5
        public IActionResult Edit(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: /Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Update(recipe);
                _dbContext.SaveChanges();
                return RedirectToAction("Detail", new { id });
            }
            return View(recipe);
        }

        

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
