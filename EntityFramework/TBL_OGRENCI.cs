//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_OGRENCI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_OGRENCI()
        {
            this.TBL_NOT = new HashSet<TBL_NOT>();
        }
    
        public int OGRENCI_ID { get; set; }
        public string OGRENCI_AD { get; set; }
        public string OGRENCI_SOYAD { get; set; }
        public string OGRENCI_FOTOGRAF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_NOT> TBL_NOT { get; set; }
    }
}
