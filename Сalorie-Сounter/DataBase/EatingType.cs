using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalorie_Сounter.DataBase
{
    public class EatingType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<EatingHistoryItem> EatingHistoryItems { get; set; }
    }
}
