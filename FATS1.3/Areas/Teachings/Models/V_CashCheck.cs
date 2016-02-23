using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_CashCheck
    {
        public DateTime TimeMark { get; set; }
        public string BankName { get; set; }
        public string ClientName { get; set; }
        public string ClientAcc { get; set; }
        public decimal EntryAmount { get; set; }
        public string Purpose { get; set; }
    }
}