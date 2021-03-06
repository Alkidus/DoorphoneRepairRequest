using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } //название      
        public string CompanyAdress { get; set; } //адрес
        public string CompanyPhone { get; set; } //тедефон
        public string CompanyAccount { get; set; } //расчетный счет в банке
        public string CompanyCode { get; set; } //код ЕДРПОУ
        public string CompanyBankCode { get; set; } // МФО банка
    }
}
