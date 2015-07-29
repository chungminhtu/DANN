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
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [Range(1, 100, ErrorMessage = DANN.Service.CommonMessages.Range)]
            public int CodeKind_Id { get; set; }

            [DisplayName("Tên bảng")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(100, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string CodeKindName { get; set; }
        }
    }
}
