//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DANN.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_DonViTinh
    {
        public DM_DonViTinh()
        {
            this.TK_ChiTieu = new HashSet<TK_ChiTieu>();
        }
    
        public int DonViTinh_Id { get; set; }
        public string TenDonViTinh { get; set; }
        public string LoaiDonViTinh { get; set; }
        public string ValueFormat { get; set; }
    
        public virtual ICollection<TK_ChiTieu> TK_ChiTieu { get; set; }
    }
}
