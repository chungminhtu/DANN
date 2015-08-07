using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(DM_DiaPhuongMetadata))]
    public partial class DM_DiaPhuong : BaseEntity
    {
        public class DM_DiaPhuongMetadata
        {
            public int DiaPhuong_Id { get; set; }
            public Nullable<int> DiaPhuong_ParentId { get; set; }

            [DisplayName("Tên địa phương ")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(200, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string TenDiaPhuong { get; set; }

            [DisplayName("Mã Bản đồ ")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(200, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string IDBanDo { get; set; }

            [DisplayName("Loại")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(5, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string Loai { get; set; }

            [DisplayName("Kinh độ ")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(20, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string Longitude { get; set; }

            [DisplayName("Vĩ độ")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(20, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string Latitude { get; set; }

            [DisplayName("Mã vùng")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(20, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string TelCode { get; set; }
        }
    }
}
