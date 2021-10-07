using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DomofonSystem
    {
        public int Id { get; set; }
        public string DomofonSystemType { get; set; } //тип домофонной системы
        public string Comments { get; set; } // примечание
        public ICollection<Adress> Adresses { get; set; }
        public DomofonSystem()
        {
            Adresses = new List<Adress>();
        }
    }
}
