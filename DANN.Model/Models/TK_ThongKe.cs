using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DANN.Model
{

    [MetadataType(typeof(TK_ThongKeMetadata))]
    public partial class TK_ThongKe : BaseEntity
    {
        public class TK_ThongKeMetadata
        {
            public int ChiTieu_Id { get; set; }
            public int DoiTuong_Id { get; set; }
            public int KyBaoCao_Id { get; set; }
            public int Nhom_Id { get; set; }
            public int DiaPhuong_Id { get; set; }
            public string GiaTriThongKe { get; set; }

            public virtual DM_KyBaoCao DM_KyBaoCao { get; set; }
            public virtual DM_PhanHe DM_PhanHe { get; set; }
            public virtual TK_ChiTieu TK_ChiTieu { get; set; }
            public virtual TK_DoiTuong TK_DoiTuong { get; set; }
        }
    }
}
