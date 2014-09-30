using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //转账支票
    public class V_TransferCheck
    {
        public DateTime ChequeDate { get; set; }
        public string PayeeBank { get; set; }
        public string PayeeAcc { get; set; }
        public string RemitterName { get; set; }
        public string Purpose { get; set; }
        public decimal MoneyAmount { get; set; }
    }
}