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
        void Update(Restaurant r);
        void Delete(Restaurant r);
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

        public void Delete(Restaurant r)
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

        public void Update(Restaurant r)
        {
            throw new NotImplementedException();
        }
    }
}
