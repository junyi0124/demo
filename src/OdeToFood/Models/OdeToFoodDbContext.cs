using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class OdeToFoodDbContext :DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        //public DbSet<> MyProperty { get; set; }
    }
}
