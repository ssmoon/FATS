using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class IndividualDepositConverter
    {
        public static V_IndividualDeposit DWHQ_Deposit(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualDeposit>();
            V_IndividualDeposit targetObj = Mapper.Map<IndividualSaving, V_IndividualDeposit>(orgObj);
            targetObj.DepositType = "活期";
            return targetObj;
        }

        public static V_IndividualDeposit DWZZ_Deposit(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualDeposit>();
            V_IndividualDeposit targetObj = Mapper.Map<IndividualSaving, V_IndividualDeposit>(orgObj);
            targetObj.DepositType = "整整";
            return targetObj;
        }

        public static V_IndividualDeposit DWLZ_Deposit(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualDeposit>();
            V_IndividualDeposit targetObj = Mapper.Map<IndividualSaving, V_IndividualDeposit>(orgObj);
            targetObj.DepositType = "零整";
            return targetObj;
        }

        public static V_IndividualDeposit DWZL_Deposit(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualDeposit>();
            V_IndividualDeposit targetObj = Mapper.Map<IndividualSaving, V_IndividualDeposit>(orgObj);
            targetObj.DepositType = "整零";
            return targetObj;
        }

        public static V_IndividualDeposit DWTI_Deposit(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualDeposit>();
            V_IndividualDeposit targetObj = Mapper.Map<IndividualSaving, V_IndividualDeposit>(orgObj);
            targetObj.DepositType = "本息";
            return targetObj;
        }
    }

    public class IndividualWithdrawConverter
    {
        public static V_IndividualWithdraw DWHQ_Withdraw(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualWithdraw>();
            V_IndividualWithdraw targetObj = Mapper.Map<IndividualSaving, V_IndividualWithdraw>(orgObj);
            targetObj.WithdrawType = "活期";
            return targetObj;
        }

        public static V_IndividualWithdraw DWHQ_Clear(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualWithdraw>();
            V_IndividualWithdraw targetObj = Mapper.Map<IndividualSaving, V_IndividualWithdraw>(orgObj);
            targetObj.WithdrawType = "活期";
            return targetObj;
        }

        public static V_IndividualWithdraw DWZZ_Withdraw(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualWithdraw>();
            V_IndividualWithdraw targetObj = Mapper.Map<IndividualSaving, V_IndividualWithdraw>(orgObj);
            targetObj.WithdrawType = "整整";
            return targetObj;
        }

        public static V_IndividualWithdraw DWLZ_Withdraw(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualWithdraw>();
            V_IndividualWithdraw targetObj = Mapper.Map<IndividualSaving, V_IndividualWithdraw>(orgObj);
            targetObj.WithdrawType = "零整";
            return targetObj;
        }

        public static V_IndividualWithdraw DWZL_Withdraw(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualWithdraw>();
            V_IndividualWithdraw targetObj = Mapper.Map<IndividualSaving, V_IndividualWithdraw>(orgObj);
            targetObj.WithdrawType = "整零";
            return targetObj;
        }

        public static V_IndividualWithdraw DWTI_Withdraw(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_IndividualWithdraw>();
            V_IndividualWithdraw targetObj = Mapper.Map<IndividualSaving, V_IndividualWithdraw>(orgObj);
            targetObj.WithdrawType = "本息";
            return targetObj;
        }
    }

    public class InterestVoucherConverter
    {
        public static V_InterestVoucher DWHQ_Interest(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_InterestVoucher>();
            V_InterestVoucher targetObj = Mapper.Map<IndividualSaving, V_InterestVoucher>(orgObj);
            targetObj.Abstract = "结息";
            return targetObj;
        }

        public static V_InterestVoucher DWTI_Interest(IndividualSaving orgObj)
        {
            Mapper.CreateMap<IndividualSaving, V_InterestVoucher>();
            V_InterestVoucher targetObj = Mapper.Map<IndividualSaving, V_InterestVoucher>(orgObj);
            targetObj.Abstract = "结息";
            return targetObj;
        }
    }
}