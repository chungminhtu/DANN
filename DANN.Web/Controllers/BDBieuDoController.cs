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

        public ActionResult ListChecBoxKBCPartial()
        {
            var Model = _service3.GetAll();
            return PartialView("_ListChecBoxKBCPartial", Model);
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

        public ActionResult BieuDo(string CallBack, [Bind]ChartBarViewsDemoOptions options)
        {
            if (CallBack == null || CallBack == "")
            {
                List<int> LstMaKyBaoCaoCheck = new List<int>();
                int MaChiTieuSelect = 4;
                List<int> LstMaDiaPhuongCheck = new List<int>();
                LstMaKyBaoCaoCheck.Add(1);
                LstMaKyBaoCaoCheck.Add(2);
                LstMaKyBaoCaoCheck.Add(3);
                LstMaDiaPhuongCheck.Add(1);

                TK_ChiTieu chitieu = new TK_ChiTieu();
                DM_PhanHe PhanHe = new DM_PhanHe();
                chitieu = _service1.GetEntityById(MaChiTieuSelect);
                PhanHe = _service4.GetEntityById(chitieu.PhanHe_Id);
                ViewBag.TenPhanHe = PhanHe.TenPhanHe;
                List<View_ThongKeNienGiam> LstThongKe = _service6._dbset.Where(a => LstMaDiaPhuongCheck.Contains(a.DiaPhuong_Id) && LstMaKyBaoCaoCheck.Contains(a.KyBaoCao_Id) && a.ChiTieu_Id == MaChiTieuSelect).ToList();
                //Chuyển dữ liệu thống kê từ string sang decimal để hiển thị lên biểu đồ
                List<BieuDoNienGiam> LstThongKeNienGiam = new List<BieuDoNienGiam>();
                foreach (var item in LstThongKe)
                {
                    BieuDoNienGiam itemNienGiam = new BieuDoNienGiam();
                    itemNienGiam.TenKyBaoCao = item.TenKyBaoCao;
                    itemNienGiam.TenChiTieu = item.TenChiTieu;
                    itemNienGiam.ChiTieu_Id = item.ChiTieu_Id;
                    itemNienGiam.KyBaoCao_Id = item.KyBaoCao_Id;
                    itemNienGiam.DiaPhuong_Id = item.DiaPhuong_Id;
                    itemNienGiam.GiaTriThongKe = Convert.ToDecimal(item.GiaTriThongKe);
                    itemNienGiam.TenDiaPhuong = item.TenDiaPhuong;
                    LstThongKeNienGiam.Add(itemNienGiam);
                }
                ViewData[ChartDemoHelper.OptionsKey] = options;
                Session["ThongKeNienGiam"] = LstThongKeNienGiam;
                //Tiêu đề báo cáo
                if (LstThongKe.Any())
                {
                    ViewBag.TenChiTieu = LstThongKe[0].TenChiTieu;
                }
                return View(LstThongKeNienGiam);
            }
            else
            {
                ViewData[ChartDemoHelper.OptionsKey] = options;
                return View(Session["ThongKeNienGiam"]);
            }
        }
        public static ChartBarViewsDemoOptions loaibd { set; get; }
        public ActionResult BieuDoPartial([Bind]ChartBarViewsDemoOptions options)
        {
            if (loaibd != null)
            {
                ViewData[ChartDemoHelper.OptionsKey] = loaibd;
            }
            else
            {
                ViewData[ChartDemoHelper.OptionsKey] = options;
            }

            return PartialView("BieuDoPartial", Session["ThongKeNienGiam"]);
        }
    }
    public class BieuDoNienGiam
    {
        public string TenKyBaoCao { get; set; }
        public string TenChiTieu { get; set; }
        public int ChiTieu_Id { get; set; }
        public int KyBaoCao_Id { get; set; }
        public int DiaPhuong_Id { get; set; }
        public decimal GiaTriThongKe { get; set; }
        public string TenDiaPhuong { get; set; }
    }
}