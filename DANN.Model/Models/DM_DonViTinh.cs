using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(DM_DonViTinhMetadata))]
    public partial class DM_DonViTinh : BaseEntity
    {
        public class DM_DonViTinhMetadata
        {

            public int DonViTinh_Id { get; set; }
            
            [DisplayName("Tên Đơn Vị Tính")]
            [Required(ErrorMessage="Bạn chưa nhập Tên Đơn Vị Tính!")]
            [StringLength(100,ErrorMessage="Tên Đơn Vị Tính không được vượt quá 100 ký tự!")]
            public string TenDonViTinh { get; set; }

            [DisplayName("Loại Đơn Vị Tính")]
            [Required(ErrorMessage="Bạn chưa nhập Loại Đơn Vị Tính!")]
            [StringLength(20,ErrorMessage="Loại Đơn Vị Tính không được nhập quá 20 ký tự!")]
            public string LoaiDonViTinh { get; set; }
           
            
            public string ValueFormat { get; set; }

        }
    }
}
