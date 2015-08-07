using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(AD_LichSuMetadata))]
    public partial class AD_LichSu : BaseEntity
    {
        public class AD_LichSuMetadata
        {
            public int LichSu_Id { get; set; }


            [DisplayName("Tên người truy cập")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(30, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string UserName { get; set; }

            [DisplayName("Mã MenuId")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [Range(1, int.MaxValue, ErrorMessage = DANN.Model.CommonMessages.Range)]
            public Nullable<int> Menu_Id { get; set; }


            [DisplayName("Thao tác")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(50, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string ActionName { get; set; }

            [DisplayName("Các giá trị thay đổi")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(50, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]

            public string Variables { get; set; }
        }
    }
}
