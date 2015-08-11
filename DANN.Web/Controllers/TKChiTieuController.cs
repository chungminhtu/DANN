using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DANN.Service;
using DANN.Model;
namespace DANN.Web.Controllers
{
    public class TKChiTieuController : CommonController<TK_ChiTieu, TK_ChiTieu, TK_ChiTieu>
    {
        public TKChiTieuController(IEntityService<TK_ChiTieu> service, IEntityService<TK_ChiTieu> service1, IEntityService<TK_ChiTieu> service2)
            : base(service, service1, service2)
        {

        }
    }
}