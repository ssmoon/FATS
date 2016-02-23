using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_DiscountingVoucher
    {
        public System.DateTime TimeMark { get; set; }
        public System.DateTime DraftDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public string ClientAcc { get; set; }
        public string ClientName { get; set; }
        public string BankName { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherType { get; set; }
        public decimal EntryAmount { get; set; }
        public decimal DiscountInterest { get; set; }
        public decimal DiscountAmount { get; set; }
        public double DiscountRate { get; set; }
        public string AcceptBank { get; set; }
        
    }
}