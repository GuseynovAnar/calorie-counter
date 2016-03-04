using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalorie_Сounter.DataBase
{
    public class DataBaseRepository
    {
        public DataBaseRepository()
        {
            using (Context context = new Context())
            {
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                    context.SaveChanges();
                }
            }
        }
    }
}
