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
    
    public partial class AspNetNew
    {
        public string News_Id { get; set; }
        public string News_Title_Ar { get; set; }
        public string News_Title_En { get; set; }
        public string News_Short_Ar { get; set; }
        public string News_Short_En { get; set; }
        public string News_Long_Ar { get; set; }
        public string News_Long_En { get; set; }
        public System.DateTime News_DateTime { get; set; }
        public string News_Photo { get; set; }
        public string NCat_Id { get; set; }
        public string Id { get; set; }
    
        public virtual AspNetNewsCategory AspNetNewsCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
