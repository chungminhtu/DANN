using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(BM_DongMetadata))]
    public partial class BM_Dong : BaseEntity
    {
        public class BM_DongMetadata
        {
            public int BieuMau_Id { get; set; }
            public int Dong_Id { get; set; }
            public Nullable<int> Dong_ParentId { get; set; }
        }
    }
}
