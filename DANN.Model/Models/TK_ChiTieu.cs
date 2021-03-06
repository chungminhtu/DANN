﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DANN.Model
{

    [MetadataType(typeof(TK_ChiTieuMetadata))]
    public partial class TK_ChiTieu : BaseEntity
    {
        public class TK_ChiTieuMetadata
        {

            public int ChiTieu_Id { get; set; }
            public Nullable<int> ChiTieu_ParentId { get; set; }

            [DisplayName("Tên Chỉ tiêu")]
            [Required(ErrorMessage = DANN.Model.CommonMessages.Required)]
            [StringLength(300, ErrorMessage = DANN.Model.CommonMessages.StringLenght)]
            public string TenChiTieu { get; set; }


            public Nullable<int> PhanHe_Id { get; set; }
            public Nullable<int> DonViTinh_Id { get; set; }

        }
    }
}
