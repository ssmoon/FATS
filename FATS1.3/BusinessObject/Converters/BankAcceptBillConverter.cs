using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class BankAcceptBillConverter
    {
        public static V_TradeAcceptance N2_TradeAcceptance(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_TradeAcceptance>();
            return Mapper.Map<BankAcceptBill, V_TradeAcceptance>(orgObj);
        }

        public static V_CollectVoucher N9_CollectVoucher(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_CollectVoucher>();
            V_CollectVoucher dstObj = Mapper.Map<BankAcceptBill, V_CollectVoucher>(orgObj);
            dstObj.CollectDate = orgObj.IncomeBillDate;
            dstObj.AcceptDate = orgObj.DrawBillDate;
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_SpecialTransferVoucher N12_SpecialTransferVoucher(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_SpecialTransferVoucher>();
            V_SpecialTransferVoucher dstObj = Mapper.Map<BankAcceptBill, V_SpecialTransferVoucher>(orgObj);
            dstObj.TimeMark = orgObj.DrawBillDate;
            dstObj.OrgVoucherName = "银行承兑汇票";
            dstObj.OrgVoucherNo = orgObj.BillNo;
            dstObj.OrgVoucherAmount = orgObj.MoneyAmount;
            dstObj.TransferReason = "收取承兑汇票票款";
            dstObj.TransferOrient = "借方";
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_SpecialTransferVoucher N17_SpecialTransferVoucher(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_SpecialTransferVoucher>();
            V_SpecialTransferVoucher dstObj = Mapper.Map<BankAcceptBill, V_SpecialTransferVoucher>(orgObj);
            dstObj.TimeMark = orgObj.DrawBillDate;
            dstObj.OrgVoucherName = "银行承兑汇票";
            dstObj.OrgVoucherNo = orgObj.BillNo;
            dstObj.OrgVoucherAmount = orgObj.MoneyAmount;
            dstObj.TransferReason = "扣收承兑汇票票款";
            dstObj.TransferOrient = "贷方";
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_ElectronicVoucher N23_ElectronicVoucher(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_ElectronicVoucher>();
            V_ElectronicVoucher dstObj = Mapper.Map<BankAcceptBill, V_ElectronicVoucher>(orgObj);
            dstObj.TimeMark = orgObj.DrawBillDate;            
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }


        public static V_BankAcceptBill_OuterSubject N6_BankAcceptBill_OuterSubject(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_BankAcceptBill_OuterSubject>();
            V_BankAcceptBill_OuterSubject dstObj = Mapper.Map<BankAcceptBill, V_BankAcceptBill_OuterSubject>(orgObj);
            dstObj.CurrStatus = 0;
            dstObj.OpResult = "接受申请";
            dstObj.BankName = orgObj.PayeeBank;
            dstObj.TimeMark = orgObj.IncomeBillDate;
            return dstObj;
        }

        public static V_BankAcceptBill_OuterSubject N20_BankAcceptBill_OuterSubject(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_BankAcceptBill_OuterSubject>();
            V_BankAcceptBill_OuterSubject dstObj = Mapper.Map<BankAcceptBill, V_BankAcceptBill_OuterSubject>(orgObj);
            dstObj.CurrStatus = 1;
            dstObj.OpResult = "已划款";
            dstObj.BankName = orgObj.PayeeBank;
            dstObj.TimeMark = orgObj.DrawBillDate;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N10_CollectAccept_OuterSubject(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<BankAcceptBill, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "托收承付登记簿";
            dstObj.OpResult = "待承付";
            dstObj.BankName = orgObj.RemitterBank;
            dstObj.CollectDate = orgObj.IncomeBillDate;
            dstObj.AcceptDate = orgObj.DrawBillDate;
            dstObj.TimeMark = orgObj.IncomeBillDate;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N26_CollectAccept_OuterSubject(BankAcceptBill orgObj)
        {
            Mapper.CreateMap<BankAcceptBill, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<BankAcceptBill, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "托收承付登记簿";
            dstObj.OpResult = "已承付";
            dstObj.BankName = orgObj.RemitterBank;
            dstObj.TimeMark = orgObj.DrawBillDate;
            dstObj.CollectDate = orgObj.IncomeBillDate;
            dstObj.AcceptDate = orgObj.DrawBillDate;
            return dstObj;
        }


    }
}