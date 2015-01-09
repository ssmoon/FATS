using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class CollectAcceptConverter
    {
        public static V_OuterSubject N3_OuterSubject(CollectAccept orgObj)
        {
            V_OuterSubject dstObj = new V_OuterSubject();
            dstObj.Abstract = "";
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.MoneyAmount = orgObj.MoneyAmount;
            dstObj.OuterSubject = orgObj.OuterSubject;
            dstObj.CustomerAccNo = orgObj.PayeeAcc;
            dstObj.TimeMark = orgObj.CollectDate;
            return dstObj;
        }

        public static V_OuterSubject N6_OuterSubject(CollectAccept orgObj)
        {
            V_OuterSubject dstObj = new V_OuterSubject();
            dstObj.Abstract = "";
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.MoneyAmount = orgObj.MoneyAmount;
            dstObj.OuterSubject = orgObj.OuterSubject;
            dstObj.CustomerAccNo = orgObj.RemitterAcc;
            dstObj.TimeMark = orgObj.CollectDate;
            return dstObj;
        }

        public static V_OuterSubject N11_OuterSubject(CollectAccept orgObj)
        {
            V_OuterSubject dstObj = new V_OuterSubject();
            dstObj.Abstract = "";
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.MoneyAmount = orgObj.MoneyAmount;
            dstObj.OuterSubject = orgObj.OuterSubject;
            dstObj.CustomerAccNo = orgObj.PayeeAcc;
            dstObj.TimeMark = orgObj.AcceptDate;
            return dstObj;
        }

        public static V_OuterSubject N17_OuterSubject(CollectAccept orgObj)
        {
            V_OuterSubject dstObj = new V_OuterSubject();
            dstObj.Abstract = "";
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.MoneyAmount = orgObj.MoneyAmount;
            dstObj.OuterSubject = orgObj.OuterSubject;
            dstObj.CustomerAccNo = orgObj.RemitterAcc;
            dstObj.TimeMark = orgObj.AcceptDate;
            return dstObj;
        }

        public static V_CollectVoucher N2_CollectVoucher(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectVoucher>();
            return Mapper.Map<CollectAccept, V_CollectVoucher>(orgObj);
        }

    }
}