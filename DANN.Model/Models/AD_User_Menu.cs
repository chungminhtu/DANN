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
            [DisplayName("Tên đăng nhập")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(30,ErrorMessage="\"{0}\"không được vượt quá 30 ký tự.")]
            public string User_Id { get; set; }

            [DisplayName("Quyền truy cập")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [Range(0,int.MaxValue,ErrorMessage="Bạn chỉ được nhập số.")]
            public int Menu_Id { get; set; }
        }
    }
}
