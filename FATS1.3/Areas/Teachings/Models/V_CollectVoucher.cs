using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //托收凭证
    public class V_CollectVoucher
    {
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public decimal MoneyAmount { get; set; }
        public System.DateTime CollectDate { get; set; }
        public System.DateTime AcceptDate { get; set; }
        public string Purpose { get; set; }
        public string BankName { get; set; }
    }
}