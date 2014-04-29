using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace FATS.Models
{
    public partial class TeachingNode
    {
        [NotMapped]
        public TemplateNode RelTmpNode { get; set; }
        [NotMapped]
        public string NodeType
        {
            get
            {
                return RelTmpNode.NodeType;
            }
        }
        [NotMapped]
        public string NodeName
        {
            get
            {
                return RelTmpNode.NodeName;
            }
        }
        [NotMapped]
        public string NodeTag
        {
            get
            {
                return RelTmpNode.Tag;
            }
        }
        [NotMapped]
        public int Index
        {
            get
            {
                return RelTmpNode.NodeIndex;
            }
        }

        [NotMapped]
        public int GroupIdx
        {
            get
            {
                return RelTmpNode.GroupIdx;
            }
        }
    }
}