using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(BM_BieuMauMetadata))]
    public partial class BM_BieuMau : BaseEntity
    {
        public class BM_BieuMauMetadata
        {
            public int BieuMau_Id { get; set; }

            [DisplayName("Tên biểu mẫu")]
            [Required(ErrorMessage = "Bạn chưa nhập Tên biểu mẫu!")]
            [StringLength(100,ErrorMessage="Tên biểu mẫu không được nhập quá 100 ký tự!")]
            public string TenBieuMau { get; set; }
        }
    }
}
