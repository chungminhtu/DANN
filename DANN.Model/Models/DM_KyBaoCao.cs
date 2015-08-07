using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(DM_KyBaoCaoMetadata))]
    public partial class DM_KyBaoCao : BaseEntity
    {
        public class DM_KyBaoCaoMetadata
        {

            public int KyBaoCao_Id { get; set; }

            [DisplayName("Tên kỳ báo cáo")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(100, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string TenKyBaoCao { get; set; }

            [DisplayName("Loại Kỳ báo cáo")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(50, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string LoaiBaoCao { get; set; }

            [DisplayName("Nguồn báo cáo")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(50, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string NguonBaoCao { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
