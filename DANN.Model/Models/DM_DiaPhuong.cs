using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(DM_DiaPhuongMetadata))]
    public partial class DM_DiaPhuong : BaseEntity
    {
        public class DM_DiaPhuongMetadata
        {
            public int DiaPhuong_Id { get; set; }
            public Nullable<int> DiaPhuong_ParentId { get; set; }
            public string TenDiaPhuong { get; set; }
            public string IDBanDo { get; set; }
            public string Loai { get; set; }
            public string Longitude { get; set; }
            public string Latitude { get; set; }
            public string TelCode { get; set; }
        }
    }
}
