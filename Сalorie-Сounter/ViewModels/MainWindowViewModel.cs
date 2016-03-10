using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Calorie_Counter.ViewModels
{
    class MainWindowViewModel
    {
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        private Dictionary<string, List<Dish>> _dailyHistory;
        public Dictionary<string, List<Dish>> DailyHistory
        {
            get
            {
                return _dailyHistory;
            }
            set
            {
                _dailyHistory = value;
            }
        }
        DataBaseRepository _repo = new DataBaseRepository();

        public void GetDailyInfo(DateTime date)
        {
            DailyHistory = _repo.GetDailyHistoryData(date); 
        }
    }
}
