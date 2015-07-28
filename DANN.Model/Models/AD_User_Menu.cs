using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(AD_User_MenuMetadata))]
    public partial class AD_User_Menu : BaseEntity
    {
        public class AD_User_MenuMetadata
        {
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Tên đăng nhập")]
            public string User_Id { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Quyền truy cập")]
            public int Menu_Id { get; set; }
        }
    }
}
