using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.DataDefine
{
    public class ConstDefine
    {
        public const int RoutineType_Teaching1 = 1;
        public const int RoutineType_Teaching2 = 2;

        public const int UserStatus_Invalid = -1;
        public const int UserStatus_Valid = 11;

        public const int ActivationCode_Status_Unused = 0;
        public const int ActivationCode_Status_Used = 11;


        public const string SessionKey_FinishedRoutineID = "FinishedRoutineID";
        public const string ViewData_CaseText = "CaseDesc";
    }
    
}