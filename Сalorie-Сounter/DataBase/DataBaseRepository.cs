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
                _context.SaveChanges(); // async
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

        public void AddEatingHistoryItem()
        {

        }

        public Dictionary<string, List<Dish>> GetDailyHistoryData(DateTime date)
        {
            using (_context = new Context())
            {
                var joinRequest =
                     from eh in _context.EatingHistory
                     where eh.Date == date.Date
                     join d in _context.Dishes on eh.Dish equals d
                     select new
                     {
                         EatingType = eh.EatingType,
                         Dish = d
                     };
                var groupRequest =
                    from j in joinRequest
                    group j by j.EatingType.Name;
                Dictionary<string, List<Dish>> historyDict = new Dictionary<string, List<Dish>>();
                var typesRequest = from t in _context.EatingTypes
                                   select t;
                foreach (var t in typesRequest)
                    historyDict.Add(t.Name, null);
                foreach (var g in groupRequest)
                {
                    List<Dish> tempList = new List<Dish>();
                    foreach (var item in g)
                        tempList.Add(item.Dish);
                    historyDict[g.Key] = tempList;
                }
                return historyDict;
            }
        }
    }
}
