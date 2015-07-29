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
            [Required(ErrorMessage = "Bạn chưa nhập \"{0}\"")]
            [StringLength(100, ErrorMessage= "\"{0}\" dài quá 100 ký tự.")]
            public string TenKyBaoCao { get; set; }
           
            [DisplayName("Loại Kỳ báo cáo")]
            [Required(ErrorMessage="Bạn chưa nhập\" {0}\"")]
            [StringLength(50,ErrorMessage="\"{0}\" không được nhập quá 50 ký tự.")]
            public string LoaiBaoCao { get; set; }
           
            [DisplayName("Nguồn báo cáo")]
            [Required(ErrorMessage="Bạn chưa nhập\" {0}\"")]
            [StringLength(50,ErrorMessage="\"{0}\" không được nhập quá 50 ký tự.")]
            public string NguonBaoCao { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
