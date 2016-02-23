﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FATContainer : DbContext
    {
        public FATContainer()
            : base("name=FATContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CustomerLedger> CustomerLedger { get; set; }
        public DbSet<DetailedLedger> DetailedLedger { get; set; }
        public DbSet<FATUser> FATUser { get; set; }
        public DbSet<FATUserGroup> FATUserGroup { get; set; }
        public DbSet<GeneralLedger> GeneralLedger { get; set; }
        public DbSet<StudentActivity> StudentActivity { get; set; }
        public DbSet<SubjectItem> SubjectItem { get; set; }
        public DbSet<TeachingNode> TeachingNode { get; set; }
        public DbSet<TeachingRoutine> TeachingRoutine { get; set; }
        public DbSet<TemplateNode> TemplateNode { get; set; }
        public DbSet<TemplateRoutine> TemplateRoutine { get; set; }
        public DbSet<TransferCheck> TransferCheck { get; set; }
        public DbSet<RoutineGroup> RoutineGroup { get; set; }
        public DbSet<BankAcceptBill> BankAcceptBill { get; set; }
        public DbSet<BankDraft> BankDraft { get; set; }
        public DbSet<CollectAccept> CollectAccept { get; set; }
        public DbSet<EntrustBankPayment> EntrustBankPayment { get; set; }
        public DbSet<EntrustCorpPayment> EntrustCorpPayment { get; set; }
        public DbSet<MoneyRemittance> MoneyRemittance { get; set; }
        public DbSet<UserErrorHint> UserErrorHint { get; set; }
        public DbSet<CashJournal> CashJournal { get; set; }
        public DbSet<OuterSubject> OuterSubject { get; set; }
        public DbSet<IndividualSaving> IndividualSaving { get; set; }
        public DbSet<ActivationCode> ActivationCode { get; set; }
        public DbSet<UnitSaving> UnitSaving { get; set; }
        public DbSet<Discounting> Discounting { get; set; }
        public DbSet<Loan> Loan { get; set; }
    }
}
