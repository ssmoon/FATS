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
        public static V_CollectVoucher N2_CollectVoucher(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectVoucher>();
            return Mapper.Map<CollectAccept, V_CollectVoucher>(orgObj);
        }

        public static V_CollectAccept_OuterSubject N3_OuterSubject(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<CollectAccept, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.OpResult = "待托收";
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N6_OuterSubject(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<CollectAccept, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.OpResult = "待承付";
            dstObj.BankName = orgObj.PayeeBank;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N11_OuterSubject(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<CollectAccept, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.OpResult = "已承付";
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_CollectAccept_OuterSubject N17_OuterSubject(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectAccept_OuterSubject>();
            V_CollectAccept_OuterSubject dstObj = Mapper.Map<CollectAccept, V_CollectAccept_OuterSubject>(orgObj);
            dstObj.BillTitle = "表外科目收入凭证";
            dstObj.OpResult = "已收款";
            dstObj.BankName = orgObj.PayeeBank;
            return dstObj;
        }

    }
}