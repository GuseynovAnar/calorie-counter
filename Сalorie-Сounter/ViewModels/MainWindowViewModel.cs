using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Calorie_Counter.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<EatingHistoryItem> _dailyHistory;
        public List<EatingHistoryItem> DailyHistory
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
        DataBaseRepository _repo = new DataBaseRepository();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void GetDailyInfo(DateTime date)
        {
            DailyHistory = _repo.GetDailyHistoryData(date);
            if (date.Date == DateTime.Now.Date)
                IsCurrentDate = true;
            else
                IsCurrentDate = false;
        }

        public void DeleteItem(EatingHistoryItem item)
        {
            _repo.RemoveEatingHistoryItem(item);
            DailyHistory = _repo.GetDailyHistoryData(DateTime.Now);
        }
    }
}
