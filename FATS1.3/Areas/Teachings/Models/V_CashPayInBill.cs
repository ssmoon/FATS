using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_CashPayInBill
    {
        public string ClientName { get; set; }
        public string ClientAcc { get; set; }
        public string BankName { get; set; }
        public string MoneySource { get; set; }
        public string PayInMan { get; set; }
        public DateTime TimeMark { get; set; }
        public decimal EntryAmount { get; set; }
    }
}