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
            [Required(ErrorMessage=DANN.Service.CommonMessages.Required)]
            [StringLength(200,ErrorMessage="\"{0}\" không được nhập quá 200 ký tự.")]
            public string TenPhanHe { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
