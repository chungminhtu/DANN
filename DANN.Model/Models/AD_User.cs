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
            [Required(ErrorMessage = "Bạn chưa nhập Tên đăng nhập")]
            [StringLength(30,ErrorMessage="Tên đăng nhập không được vượt quá 30 ký tự!")]
            public string User_Id { get; set; }
           
            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = "Bạn chưa nhập Mật khẩu")]
            [StringLength(20,ErrorMessage="Mật khẩu không được vượt quá 20 ký tự!")]
            public string Password { get; set; }
           
            [DisplayName("Tên người dùng")]
            [Required(ErrorMessage = "Bạn chưa nhập Tên người dùng")]
            [StringLength(50,ErrorMessage="Tên người dùng không được nhập quá 50 ký tự!")]
            public string UserName { get; set; }

            [DisplayName("Địa chỉ Email")]
            [Required(ErrorMessage="Bạn chưa nhập Địa chỉ Email!")]
            public string Email { get; set; }

            [DisplayName("Địa chỉ hiện tại")]
            [Required(ErrorMessage="Bạn chưa nhập Địa chỉ hiện tại!")]
            [StringLength(250,ErrorMessage="Địa chỉ hiện tại không được nhập quá 250 ký tự!")]
            public string DiaChi { get; set; }

            [DisplayName("Số điện thoại")]
            [Required(ErrorMessage="Bạn chưa nhập Số điện thoại!")]
           // [Range(0,50,ErrorMessage="Bạn chỉ được nhập số!")]
            public string SoDienThoai { get; set; }

            [DisplayName("Chức vụ")]
            //[Required("Bạn chưa nhập Chức vụ!")]
            [StringLength(100,ErrorMessage="Chức vụ không được nhập quá 100 ký tự! ")]
            public string ChucVu { get; set; }
         
            [DisplayName("Thuộc Phòng ban")]
           // [Required("Bạn chưa nhập Phòng ban!")]
            [StringLength(100,ErrorMessage="Phòng ban không được nhập quá 100 ký tự")]
            public string PhongBan { get; set; }
        }
    }
}
