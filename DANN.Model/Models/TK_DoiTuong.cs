using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(TK_DoiTuongMetadata))]
    public partial class TK_DoiTuong : BaseEntity
    {
        public class TK_DoiTuongMetadata
        {
            public int DoiTuong_Id { get; set; }
            public Nullable<int> DoiTuong_ParentId { get; set; }

            [DisplayName("Tên Đối tượng")]
            [Required(ErrorMessage = DANN.Service.CommonMessages.Required)]
            [StringLength(200, ErrorMessage = DANN.Service.CommonMessages.StringLenght)]
            public string TenDoiTuong { get; set; }
            public Nullable<int> Nhom_Id { get; set; }

        }
    }
}
