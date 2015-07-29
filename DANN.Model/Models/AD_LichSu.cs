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
            [Required(ErrorMessage="Bạn chưa nhập \"{0}\"")]
            [StringLength(30,ErrorMessage="\"{0}\" không được vượt quá 30 ký tự!")]
            public string UserName { get; set; }

            [DisplayName("Mã MenuId")]
            [Required(ErrorMessage="Bạn chưa nhập\" {0}\"")]
            [Range(0,int.MaxValue,ErrorMessage="Bạn chỉ được nhập số!")]
            public Nullable<int> Menu_Id { get; set; }


            [DisplayName("Thao tác")]
            [Required(ErrorMessage="Bạn phải nhập \"{0}\"")]
            [StringLength(50,ErrorMessage="Bạn không được nhập quá 50 ký tự!")]
            public string ActionName { get; set; }

            [DisplayName("Các giá trị thay đổi")]
            [Required(ErrorMessage="Bạn phải nhập \" {0}\"")]
            [StringLength(50,ErrorMessage="Bạn không được nhập quá 50 ký tự!")]

            public string Variables { get; set; }
        }
    }
}
