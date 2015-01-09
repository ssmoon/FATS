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
        public static V_OuterSubject N8_OuterSubject(BankAcceptBill orgObj)
        {
            V_OuterSubject dstObj = new V_OuterSubject();
            dstObj.Abstract = "";
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.MoneyAmount = orgObj.MoneyAmount;
            dstObj.OuterSubject = orgObj.OuterSubject;
            dstObj.CustomerAccNo = orgObj.PayeeAcc;
            dstObj.TimeMark = orgObj.IncomeBillDate;
            return dstObj;
        }

        public static V_OuterSubject N12_OuterSubject(BankAcceptBill orgObj)
        {
            V_OuterSubject dstObj = new V_OuterSubject();
            dstObj.Abstract = "";
            dstObj.BillTitle = "表外科目支出凭证";
            dstObj.MoneyAmount = orgObj.MoneyAmount;
            dstObj.OuterSubject = orgObj.OuterSubject;
            dstObj.CustomerAccNo = orgObj.RemitterAcc;
            dstObj.TimeMark = orgObj.DrawBillDate;
            return dstObj;
        }

       
        public static V_CollectVoucher N2_CollectVoucher(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectVoucher>();
            return Mapper.Map<CollectAccept, V_CollectVoucher>(orgObj);
        }

    }
}