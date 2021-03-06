﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_CollectAccept_OuterSubject
    {
        public string OuterSubject { get; set; }
        public string BankName { get; set; }
        public string BillTitle { get; set; }
        public decimal MoneyAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public System.DateTime CollectDate { get; set; }
        public System.DateTime AcceptDate { get; set; }
        public string OpResult { get; set; }
        public System.DateTime TimeMark { get; set; }
    }
}