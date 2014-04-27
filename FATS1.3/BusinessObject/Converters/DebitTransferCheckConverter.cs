using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.Areas.Teachings.Models;
using AutoMapper;

namespace FATS.BusinessObject.Converters
{
    public class DebitTransferCheckConverter
    {
        public static V_TransferCheck S1_ToView_TransferCheck(TransferCheck dbCheck)
        {
            Mapper.CreateMap<TransferCheck, V_TransferCheck>();
            V_TransferCheck vCheck = Mapper.Map<TransferCheck, V_TransferCheck>(dbCheck);
            return vCheck;
        }

        public static V_IncomeBill S1_ToView_IncomeBill(TransferCheck dbCheck)
        {
            Mapper.CreateMap<TransferCheck, V_IncomeBill>();
            V_IncomeBill vBill = Mapper.Map<TransferCheck, V_IncomeBill>(dbCheck);
            return vBill;
        }
    }
}