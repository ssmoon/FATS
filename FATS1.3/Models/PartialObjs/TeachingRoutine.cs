using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace FATS.Models
{
    public partial class TeachingRoutine
    {
        [NotMapped]
        public TemplateRoutine RelTmpRoutine { get; set; }
        [NotMapped]
        public string TmpRoutineName
        {
            get
            {
                if (RelTmpRoutine == null)
                    return string.Empty;
                else return RelTmpRoutine.RoutineName;
            }
        }
        [NotMapped]
        public SortedList<int, TeachingNode> NodeList { get; set; }

        [NotMapped]
        public SortedList<int, RoutineGroup> GroupList { get; set; }

        public TeachingNode FindNode(int tchNodeID)
        {
            return NodeList.Values.FirstOrDefault(n => n.Row_ID == tchNodeID);
        }
    }
}