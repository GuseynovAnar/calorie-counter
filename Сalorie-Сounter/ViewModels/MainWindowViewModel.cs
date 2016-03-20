using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Calorie_Counter.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EatingHistoryItem> _dailyHistory;
        public ObservableCollection<EatingHistoryItem> DailyHistory
        {
            get
            {
                return _dailyHistory;
            }
            set
            {
                _dailyHistory = value;
                OnPropertyChanged("DailyHistory");
            }
        }
        private bool _isCurrentDate;
        public bool IsCurrentDate
        {
            get
            {
                return _isCurrentDate;
            }
            set
            {
                _isCurrentDate = value;
                OnPropertyChanged("IsCurrentDate");
            }
        }

        private FoodStats _dailyFoodStatistics;
        public FoodStats DailyFoodStatistics
        {
            get
            {
                return _dailyFoodStatistics;
            }
            set
            {
                _dailyFoodStatistics = value;
                OnPropertyChanged("DailyFoodStatistics");
            }
        }
        private DataBaseRepository _repo = new DataBaseRepository();
        private FoodStatisticsCounter _counter = new FoodStatisticsCounter();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        // получение полной информации за конкретный день - список блюд, возможность добавления новых блюд и статистику
        public void GetDailyInfo(DateTime date)
        {
            DailyHistory = new ObservableCollection<EatingHistoryItem>(_repo.GetDailyHistoryData(date));
            if (date.Date == DateTime.Now.Date)
                IsCurrentDate = true;
            else
                IsCurrentDate = false;
            DailyFoodStatistics = _counter.CountFoodStatistics(DailyHistory.ToList());
        }

        // удаление элемента из таблицы с историей и обновление статистики
        public void DeleteItem(EatingHistoryItem item)
        {
            _repo.RemoveEatingHistoryItem(item);
            DailyHistory.Remove(item);
            DailyFoodStatistics = _counter.CountFoodStatistics(DailyHistory.ToList());
        }
    }
}
