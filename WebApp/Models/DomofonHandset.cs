using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DomofonHandset
    {
        public int Id { get; set; }
        public string DomofonHandsetType { get; set; } //тип домофонной трубки
        public string Comments { get; set; } // примечание
    }
}
