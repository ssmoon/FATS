﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //商业承兑汇票
    public class V_TradeAcceptance
    {
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public decimal MoneyAmount { get; set; }
        public DateTime DrawBillDate { get; set; }
        public DateTime IncomeBillDate { get; set; }
        public string Purpose { get; set; }
    }
}