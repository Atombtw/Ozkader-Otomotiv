//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Özkader_Otomotiv.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Kategori()
        {
            this.Tbl_Urun = new HashSet<Tbl_Urun>();
        }
    
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public string KategoriFoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Urun> Tbl_Urun { get; set; }
    }
}
