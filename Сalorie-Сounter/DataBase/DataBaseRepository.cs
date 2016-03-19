using System;
using System.Collections.Generic;
using System.IO;
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
                    var categories = LoadCategoriesFromFile();
                    _context.Categories.AddRange(categories);
                    var dishes = LoadDishesFromFile();
                    _context.Dishes.AddRange(dishes);
                    var history = LoadHistoryFromFile();
                    _context.EatingHistory.AddRange(history);
                    _context.SaveChanges();
                }
            }
        }

        private List<Category> LoadCategoriesFromFile()
        {
            var categories = new List<Category>();
            using (var sr = new StreamReader("../../DataBaseFiles/categories.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var items = line.Split('\t');
                    categories.Add(new Category
                    {
                        Name = items[0]
                    });
                }
            }
            return categories;
        }
        private List<Dish> LoadDishesFromFile()
        {
            var dishes = new List<Dish>();
            using (var sr = new StreamReader("../../DataBaseFiles/dishes.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var items = line.Split('\t');
                    dishes.Add(new Dish
                    {
                        Name = items[0],
                        Calories = float.Parse(items[1]),
                        Proteins = float.Parse(items[2]),
                        Fats = float.Parse(items[3]),
                        Carbohydrates = float.Parse(items[4]),
                        CategoryId = int.Parse(items[5])
                    });
                }
            }
            return dishes;
        }
        private List<EatingHistoryItem> LoadHistoryFromFile()
        {
            var history = new List<EatingHistoryItem>();
            using (var sr = new StreamReader("../../DataBaseFiles/history.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var items = line.Split('\t');
                    history.Add(new EatingHistoryItem
                    {
                        Date = DateTime.Parse(items[0]).Date,
                        DishId = int.Parse(items[1]),
                        Quantity = float.Parse(items[2]),
                        Calories = float.Parse(items[3]),
                        Proteins = float.Parse(items[4]),
                        Fats = float.Parse(items[5]),
                        Carbohydrates = float.Parse(items[6])
                    });
                }
            }
            return history;
        }

        public void AddDish(Dish dish)
        {
            using (_context = new Context())
            {
                if (dish.Category != null)
                    _context.Categories.Attach(dish.Category);
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
                        where d.Category.Id == category.Id
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
                                select d).ToList(); // как это работает?!
                return request;
            }
        }
    }
}
