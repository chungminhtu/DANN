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
    
    public partial class DM_PhanHe
    {
        public DM_PhanHe()
        {
            this.TK_ThongKe = new HashSet<TK_ThongKe>();
        }
    
        public int PhanHe_Id { get; set; }
        public string TenPhanHe { get; set; }
        public Nullable<bool> KhongDuocXoa { get; set; }
    
        public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
    }
}
