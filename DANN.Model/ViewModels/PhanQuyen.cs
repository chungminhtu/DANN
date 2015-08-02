using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{
    public class PhanQuyen
    {
       // public List<AD_User> ListUsers { get; set; }
        public List<AD_User_Menu> ListUserMenu { get; set; }
        public List<AD_Menu> ListMenus { get; set; }

        public List<Quyen> ListQuyen { get; set; }
    }


    public class Quyen
    {
        public string User_Id { get; set; }
        public int Menu_Id { get; set; }
        public Nullable<int> Menu_ParentId { get; set; }

        [DisplayName("Tên màn hình")]
        public string MenuText { get; set; }

        [DisplayName("Toàn bộ quyền")]
        public bool? TatCaQuyen { get; set; }
        [DisplayName("Quyền xem")]
        public bool? QuyenXem { get; set; }
        [DisplayName("Quyền thêm")]
        public bool? QuyenThem { get; set; }
        [DisplayName("Quyền sửa")]
        public bool? QuyenSua { get; set; }
        [DisplayName("Quyền xóa")]
        public bool? QuyenXoa { get; set; }
        [DisplayName("Quyền lưu")]
        public bool? QuyenLuu { get; set; }
        [DisplayName("Quyền In")]
        public bool? QuyenIn { get; set; }

        public int? MenuSort { get; set; }
    }
}
