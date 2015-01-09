using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_OuterSubject
    {
        public string OuterSubject { get; set; }
        public DateTime TimeMark { get; set; }
        public string Abstract { get; set; }
        public string CustomerAccNo { get; set; }
        public string BillTitle { get; set; }
        public decimal MoneyAmount { get; set; }
    }
}