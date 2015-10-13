using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class BankDraftConverter
    {
        public static V_BusinessProxy N2_BusinessProxy(BankDraft orgObj)
        {
            Mapper.CreateMap<BankDraft, V_BusinessProxy>();
            V_BusinessProxy dstObj = Mapper.Map<BankDraft, V_BusinessProxy>(orgObj);
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_BankDraft N7_BankDraft(BankDraft orgObj)
        {
            Mapper.CreateMap<BankDraft, V_BankDraft>();
            return Mapper.Map<BankDraft, V_BankDraft>(orgObj);
        }

        public static V_IncomeBill N12_IncomeBill(BankDraft orgObj)
        {
            Mapper.CreateMap<BankDraft, V_IncomeBill>();
            return Mapper.Map<BankDraft, V_IncomeBill>(orgObj);
        }
    }
}