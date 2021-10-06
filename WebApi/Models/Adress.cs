using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string City { get; set; }//город
        public string Street { get; set; }//улица
        public int House { get; set; }//№ дома
        public string Corpus { get; set; }//№ корпуса
        public int Entrance { get; set; } //номер подезда в доме
        public string ContractNumb { get; set; } //номер договора
        public int FlatCount { get; set; } //общее количество квартир в поъезде
        public int DoorsCount { get; set; } //общее количество дверей в поъезде
        public int? DomofonSystemId { get; set; } //тип домофонной системы
        public int DomofonKeyId { get; set; }//тип или код ключа
        public DomofonSystem DomofonSystem { get; set; }
        public DomofonKey DomofonKey { get; set; }
    }
}
