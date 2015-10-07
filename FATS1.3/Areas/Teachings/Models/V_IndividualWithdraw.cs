using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //转账支票
    public class V_IndividualWithdraw
    {
        public string WithdrawType { get; set; }
        public DateTime WithdrawTime { get; set; }
        public string WithdrawClient { get; set; }
        public string ClientAcc { get; set; }
        public string WithdrawPeriod { get; set; }
        public decimal EntryAmount { get; set; }
        public string BankName { get; set; }
    }
}