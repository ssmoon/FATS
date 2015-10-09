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
        public static V_CollectVoucher N2_CollectVoucher(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_CollectVoucher>();
            return Mapper.Map<EntrustCorpPayment, V_CollectVoucher>(orgObj);
        }

        public static V_EntrustPayment_OuterSubject N3_OuterSubject(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_EntrustPayment_OuterSubject>();
            V_EntrustPayment_OuterSubject dstObj = Mapper.Map<EntrustCorpPayment, V_EntrustPayment_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "待收款";
            dstObj.TimeMark = orgObj.EntrustDate;
            dstObj.FinalAmount = dstObj.MoneyAmount;
            return dstObj;
        }

        public static V_EntrustPayment_OuterSubject N13_OuterSubject(EntrustCorpPayment orgObj)
        {
            Mapper.CreateMap<EntrustCorpPayment, V_EntrustPayment_OuterSubject>();
            V_EntrustPayment_OuterSubject dstObj = Mapper.Map<EntrustCorpPayment, V_EntrustPayment_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目登记簿";
            dstObj.OpResult = "已划款";
            dstObj.TimeMark = orgObj.PaymentDate;
            dstObj.FinalAmount = 0;
            return dstObj;
        }

    }
}