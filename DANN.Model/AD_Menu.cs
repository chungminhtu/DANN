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
    
    public partial class AD_Menu
    {
        public AD_Menu()
        {
            this.AD_User_Menu = new HashSet<AD_User_Menu>();
        }
    
        public int Menu_Id { get; set; }
        public Nullable<int> Menu_ParentId { get; set; }
        public string MenuText { get; set; }
        public string MenuAction { get; set; }
        public string MenuIcon { get; set; }
        public Nullable<int> MenuSort { get; set; }
        public Nullable<bool> MenuSeparator { get; set; }
        public Nullable<int> PhanHe_Id { get; set; }
        public Nullable<bool> KhongDuocXoa { get; set; }
    
        public virtual ICollection<AD_User_Menu> AD_User_Menu { get; set; }
    }
}
