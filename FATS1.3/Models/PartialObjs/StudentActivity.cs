using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace FATS.Models
{
    public partial class StudentActivity
    {
        [NotMapped]
        public string CaseName { get; set; }
        [NotMapped]
        public string NodeType { get; set; }
        [NotMapped]
        public string NodeTag { get; set; }
        [NotMapped]
        public string TmpRoutineName { get; set; }
        [NotMapped]
        public string TmpNodeName { get; set; } 
    }
}