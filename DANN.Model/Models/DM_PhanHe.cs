using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(DM_PhanHeMetadata))]
    public partial class DM_PhanHe : BaseEntity
    {
        public class DM_PhanHeMetadata
        {

            public int PhanHe_Id { get; set; }
           
            [DisplayName("Tên Phân hệ")]
            [Required(ErrorMessage="Bạn chưa nhập Tên phân hệ!")]
            [StringLength(200,ErrorMessage="Tên phân hệ không được nhập quá 200 ký tự!")]
            public string TenPhanHe { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
