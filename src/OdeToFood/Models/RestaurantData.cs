using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public interface IRestaurantData
    {
        List<Restaurant> GetAll();
        Restaurant Detail(int id);
        void Add(Restaurant r);
        int Update(Restaurant model);
        //void Delete(Restaurant r);
    }

    public class InMemoryData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id=1, Name="全聚德" },
                new Restaurant { Id=2, Name="东来顺" },
                new Restaurant { Id=3, Name="星期五" }
            };
        }
        public void Add(Restaurant r)
        {
            throw new NotImplementedException();
        }

        public Restaurant Detail(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public List<Restaurant> GetAll()
        {
            return restaurants;
        }

        public int Update(Restaurant model)
        {
            throw new NotImplementedException();
            return 0;
        }
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _ctx;

        public SqlRestaurantData(OdeToFoodDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(Restaurant r)
        {
            _ctx.Add(r);
            _ctx.SaveChanges();
        }

        public Restaurant Detail(int id)
        {
            return _ctx.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public List<Restaurant> GetAll()
        {
            return _ctx.Restaurants.ToList();
        }

        public int Update(Restaurant model)
        {
            _ctx.Update(model);
            return _ctx.SaveChanges();
        }
    }
}
