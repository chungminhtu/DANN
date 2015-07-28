using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(AD_UserMetadata))]
    public partial class AD_User : BaseEntity
    {
        public class AD_UserMetadata
        {
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Tên đăng nhập")]
            public string User_Id { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Mật khẩu")]
            public string Password { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Tên người dùng")]
            public string UserName { get; set; }
            [DisplayName("Địa chỉ Email")]
            public string Email { get; set; }
            [DisplayName("Địa chỉ hiện tại")]
            public string DiaChi { get; set; }
            [DisplayName("Số điện thoại")]
            public string SoDienThoai { get; set; }
            [DisplayName("Chức vụ")]
            public string ChucVu { get; set; }
            [DisplayName("Thuộc Phòng ban")]
            public string PhongBan { get; set; }
        }
    }
}
