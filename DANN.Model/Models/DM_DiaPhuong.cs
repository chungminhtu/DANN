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
            [Required(ErrorMessage="Bạn chưa nhập Tên địa phương!")]
            [StringLength(200,ErrorMessage="Tên địa phương không được nhập quá 200 ký tự!")]
            public string TenDiaPhuong { get; set; }
           
            [DisplayName("Mã Bản đồ ")]
            [Required(ErrorMessage="Bạn chưa nhập Mã bản đồ!")]
            [StringLength(200,ErrorMessage="Mã Bản đồ không được nhập quá 200 ký tự!")]
            public string IDBanDo { get; set; }

            [DisplayName("Loại")]
            [Required(ErrorMessage="Bạn chưa nhập vào Loại!")]
            [StringLength(5,ErrorMessage="Bạn chỉ được nhập tối đa 5 ký tự!")]
            public string Loai { get; set; }
           
            [DisplayName("Kinh độ ")]
            [Required(ErrorMessage="Bạn chưa nhập vào Kinh độ!")]
            [StringLength(20,ErrorMessage="Kinh độ không được nhập quá 20 ký tự!")]
            public string Longitude { get; set; }

            [DisplayName("Vĩ độ")]
            [Required(ErrorMessage="Bạn chưa nhập vào Vĩ độ!")]
            [StringLength(20,ErrorMessage="Vĩ độ không được nhập quá 20 ký tự!")]
            public string Latitude { get; set; }
            
            
            public string TelCode { get; set; }
        }
    }
}
