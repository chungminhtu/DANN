using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(TK_ThongKeMetadata))]
    public partial class TK_ThongKe : BaseEntity
    {
        public class TK_ThongKeMetadata
        {
           [DisplayName("Mã Chỉ tiêu")]
            public int ChiTieu_Id { get; set; }
            [DisplayName("Mã Đối tượng")]
            public int DoiTuong_Id { get; set; }
            [DisplayName("Mã Kỳ báo cáo")]
            public int KyBaoCao_Id { get; set; }
            [DisplayName("Mã Nhóm")]
            public int Nhom_Id { get; set; }
            [DisplayName("Mã Địa phương")]
            public int DiaPhuong_Id { get; set; }

            [DisplayName("Giá trị Thống kê")]
            [Required(ErrorMessage="Bạn chưa nhập Giá trị Thống kê!")]
            [StringLength(50,ErrorMessage="Giá trị Thống kê không được vượt quá 50 ký tự!")]
            public string GiaTriThongKe { get; set; }

            public virtual DM_KyBaoCao DM_KyBaoCao { get; set; }
            public virtual DM_PhanHe DM_PhanHe { get; set; }
            public virtual TK_ChiTieu TK_ChiTieu { get; set; }
            public virtual TK_DoiTuong TK_DoiTuong { get; set; }
        }
    }
}
