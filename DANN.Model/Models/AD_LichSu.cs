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
            [Required(ErrorMessage="Bạn chưa nhập tên truy cập!")]
            [StringLength(30,ErrorMessage="Tên truy cập không được vượt quá 30 ký tự!")]
            public string UserName { get; set; }

            [DisplayName("Mã MenuId")]
            [Required(ErrorMessage="Bạn chưa nhập Mã MenuId!")]
            [Range(0,int.MaxValue,ErrorMessage="Bạn chỉ được nhập số!")]
            public Nullable<int> Menu_Id { get; set; }


            [DisplayName("Thao tác")]
            [Required(ErrorMessage="Bạn phải nhập Thao tác!")]
            [StringLength(50,ErrorMessage="Bạn không được nhập quá 50 ký tự!")]
            public string ActionName { get; set; }

            [DisplayName("Các giá trị thay đổi")]
            [Required(ErrorMessage="Bạn phải nhập giá trị thay đổi!")]
            [StringLength(50,ErrorMessage="Bạn không được nhập quá 50 ký tự!")]

            public string Variables { get; set; }
        }
    }
}
