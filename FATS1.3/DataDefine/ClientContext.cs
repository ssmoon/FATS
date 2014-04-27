using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.DataDefine
{
    public class ClientContext
    {
        public int TchRoutineID { get; set; }        
        public int NextTchNodeID { get; set; }
        public int PrevTchNodeID { get; set; }
        public string NextTchNodeType { get; set; }
        public string NextTchNodeTag { get; set; }
        public string PrevTchNodeType { get; set; }
        public string PrevTchNodeTag { get; set; }
        public int IsFinished { get; set; }

        public int IsTeacher { get; set; }

    }
}