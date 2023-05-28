// RegisterController.cs
using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;
using System.Linq;

namespace RecipeAleyna.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RecipeDbContext _dbContext;

        public RegisterController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            
            bool usernameExists = _dbContext.User.Any(u => u.Username == model.Username);

            if (usernameExists)
            {
                ModelState.AddModelError("Username", "Username already exists.");
                return BadRequest(ModelState);
            }

            
            var user = new UserModel
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                UserImageLink = model.UserImageLink,
                Name = model.Name,
                Surname = model.Surname,
                Description = model.Description
            };
            
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            if (user.Username != null) HttpContext.Session.SetString("Username", user.Username);

            // Store the user's authentication information (e.g., in a session or cookie)
            // Redirect the user to their profile or a desired page

            return RedirectToAction("Profile", "User");
        }
    }
}