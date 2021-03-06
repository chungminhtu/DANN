﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(DM_PhanHeMetadata))]
    public partial class DM_PhanHe : BaseEntity
    {
        public class DM_PhanHeMetadata
        {

            public int PhanHe_Id { get; set; }

            [DisplayName("Tên Phân hệ")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(200, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string TenPhanHe { get; set; }

            public virtual ICollection<TK_ThongKe> TK_ThongKe { get; set; }
        }
    }
}
