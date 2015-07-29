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
            [Required(ErrorMessage = "Bạn chưa nhập Tên Menu!")]
            [StringLength(250,ErrorMessage="Tên Menu không được nhập quá 250 ký tự!")]
            public string MenuText { get; set; }
           
            [DisplayName("Tên URL")]
            [Required(ErrorMessage="Bạn chưa nhập Tên URL!")]
            [StringLength(100,ErrorMessage="Tên URL không được nhập quá 100 ký tự!")]
            public string MenuAction { get; set; }

            [DisplayName("Biểu tượng Menu")]
            [Required(ErrorMessage="Bạn chưa nhập biểu tượng Menu!")]
            [StringLength(50,ErrorMessage="Biểu tượng Menu không được nhập quá 50 ký tự!")]
            public string MenuIcon { get; set; }
           
            [DisplayName("Sắp xếp Menu")]
            [Required(ErrorMessage="Bạn chưa Sắp xếp Menu!")]
            [Range(0, int.MaxValue, ErrorMessage = "Bạn chỉ được nhập số!")]
            public Nullable<int> MenuSort { get; set; }

            [DisplayName("Ngăn cách menu")]
            public Nullable<bool> MenuSeparator { get; set; }
        }
    }
}
