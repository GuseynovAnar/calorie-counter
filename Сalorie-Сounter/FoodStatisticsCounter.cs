using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сalorie_Сounter.DataBase;

namespace Calorie_Counter
{
    public class FoodStatisticsCounter
    {
        public FoodStats CountFoodStatistics(List<EatingHistoryItem> history)
        {
            FoodStats stats = new FoodStats();
            foreach (var item in history)
            {
                stats.Calories += item.Calories;
                stats.Carbohydrates += item.Carbohydrates;
                stats.Fats += item.Fats;
                stats.Proteins += item.Proteins;
            }
            return stats;
        }
    }
}
