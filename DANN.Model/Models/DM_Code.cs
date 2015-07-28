using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(DM_CodeMetadata))]
    public partial class DM_Code : BaseEntity
    {
        public class DM_CodeMetadata
        {
            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Mã CodeId")]
            public int Code_Id { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Mã bảng")]
            public int CodeKind_Id { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Mã giá trị")]
            public int CodeValue { get; set; }


            [Required(ErrorMessage = "Bạn chưa nhập *")]
            [DisplayName("Tên giá trị")]
            public string CodeName { get; set; }

        }
    }
}
