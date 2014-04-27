using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace FATS.DataDefine
{
    public class ClientGridDataWrapper
    {
        public int sEcho { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public int iTotalRecords { get; set; }
        public dynamic aaData { get; set; }
    }
}