using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(BM_CotMetadata))]
    public partial class BM_Cot : BaseEntity
    {
        public class BM_CotMetadata
        {
            public int BieuMau_Id { get; set; }
            public int Cot_Id { get; set; }
            public Nullable<int> Cot_ParentId { get; set; }
        }
    }
}
