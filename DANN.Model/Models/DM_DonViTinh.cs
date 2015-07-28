using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(DM_DonViTinhMetadata))]
    public partial class DM_DonViTinh : BaseEntity
    {
        public class DM_DonViTinhMetadata
        {

            public int DonViTinh_Id { get; set; }
            public string TenDonViTinh { get; set; }
            public string LoaiDonViTinh { get; set; }
            public string ValueFormat { get; set; }

        }
    }
}
