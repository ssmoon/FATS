//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FATS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FATUser
    {
        public int Row_ID { get; set; }
        public string UserName { get; set; }
        public short IsStudent { get; set; }
        public short IsTeacher { get; set; }
        public short IsAdmin { get; set; }
        public short CurrStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Password { get; set; }
        public string UserCode { get; set; }
        public string School { get; set; }
    }
}
