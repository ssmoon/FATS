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
    
    public partial class TransferCheck
    {
        public int Row_ID { get; set; }
        public string RemitterName { get; set; }
        public string RemitterAcc { get; set; }
        public string RemitterBank { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAcc { get; set; }
        public string PayeeBank { get; set; }
        public decimal MoneyAmount { get; set; }
        public string CheckNo { get; set; }
        public System.DateTime ChequeDate { get; set; }
        public System.DateTime IncomeBillDate { get; set; }
        public string Purpose { get; set; }
        public int TchRoutineID { get; set; }
        public string TchRoutineTag { get; set; }
    }
}
