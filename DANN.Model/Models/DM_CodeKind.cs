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
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [Range(0, int.MaxValue, ErrorMessage="Bạn chỉ được nhập số.")]
            public int CodeKind_Id { get; set; }
           
            [DisplayName("Tên bảng")]
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [StringLength(100,ErrorMessage="\"{0}\" không được nhập quá 100 ký tự.")]
            public string CodeKindName { get; set; }
        }
    }
}
