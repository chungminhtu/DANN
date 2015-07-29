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
            [Required(ErrorMessage="Bạn chưa nhập \"{0}\"")]
            [StringLength(200,ErrorMessage="\"{0}\" không được nhập quá 200 ký tự.")]
            public string TenDoiTuong { get; set; }
            public Nullable<int> Nhom_Id { get; set; }

        }
    }
}
