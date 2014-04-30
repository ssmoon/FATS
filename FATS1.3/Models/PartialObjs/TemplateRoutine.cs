using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace FATS.Models
{
    public partial class TemplateRoutine
    {
        public TemplateRoutine()
        {
            NodeDict = new Dictionary<string, TemplateNode>(10);
        }

        [NotMapped]
        public Dictionary<string, TemplateNode> NodeDict { get; set; }
    }
}