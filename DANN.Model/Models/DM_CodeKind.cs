using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(DM_CodeKindMetadata))]
    public partial class DM_CodeKind : BaseEntity
    {
        public class DM_CodeKindMetadata
        {
            [DisplayName("Mã bảng")]
            [Required(ErrorMessage = "Bạn chưa nhập Mã bảng!")]
            [Range(0, int.MaxValue, ErrorMessage="Bạn chỉ được nhập số!")]
            public int CodeKind_Id { get; set; }
           
            [DisplayName("Tên bảng")]
            [Required(ErrorMessage = "Bạn chưa nhập Tên bảng!")]
            [StringLength(100,ErrorMessage="Tên bảng không được nhập quá 100 ký tự!")]
            public string CodeKindName { get; set; }
        }
    }
}
