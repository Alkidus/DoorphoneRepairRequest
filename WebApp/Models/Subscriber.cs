using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Subscriber
    {
        public Subscriber()
        {
            RepairRequests = new List<RepairRequest>();
        }
        public int Id { get; set; }
        public string Name { get; set; } //имя
        public string Surname { get; set; } //фамилия
        public string Phone { get; set; } //телефон
        public int Flat { get; set; } //номер квартиры
        public string ContractNumb { get; set; } //номер договора
        public DateTime ContractDate { get; set; } //дата заключения договора
        public string Code { get; set; } //индивидуальный код абонента
        public int AdressId { get; set; } //адресс
        public int DomofonHandsetId { get; set; } //тип трубки
        public int DomofonKeyId { get; set; } //тип ключа
        public string Comments { get; set; } //коментарии
        public int RepairRequestId { get; set; } //заявки
        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
