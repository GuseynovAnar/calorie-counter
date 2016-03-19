using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Сalorie_Сounter.DataBase;
using Calorie_Counter;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<EatingHistoryItem> items = new List<EatingHistoryItem>();
            EatingHistoryItem item1 = new EatingHistoryItem()
            {
                Calories = 100,
                Carbohydrates = 100,
                Fats = 100,
                Proteins = 100
            };
            EatingHistoryItem item2 = new EatingHistoryItem()
            {
                Calories = 20,
                Carbohydrates = 10,
                Fats = 0,
                Proteins = 30
            };
            items.Add(item1);
            items.Add(item2);
            FoodStatisticsCounter counter = new FoodStatisticsCounter();

            FoodStats stats = counter.CountFoodStatistics(items);

            Assert.AreEqual(120, stats.Calories);
            Assert.AreEqual(110, stats.Carbohydrates);
            Assert.AreEqual(100, stats.Fats);
            Assert.AreEqual(130, stats.Proteins);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod2()
        {
            DataBaseRepository repository = new DataBaseRepository();
            repository.AddDish(null);
        }
    }
}
