using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class EntrustCorpPaymentConverter
    {
        public static V_CollectVoucher N4_CollectVoucher(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_CollectVoucher>();
            return Mapper.Map<EntrustCorpPayment, V_CollectVoucher>(orgObj);
        }

        public static V_ElectronicVoucher N9_ElectronicVoucher(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_ElectronicVoucher>();
            V_ElectronicVoucher dstObj = Mapper.Map<EntrustCorpPayment, V_ElectronicVoucher>(orgObj);
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N2_OuterSubject(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<EntrustCorpPayment, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "待收款";
            dstObj.TimeMark = orgObj.EntrustDate;
            dstObj.FinalAmount = dstObj.MoneyAmount;
            dstObj.CollectDate = orgObj.EntrustDate;
            dstObj.AcceptDate = orgObj.PaymentDate;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N12_OuterSubject(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<EntrustCorpPayment, V_CollectAccept_OuterSubject>(orgObj);
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