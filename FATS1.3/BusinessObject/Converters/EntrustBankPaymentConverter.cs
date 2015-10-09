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
        public static V_CollectVoucher N2_CollectVoucher(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_CollectVoucher>();
            return Mapper.Map<EntrustBankPayment, V_CollectVoucher>(orgObj);
        }

        public static V_EntrustPayment_OuterSubject N3_OuterSubject(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_EntrustPayment_OuterSubject>();
            V_EntrustPayment_OuterSubject dstObj = Mapper.Map<EntrustBankPayment, V_EntrustPayment_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "待收款";
            dstObj.TimeMark = orgObj.EntrustDate;
            dstObj.FinalAmount = dstObj.MoneyAmount;
            return dstObj;
        }

        public static V_EntrustPayment_OuterSubject N12_OuterSubject(EntrustBankPayment orgObj)
        {
            Mapper.CreateMap<EntrustBankPayment, V_EntrustPayment_OuterSubject>();
            V_EntrustPayment_OuterSubject dstObj = Mapper.Map<EntrustBankPayment, V_EntrustPayment_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "已划款";
            dstObj.TimeMark = orgObj.PaymentDate;
            dstObj.FinalAmount = 0;
            return dstObj;
        }

    }
}