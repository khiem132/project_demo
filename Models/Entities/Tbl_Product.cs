//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP_5_Upload.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Product()
        {
            this.Tbl_Product_Image = new HashSet<Tbl_Product_Image>();
        }
    
        public int C_id { get; set; }
        public string C_name { get; set; }
        public decimal C_price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Product_Image> Tbl_Product_Image { get; set; }
        public virtual Tbl_Product_Image Tbl_Product_Image1 { get; set; }
    }
}
