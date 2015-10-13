using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_BankAcceptBill_OuterSubject
    {
        public string OuterSubject { get; set; }
        public string BankName { get; set; }
        public decimal MoneyAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public System.DateTime IncomeBillDate { get; set; }
        public System.DateTime DrawBillDate { get; set; }
        public string OpResult { get; set; }
        public int CurrStatus { get; set; }
        public DateTime TimeMark { get; set; }
    }
}