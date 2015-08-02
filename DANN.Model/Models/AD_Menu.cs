using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(AD_MenuMetadata))]
    public partial class AD_Menu : BaseEntity
    {
        public class AD_MenuMetadata
        {
            public int Menu_Id { get; set; }
            public Nullable<int> Menu_ParentId { get; set; }

            [DisplayName("Tên Menu")]
            [Required(ErrorMessage = "Bạn chưa nhập\" {0}\"")]
            [StringLength(250, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string MenuText { get; set; }

            [DisplayName("Tên URL")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(100, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string MenuAction { get; set; }

            [DisplayName("Biểu tượng Menu")]
            //[Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            //[StringLength(50, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string MenuIcon { get; set; }

            [DisplayName("Sắp xếp Menu")]
            public Nullable<int> MenuSort { get; set; }

            [DisplayName("Ngăn cách menu")]
            public Nullable<bool> MenuSeparator { get; set; }
        }
    }
}
