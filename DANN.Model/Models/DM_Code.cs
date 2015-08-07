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
           // [Range(0,int.MaxValue,ErrorMessage=DANN.Service.CommonMessages.range)]
            public int Code_Id { get; set; }

         //   [DisplayName("Mã bảng")]
         //   [Required(ErrorMessage = "Bạn chưa nhập Mã bảng!")]
         //   [Range(0,int.MaxValue,ErrorMessage=DANN.Service.CommonMessages.range)]
            public int CodeKind_Id { get; set; }

            [DisplayName("Mã giá trị")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [Range(1, 100, ErrorMessage = DANN.Model.CommonMessages.Range)]
            public int CodeValue { get; set; }


            [DisplayName("Tên giá trị")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(100, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string CodeName { get; set; }

        }
    }
}
