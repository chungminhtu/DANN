using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DANN.Model;
using DANN.Model;

namespace DANN.Web.Controllers
{


    public class ADLichSuController : CommonController<AD_LichSu, AD_LichSu, AD_LichSu>
    {
        IEntityService<AD_LichSu> _service;

        public ADLichSuController(IEntityService<AD_LichSu> service, IEntityService<AD_LichSu> service1, IEntityService<AD_LichSu> service2)
            : base(service, service1, service2)
        {
            _service = service;
        }
    }
}