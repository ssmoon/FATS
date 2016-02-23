using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Areas.Teachings.Models
{
    public class V_LoanVoucher
    {
        public string ClientName { get; set; }
        public string BankName { get; set; }
        public decimal MoneyAmount { get; set; }
        public int TchRoutineID { get; set; }
        public string TchRoutineTag { get; set; }
        public string Purpose { get; set; }
        public System.DateTime LoanDate { get; set; }
        public System.DateTime RepayDate { get; set; }
        public string LoanAcc { get; set; }
        public string RepayAcc { get; set; }
        public string LoanType { get; set; }
        public float InterestRate { get; set; }
        public decimal InterestAmount { get; set; }
    }
}