using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalorie_Сounter.DataBase
{
    public class DataBaseRepository
    {
        Context _context;
        public DataBaseRepository()
        {
            using (_context = new Context())
            {
                if (!_context.Database.Exists())
                {
                    _context.Database.Create();
                    _context.SaveChanges();
                }
            }
        }

        public void AddDish(Dish dish)
        {
            using (_context = new Context())
            {
                _context.Dishes.Add(dish);
                _context.SaveChanges(); // async???
            }
        }

        public List<Dish> GetDishes()
        {
            using (_context = new Context())
            {
                return _context.Dishes.ToList();
            }
        }

        public List<Dish> GetDishes(Category category)
        {
            using (_context = new Context())
            {
                return (from d in _context.Dishes
                        where d.Category == category
                        select d).ToList();
            }
        }

        public List<Category> GetCategories()
        {
            using (_context = new Context())
            {
                return _context.Categories.ToList();
            }
        }

        public void AddEatingHistoryItem(Dish dish, float quantity)
        {
            EatingHistoryItem eatingHistoryItem = new EatingHistoryItem
            {
                Date = DateTime.Now.Date,
                Dish = dish,
                Quantity = quantity,
                Calories = dish.Calories / 100 * quantity,
                Fats = dish.Fats / 100 * quantity,
                Proteins = dish.Proteins / 100 * quantity,
                Carbohydrates = dish.Carbohydrates / 100 * quantity
            };
            using (_context = new Context())
            {
                _context.Dishes.Attach(dish);
                _context.EatingHistory.Add(eatingHistoryItem);
                _context.SaveChanges();
            }
        }

        public void RemoveEatingHistoryItem(EatingHistoryItem item)
        {
            using (_context = new Context())
            {
                var request = from eh in _context.EatingHistory
                              where eh.ID == item.ID
                              select eh;
                _context.EatingHistory.Remove(request.Single());
                _context.SaveChanges();
            }
        }

        public List<EatingHistoryItem> GetDailyHistoryData(DateTime date)
        {
            using (_context = new Context())
            {
                var request = (from eh in _context.EatingHistory
                               where eh.Date == date.Date
                               select eh).ToList();
                var request1 = (from eh in _context.EatingHistory
                                where eh.Date == date.Date
                                join d in _context.Dishes on eh.Dish equals d
                                select d).ToList(); // ???
                return request;
            }
        }

        public List<EatingHistoryItem> GetDailyHistoryData(DateTime beginDate, DateTime endDate)
        {
            if (beginDate.Date > endDate.Date)
                return null;
            var request = (from eh in _context.EatingHistory
                           where eh.Date >= beginDate.Date && eh.Date <= endDate.Date
                           select eh).ToList();
            var request1 = (from eh in _context.EatingHistory
                            where eh.Date >= beginDate.Date && eh.Date <= endDate.Date
                            join d in _context.Dishes on eh.Dish equals d
                            select d).ToList(); // ???
            return request;
        }
    }
}
