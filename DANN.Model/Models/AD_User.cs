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
            [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(30, ErrorMessage = CommonMessages.StringLenght)]
            public string User_Id { get; set; }

            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(20, ErrorMessage = CommonMessages.StringLenght)]
            public string Password { get; set; }

            [DisplayName("Tên người dùng")]
            [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(50, ErrorMessage = CommonMessages.StringLenght)]
            public string UserName { get; set; }

            [DisplayName("Địa chỉ Email")]
            [Required(ErrorMessage = CommonMessages.Required)]
            [RegularExpression(CommonConstants.EMAIL,
            ErrorMessage = CommonMessages.RegularExpression)]
            public string Email { get; set; }

            [DisplayName("Địa chỉ hiện tại")]
            [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(250, ErrorMessage = CommonMessages.StringLenght)]
            public string DiaChi { get; set; }

            [DisplayName("Số điện thoại")]
            [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(50, ErrorMessage = CommonMessages.StringLenght)]
            public string SoDienThoai { get; set; }

            [DisplayName("Chức vụ")]
           // [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(100, ErrorMessage = CommonMessages.StringLenght)]
            public string ChucVu { get; set; }

            [DisplayName("Đơn vị")]
          //  [Required(ErrorMessage = CommonMessages.Required)]
            [StringLength(100, ErrorMessage = CommonMessages.StringLenght)]
            public string PhanHe { get; set; }
        }
    }
}
