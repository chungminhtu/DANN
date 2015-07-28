using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(DM_KyBaoCaoMetadata))]
    public partial class DM_KyBaoCao : BaseEntity
    {
        public class DM_KyBaoCaoMetadata
        {

            public int KyBaoCao_Id { get; set; }
            public string TenKyBaoCao { get; set; }
            public string LoaiBaoCao { get; set; }
            public string NguonBaoCao { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
