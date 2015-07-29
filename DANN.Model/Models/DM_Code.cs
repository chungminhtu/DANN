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
           // [DisplayName("Mã CodeId")]
           // [Required(ErrorMessage = "Bạn chưa nhập Mã CodeId")]
           // [Range(0,int.MaxValue,ErrorMessage="Bạn chỉ được nhập số!")]
            public int Code_Id { get; set; }

         //   [DisplayName("Mã bảng")]
         //   [Required(ErrorMessage = "Bạn chưa nhập Mã bảng!")]
         //   [Range(0,int.MaxValue,ErrorMessage="Bạn chỉ được nhập số!")]
            public int CodeKind_Id { get; set; }

            [DisplayName("Mã giá trị")]
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [Range(0,int.MaxValue,ErrorMessage="Bạn chỉ được nhập số.")]
            public int CodeValue { get; set; }


            [DisplayName("Tên giá trị")]
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [StringLength(100,ErrorMessage="\"Tên giá trị\" không được nhập quá 100 ký tự.")]
            public string CodeName { get; set; }

        }
    }
}
