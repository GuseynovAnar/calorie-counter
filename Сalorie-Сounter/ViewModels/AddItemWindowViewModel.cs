using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Сalorie_Сounter.ViewModels
{
    class AddItemWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Dish> _dishes;
        public ObservableCollection<Dish> Dishes
        {
            get
            {
                return _dishes;
            }
            set
            {
                _dishes = value;
                OnPropertyChanged("Dishes");
            }
        }
        private ObservableCollection<Category> _categories;
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
        private DataBaseRepository _repo = new DataBaseRepository();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        // получение блюд и категорий из бд при создании вьюмодели
        public AddItemWindowViewModel()
        {
            GetDishes();
            Categories = new ObservableCollection<Category>(_repo.GetCategories());
        }

        // получение списка всех блюд из бд
        public void GetDishes()
        {
            Dishes = new ObservableCollection<Dish>(_repo.GetDishes());
        }

        // получение списка всех блюд конкретной категории из бд
        public void GetDishes(Category category)
        {
            if (category != null)
                Dishes = new ObservableCollection<Dish>(_repo.GetDishes(category));
            else
                GetDishes();
        }

        // добавление записи в таблицу истории
        public void AddDishToHistory(Dish dish, float quantity)
        {
            _repo.AddEatingHistoryItem(dish, quantity);
        }
    }
}
