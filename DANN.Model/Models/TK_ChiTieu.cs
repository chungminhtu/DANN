using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(TK_ChiTieuMetadata))]
    public partial class TK_ChiTieu : BaseEntity
    {
        public class TK_ChiTieuMetadata
        {

            public int ChiTieu_Id { get; set; }
            public Nullable<int> ChiTieu_ParentId { get; set; }
            public string TenChiTieu { get; set; }
            public Nullable<int> PhanHe_Id { get; set; }
            public Nullable<int> DonViTinh_Id { get; set; }

        }
    }
}
