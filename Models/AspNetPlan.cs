//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppletSoftware.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetPlan
    {
        public string Plan_Id { get; set; }
        public string Plan_Name_Ar { get; set; }
        public string Plan_Name_En { get; set; }
        public decimal Plan_Price { get; set; }
        public System.DateTime Plan_DateTime { get; set; }
        public string Plan_Description_Ar { get; set; }
        public string Plan_Description_En { get; set; }
        public string PlanCat_Id { get; set; }
        public string Id { get; set; }
    
        public virtual AspNetPlansCategory AspNetPlansCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
