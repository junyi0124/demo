using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using OdeToFood.Models;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Authorize]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };
                _restaurantData.Add(newRestaurant);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            var model = _restaurantData.Detail(id.Value);
            if(model==null) return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            var model = _restaurantData.Detail(restaurant.Id);
            model.Name = restaurant.Name;
            model.Cuisine = restaurant.Cuisine;
            _restaurantData.Update(model);
            return RedirectToAction("Index");
        }
    }
}
