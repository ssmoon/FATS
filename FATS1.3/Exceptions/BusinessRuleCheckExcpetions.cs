using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.Exceptions
{
    public class BusinessRuleCheckExcpetions: Exception
    {
        public BusinessRuleCheckExcpetions(string message): base(message)
        {
            
        }
    }
}