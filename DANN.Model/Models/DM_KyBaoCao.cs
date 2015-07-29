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
            [Required(ErrorMessage = "Bạn chưa nhập *Tên kỳ báo cáo*")]
            [StringLength(100, ErrorMessage= "Tên kỳ báo cáo dài quá 100 ký tự!")]
            public string TenKyBaoCao { get; set; }
           
            [DisplayName("Loại Kỳ báo cáo")]
            [Required(ErrorMessage="Bạn chưa nhập Loại Kỳ báo cáo!")]
            [StringLength(50,ErrorMessage="Loại kỳ báo cao không được nhập quá 50 ký tự!")]
            public string LoaiBaoCao { get; set; }
           
            [DisplayName("Nguồn báo cáo")]
            [Required(ErrorMessage="Bạn chưa nhập Nguồn báo cáo!")]
            [StringLength(50,ErrorMessage="Nguồn báo cáo không được nhập quá 50 ký tự!")]
            public string NguonBaoCao { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
