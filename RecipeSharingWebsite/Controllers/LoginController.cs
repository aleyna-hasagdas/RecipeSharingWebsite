using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeAleyna.Data;
using RecipeAleyna.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeAleyna.Controllers
{
    public class LoginController : Controller
    {
        private readonly RecipeDbContext _dbContext;
        private readonly UserManager<UserModel> _userManager;

        public LoginController(RecipeDbContext dbContext, UserManager<UserModel> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Check if the username and password match
            if (model.Username != null)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (model.Password != null && (user == null || !_userManager.CheckPasswordAsync(user, model.Password).Result))
                {
                    ModelState.AddModelError("Username", "Invalid username or password.");
                    return BadRequest(ModelState);
                }

                if (user != null)
                {
                    var profileViewModel = new UserModel
                    {
                        Username = user.Username,
                        Email = user.Email,
                        UserImageLink = user.UserImageLink,
                        Name = user.Name,
                        Surname = user.Surname,
                        Description = user.Description
                    };

                    return View("Profile", profileViewModel);
                }
            }

            return BadRequest();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }
            
            var profileViewModel = new UserModel()
            {
                Username = user.Username,
                Email = user.Email,
                UserImageLink = user.UserImageLink,
                Name = user.Name,
                Surname = user.Surname,
                Description = user.Description
            };

            return View(profileViewModel);
        }
    }
}
