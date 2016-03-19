using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalorie_Сounter.DataBase
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Proteins { get; set; }
        [Required]
        public float Fats { get; set; }
        [Required]
        public float Carbohydrates { get; set; }
        [Required]
        public float Calories { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual List<EatingHistoryItem> EatingHistoryItems { get; set; }
    }
}
