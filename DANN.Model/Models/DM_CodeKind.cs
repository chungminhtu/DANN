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
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Mã bảng")]
            public int CodeKind_Id { get; set; }
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Tên bảng")]
            public string CodeKindName { get; set; }
        }
    }
}
