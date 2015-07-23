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
    
    public partial class DanhMucChiTieu
    {
        public DanhMucChiTieu()
        {
            this.NghiepVuChiTieux = new HashSet<NghiepVuChiTieu>();
            this.ThongKes = new HashSet<ThongKe>();
        }
    
        public System.Guid MaChiTieu { get; set; }
        public System.Guid MaNhomChiTieu { get; set; }
        public Nullable<System.Guid> MaChiTieuCha { get; set; }
        public string KyHieu { get; set; }
        public string TenChiTieu { get; set; }
        public Nullable<int> MaDonViTinh { get; set; }
        public Nullable<bool> DaGui { get; set; }
        public Nullable<byte> MucGioiHan { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        public bool KhongSuDung { get; set; }
    
        public virtual DonViTinh DonViTinh { get; set; }
        public virtual DanhMucNhomChiTieu DanhMucNhomChiTieu { get; set; }
        public virtual ICollection<NghiepVuChiTieu> NghiepVuChiTieux { get; set; }
        public virtual ICollection<ThongKe> ThongKes { get; set; }
    }
}
