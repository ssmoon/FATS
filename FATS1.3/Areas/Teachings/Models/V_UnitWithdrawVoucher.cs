using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //单位存款支取凭证
    public class V_UnitWithdrawVoucher
    {
        public DateTime TimeMark { get; set; }
        public string BankName { get; set; }
        public string ClientName { get; set; }
        public string ClientAcc { get; set; }
        public decimal EntryAmount { get; set; }
        public decimal InterestAmount { get; set; }
    }
}