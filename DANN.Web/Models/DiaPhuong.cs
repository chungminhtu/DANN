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
    
    public partial class DiaPhuong
    {
        public DiaPhuong()
        {
            this.ThongKes = new HashSet<ThongKe>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> AdminID { get; set; }
        public Nullable<int> MAPID { get; set; }
        public string NAME { get; set; }
        public string IDBanDo { get; set; }
        public string UniqueName { get; set; }
        public string TYPE { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string TelCode { get; set; }
    
        public virtual ICollection<ThongKe> ThongKes { get; set; }
    }
}
