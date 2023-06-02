using Microsoft.EntityFrameworkCore;
using RecipeAleyna.Models;

namespace RecipeAleyna.Data
{
    public class RecipeDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RatingsModel> Ratings { get; set; }
        public DbSet<FavoritesModel> Favorites { get; set; }
        public DbSet<User> Users { get; set; }

        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {
        }
        

    }
}