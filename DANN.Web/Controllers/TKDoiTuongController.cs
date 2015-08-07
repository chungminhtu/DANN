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
    public class TKDoiTuongController : CommonController<TK_DoiTuong, TK_DoiTuong, TK_DoiTuong>
    {
        public TKDoiTuongController(IEntityService<TK_DoiTuong> service, IEntityService<TK_DoiTuong> service1, IEntityService<TK_DoiTuong> service2)
            : base(service, service1, service2)
        {

        }
    }
}