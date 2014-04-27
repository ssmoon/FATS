using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.DataDefine
{
    public class RoutineConstDefine
    {
        public const string Connector = "_";

        #region Node Type
        public const string NodeType_CommonNode = "CommonNode";
        public const string NodeType_DebitTransferCheck = "DebitTransferCheck";
        #endregion

        #region T1 Routine -  TransferCheck
        public const string T1_DebitTransferCheck = "T1_DebitTransferCheck";
        public const string T1_DebitTransferCheck_S1 = T1_DebitTransferCheck + Connector + "S1";
        public const string T1_DebitTransferCheck_S2 = T1_DebitTransferCheck + Connector + "S2";
        public const string T1_DebitTransferCheck_S3 = T1_DebitTransferCheck + Connector + "S3";    
        #endregion

        #region T2 Routine
        public const string T2_DebitTransferCheck = "T2_DebitTransferCheck";
        public const string T2_DebitTransferCheck_TransferCheck = "tc";
        public const string T2_DebitTransferCheck_IncomeBill = "ib";

        #endregion
    }

    
}