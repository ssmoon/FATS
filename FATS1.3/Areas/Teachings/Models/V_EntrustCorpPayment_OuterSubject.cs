using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //shared by Bank and Corp,  
    //PayeeAcc is not used in Bank Payment
    public class V_EntrustPayment_OuterSubject
    {
        public string OuterSubject { get; set; }        
        public string BillTitle { get; set; }
        public decimal MoneyAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public System.DateTime TimeMark { get; set; }
        public string OpResult { get; set; }
    }
}