using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalorie_Сounter.DataBase
{
    public class Dish
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Calories { get; set; }
    }
}
