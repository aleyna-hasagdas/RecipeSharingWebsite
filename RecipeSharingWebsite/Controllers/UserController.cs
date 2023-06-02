using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;
using System;

namespace RecipeAleyna.Controllers
{
    public class UserController : Controller
    {
        private readonly RecipeDbContext _dbContext;

        public UserController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: User/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if the username or email already exists
                if (_dbContext.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
                {
                    ModelState.AddModelError("", "Username or Email already exists.");
                    return View(user);
                }

                // Save the user to the database
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (existingUser == null)
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                    return View(user);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        // GET: Home/Profile
        public ActionResult Profile()
        {
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.Username == User.Identity.Name);

            if (currentUser != null)
            {
                return View(currentUser);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
