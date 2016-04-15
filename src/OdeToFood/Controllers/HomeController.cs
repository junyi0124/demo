using Microsoft.AspNet.Mvc;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            //var model = new Restaurant {Id=1, Name="全聚德" };
            var model = _restaurantData.GetAll();
            return View(model);
        }

        public IActionResult Details(int Id)
        {
            var model = _restaurantData.Detail(Id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
    }
}
