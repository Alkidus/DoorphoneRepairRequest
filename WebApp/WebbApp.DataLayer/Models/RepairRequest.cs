using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RepairRequest
    {
        public int Id { get; set; }
        public DateTime DateRepairBegin { get; set; } //дата поступления заявки
        public int AdressId { get; set; } //адрес заявки, адреса могут быть не из списков, частные вызовы к неабонентам
        public int Flat { get; set; } //номер квартиры
        public string DescriptionFromSubscriber { get; set; } //описание неисправности
        public DateTime DateRepairEnd { get; set; } //дата выполнения ремонта
        public string DescriptionFromServiceman { get; set; } // описание от мастеров что было отремонтировано, какие детали израсходованы
        public bool Status { get; set; } // статус заявки, true - в работе; false - выполнена
        public Nullable<int> SubscriberId { get; set; }
        public string Comments { get; set; } //дополнительные коментарии
        public virtual Subscriber Subscriber { get; set; }
    }
}
