using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DomofonKey
    {
        public int Id { get; set; }
        public string DomofonKeyType { get; set; } //тип домофонного ключа
        //public ICollection<Adress> Adresses { get; set; }
        //public DomofonKey()
        //{
        //    Adresses = new List<Adress>();
        //}
    }
}
