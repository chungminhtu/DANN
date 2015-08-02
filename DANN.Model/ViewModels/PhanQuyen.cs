using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{
    public class Quyen
    {
        public string User_Id { get; set; }
        public int Menu_Id { get; set; }
        public Nullable<int> Menu_ParentId { get; set; }

        [DisplayName("Tên màn hình")]
        public string MenuText { get; set; }

        [DisplayName("Toàn bộ")]
        public bool? TatCaQuyen { get; set; }
        [DisplayName("Xem")]
        public bool? QuyenXem { get; set; }
        [DisplayName("Thêm")]
        public bool? QuyenThem { get; set; }
        [DisplayName("Sửa")]
        public bool? QuyenSua { get; set; }
        [DisplayName("Xóa")]
        public bool? QuyenXoa { get; set; }
        [DisplayName("Lưu")]
        public bool? QuyenLuu { get; set; }
        [DisplayName("In")]
        public bool? QuyenIn { get; set; }

        public int? MenuSort { get; set; }
    }
}
