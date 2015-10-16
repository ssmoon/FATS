using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class EntrustBankPaymentConverter
    {
        public static V_CollectVoucher N4_CollectVoucher(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_CollectVoucher>();
            return Mapper.Map<EntrustBankPayment, V_CollectVoucher>(orgObj);
        }

        public static V_ElectronicVoucher N8_ElectronicVoucher(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_ElectronicVoucher>();
            V_ElectronicVoucher dstObj = Mapper.Map<EntrustBankPayment, V_ElectronicVoucher>(orgObj);
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N2_OuterSubject(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<EntrustBankPayment, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "待收款";
            dstObj.TimeMark = orgObj.EntrustDate;
            dstObj.FinalAmount = dstObj.MoneyAmount;
            dstObj.CollectDate = orgObj.EntrustDate;
            dstObj.AcceptDate = orgObj.PaymentDate;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N11_OuterSubject(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<EntrustBankPayment, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "已划款";
            dstObj.TimeMark = orgObj.PaymentDate;
            dstObj.FinalAmount = 0;
            dstObj.CollectDate = orgObj.EntrustDate;
            dstObj.AcceptDate = orgObj.PaymentDate;
            return dstObj;
        }

    }
}