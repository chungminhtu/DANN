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
    public class BDBieuDoController : CommonController<TK_ChiTieu, TK_ThongKe, DM_KyBaoCao>
    {

        IEntityService<TK_ChiTieu> _service1;
        IEntityService<TK_ThongKe> _service2;
        IEntityService<DM_KyBaoCao> _service3;
        IEntityService<DM_PhanHe> _service4;
        IEntityService<DM_DiaPhuong> _service5;
        IEntityService<View_ThongKeNienGiam> _service6;
        public BDBieuDoController(IEntityService<TK_ChiTieu> service1, IEntityService<TK_ThongKe> service2,
            IEntityService<DM_KyBaoCao> service3, IEntityService<DM_PhanHe> service4,
            IEntityService<DM_DiaPhuong> service5, IEntityService<View_ThongKeNienGiam> service6)
            : base(service1, service2, service3)
        {
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;
            _service4 = service4;
            _service5 = service5;
            _service6 = service6;
        }

        public ActionResult ComboBoxKBCPartial()
        {
            var Model = _service3.GetAll();
            return PartialView("_ComboBoxKBCPartial", Model);
        }

        public ActionResult ComboBoxPhanHePartial()
        {
            var Model = _service4.GetAll();
            return PartialView("_ComboBoxPhanHePartial", Model);
        }

        [ValidateInput(false)]
        public ActionResult TreeListChiTieuPartial()
        {
            var Model = _service1.GetAll();
            return PartialView("_TreeListChiTieuPartial", Model);
        }

        [ValidateInput(false)]
        public ActionResult TreeListDiaPhuongPartial()
        {
            var Model = _service5.GetAll();
            return PartialView("_TreeListDiaPhuongPartial", Model);
        }

        [HttpPost]
        public ActionResult Index()
        {
            string MaKyBaoCaoSelect;
            string MaChiTieuSelect;
            List<string> LstMaDiaPhuongCheck = new List<string>();
            List<int> ListDP = new List<int>() { 1, 2, 3 };
            List<View_ThongKeNienGiam> LstThongKe = _service6._dbset.Where(a => ListDP.Contains(a.DiaPhuong_Id)).ToList();
            return View();
        }

    }
}