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
      

       
        public static V_CollectVoucher N2_CollectVoucher(CollectAccept orgObj)
        {
            Mapper.CreateMap<CollectAccept, V_CollectVoucher>();
            return Mapper.Map<CollectAccept, V_CollectVoucher>(orgObj);
        }

    }
}