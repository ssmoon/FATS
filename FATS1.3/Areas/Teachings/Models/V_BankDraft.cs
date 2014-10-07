using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //银行汇票
    public class V_BankDraft
    {
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public decimal MoneyAmount { get; set; }
        public DateTime DraftDate { get; set; }
        public string Purpose { get; set; }
        public decimal CloseAmount { get; set; }
    }
}