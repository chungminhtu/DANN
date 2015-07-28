using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(TK_DoiTuongMetadata))]
    public partial class TK_DoiTuong : BaseEntity
    {
        public class TK_DoiTuongMetadata
        {
            public int DoiTuong_Id { get; set; }
            public Nullable<int> DoiTuong_ParentId { get; set; }
            public string TenDoiTuong { get; set; }
            public Nullable<int> Nhom_Id { get; set; }

        }
    }
}
