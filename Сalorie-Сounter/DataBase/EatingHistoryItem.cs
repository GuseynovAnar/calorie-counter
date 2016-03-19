using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalorie_Сounter.DataBase
{
    public class EatingHistoryItem
    {
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int DishId { get; set; }
        [ForeignKey("DishId")]
        public virtual Dish Dish { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public float Proteins { get; set; }
        [Required]
        public float Fats { get; set; }
        [Required]
        public float Calories { get; set; }
        [Required]
        public float Carbohydrates { get; set; }
    }
}
