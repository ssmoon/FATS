using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    //业务委托书
    public class V_SpecialTransferVoucher
    {
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public string BankName { get; set; }
        public decimal MoneyAmount { get; set; }
        public DateTime TimeMark { get; set; }
        public string TransferOrient { get; set; }
        public string OrgVoucherName { get; set; }
        public string OrgVoucherNo { get; set; }
        public decimal OrgVoucherAmount { get; set; }
        public string TransferReason { get; set; }
    }
}