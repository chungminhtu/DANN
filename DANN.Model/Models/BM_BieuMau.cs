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
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(100, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string TenBieuMau { get; set; }
        }
    }
}
