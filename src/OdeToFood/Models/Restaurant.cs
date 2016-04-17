using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [StringLength(80), Required]
        public string Name { get; set; }

        public Cuisine Cuisine { get; set; }
    }
}
