using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class MoneyRemittanceConverter
    {
        public static V_BusinessProxy N2_BusinessProxy(MoneyRemittance orgObj)
        {
            Mapper.CreateMap<MoneyRemittance, V_BusinessProxy>();
            V_BusinessProxy dstObj = Mapper.Map<MoneyRemittance, V_BusinessProxy>(orgObj);
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }

        public static V_ElectronicVoucher N7_ElectronicVoucher(MoneyRemittance orgObj)
        {
            Mapper.CreateMap<MoneyRemittance, V_ElectronicVoucher>();
            V_ElectronicVoucher dstObj = Mapper.Map<MoneyRemittance, V_ElectronicVoucher>(orgObj);
            dstObj.BankName = orgObj.RemitterBank;
            return dstObj;
        }
    }
}