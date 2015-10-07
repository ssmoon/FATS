using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //转账支票
    public class V_IndividualDeposit
    {
        public string DepositType { get; set; }
        public DateTime DepositTime { get; set; }
        public string DepositClient { get; set; }
        public string ClientAcc { get; set; }
        public string DepositPeriod { get; set; }
        public decimal EntryAmount { get; set; }
        public string BankName { get; set; }
    }
}