using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace OdeToFood.Models
{
    public class OdeToFoodDbContext :IdentityDbContext<User>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        //public DbSet<> MyProperty { get; set; }
    }
}
