using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Calorie_Counter.ViewModels
{
    class NewItemWindowViewModel
    {
        DataBaseRepository _repo = new DataBaseRepository(); // vs ctor
        ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
            }
        }

        public NewItemWindowViewModel()
        {
            Categories = new ObservableCollection<Category>(_repo.GetCategories());
        }
         
        public void AddNewItem(Dish dish)
        {
            _repo.AddDish(dish);
        }
    }
}
