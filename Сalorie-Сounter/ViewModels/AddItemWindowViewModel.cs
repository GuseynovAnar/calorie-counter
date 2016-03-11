using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Сalorie_Сounter.ViewModels
{
    class AddItemWindowViewModel
    {
        private List<Dish> _allDishes;
        public List<Dish> AllDishes
        {
            get
            {
                return _allDishes;
            }

            set
            {
                _allDishes = value;
            }
        }
        DataBaseRepository _repo = new DataBaseRepository();

        public void GetAllDishes()
        {
            AllDishes = _repo.GetDishes();
        }

        public void AddDishToHistory(Dish dish, float quantity)
        {
            _repo.AddEatingHistoryItem(dish, quantity);
        }
    }
}
