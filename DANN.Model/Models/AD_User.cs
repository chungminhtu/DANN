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
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(30, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string User_Id { get; set; }

            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(20, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string Password { get; set; }

            [DisplayName("Tên người dùng")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(50, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string UserName { get; set; }

            [DisplayName("Địa chỉ Email")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = DANN.Service.CommonMessages.RegularExpression)]
            public string Email { get; set; }

            [DisplayName("Địa chỉ hiện tại")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(250, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string DiaChi { get; set; }

            [DisplayName("Số điện thoại")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(50, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string SoDienThoai { get; set; }

            [DisplayName("Chức vụ")]
            // [Required("Bạn chưa nhập Chức vụ!")]
            [StringLength(100, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string ChucVu { get; set; }

            [DisplayName("Đơn vị")]
            // [Required("Bạn chưa nhập Phòng ban!")]
            [StringLength(100, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string PhongBan { get; set; }
        }
    }
}
