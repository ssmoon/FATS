using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_InterestSummons
    {
        public string ClientName { get; set; }
        public string ClientAcc { get; set; }
        public DateTime TimeMark { get; set; }
        public decimal InterestAmount { get; set; }
        public string BankName { get; set; }
    }
}