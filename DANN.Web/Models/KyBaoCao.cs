//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DANN.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KyBaoCao
    {
        public KyBaoCao()
        {
            this.ThongKes = new HashSet<ThongKe>();
        }
    
        public string TenKyBaoCao { get; set; }
    
        public virtual ICollection<ThongKe> ThongKes { get; set; }
    }
}
