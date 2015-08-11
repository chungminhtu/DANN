using DevExpress.Web.Mvc;
using DANN.Service;
using DANN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DANN.Web.Controllers
{


    public class BMBieuMauController : CommonController<BM_BieuMau, BM_BieuMau, BM_BieuMau>
        {
            IEntityService<BM_BieuMau> _service;

            public BMBieuMauController(IEntityService<BM_BieuMau> service, IEntityService<BM_BieuMau> service1, IEntityService<BM_BieuMau> service2)
            : base(service, service1, service2)
        {
            _service = service;
        } 
    }

}