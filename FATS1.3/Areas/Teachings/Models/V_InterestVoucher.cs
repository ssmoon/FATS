using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_InterestVoucher
    {        
        public DateTime InterestTime { get; set; }
        public string Abstract { get; set; }
        public string ClientAcc { get; set; }
        public string SettleInterestClient { get; set; }
        public decimal InterestAmount { get; set; }
        public string BankName { get; set; }
    }
}