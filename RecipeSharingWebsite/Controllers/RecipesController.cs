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
        
        // GET: /Recipe/Index
        public IActionResult Index()
        {
            List<Recipe> recipes = _dbContext.Recipes.ToList();
            return View(recipes);
        }

        // GET: /Recipe/Details/5
        public IActionResult Detail(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // GET: /Recipe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.date_added = DateTime.Now;
                _dbContext.Recipes.Add(recipe);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to the home page or any other appropriate action
            }
            return View(recipe);
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
                return RedirectToAction("Details", new { id });
            }
            return View(recipe);
        }

        // GET: /Recipe/Delete/5
        public IActionResult Delete(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: /Recipe/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home"); // Redirect to the home page or any other appropriate action
        }
    }
}
