//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FATS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndividualSaving
    {
        public int Row_ID { get; set; }
        public System.DateTime DepositTime { get; set; }
        public string DepositClient { get; set; }
        public string BankName { get; set; }
        public System.DateTime WithdrawTime { get; set; }
        public string WithdrawClient { get; set; }
        public string InterestClient { get; set; }
        public System.DateTime AccountCreateTime { get; set; }
        public System.DateTime InterestTime { get; set; }
        public string VoucherNo { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal EntryAmount { get; set; }
        public string ClientAcc { get; set; }
        public int TchRoutineID { get; set; }
        public string TchRoutineTag { get; set; }
        public string DepositPeriod { get; set; }
    }
}
