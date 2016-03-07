using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public EatingType EatingType { get; set; }
        [Required]
        public Dish Dish { get; set; }
    }
}
