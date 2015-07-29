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


            // [DisplayName("Tên người truy cập")]
            public string UserName { get; set; }

            [DisplayName("Mã MenuId")]
            public Nullable<int> Menu_Id { get; set; }


            [DisplayName("Thao tác")]
            public string ActionName { get; set; }

            [DisplayName("Các giá trị thay đổi")]

            public string Variables { get; set; }
        }
    }
}
