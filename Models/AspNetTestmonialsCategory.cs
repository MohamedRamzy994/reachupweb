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
    
    public partial class AspNetTestmonialsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetTestmonialsCategory()
        {
            this.AspNetTestmonials = new HashSet<AspNetTestmonial>();
        }
    
        public string TsCat_Id { get; set; }
        public string TsCat_Name_Ar { get; set; }
        public string TsCat_Name_En { get; set; }
        public System.DateTime TsCat_DateTime { get; set; }
        public string TsCat_Description_En { get; set; }
        public string TsCat_Description_Ar { get; set; }
        public string Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetTestmonial> AspNetTestmonials { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
