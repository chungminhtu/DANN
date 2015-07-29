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
            [DisplayName("Tên đăng nhập")]
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [StringLength(30,ErrorMessage="\"{0}\" không được vượt quá 30 ký tự.")]
            public string User_Id { get; set; }
           
            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [StringLength(20,ErrorMessage="\"{0}\" không được vượt quá 20 ký tự.")]
            public string Password { get; set; }
           
            [DisplayName("Tên người dùng")]
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [StringLength(50,ErrorMessage="\"{0}\" không được nhập quá 50 ký tự.")]
            public string UserName { get; set; }

            [DisplayName("Địa chỉ Email")]
            [Required(ErrorMessage="Bạn chưa nhập \"{0}\"")]
            public string Email { get; set; }

            [DisplayName("Địa chỉ hiện tại")]
            [Required(ErrorMessage="Bạn chưa nhập \"{0}\"")]
            [StringLength(250,ErrorMessage="\"{0}\" không được nhập quá 250 ký tự.")]
            public string DiaChi { get; set; }

            [DisplayName("Số điện thoại")]
            [Required(ErrorMessage="Bạn chưa nhập \"{0}\"")]
            [Range(0,50,ErrorMessage="Bạn chỉ được nhập số")]
            public string SoDienThoai { get; set; }

            [DisplayName("Chức vụ")]
           // [Required("Bạn chưa nhập Chức vụ!")]
            [StringLength(100,ErrorMessage="Chức vụ không được nhập quá 100 ký tự. ")]
            public string ChucVu { get; set; }
         
            [DisplayName("Thuộc Phòng ban")]
           // [Required("Bạn chưa nhập Phòng ban!")]
            [StringLength(100,ErrorMessage="Phòng ban không được nhập quá 100 ký tự.")]
            public string PhongBan { get; set; }
        }
    }
}
