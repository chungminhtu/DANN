using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DANN.Model;
using System.Data.Entity.SqlServer;

namespace DANN.Web.Controllers
{
    public class GridController : Controller
    {
        DANNContext _db = new DANNContext();
        public ActionResult Index()
        {
            return View();
        }

        public bool UpdateData(string jsonData)
        {
            var objectData = new JavaScriptSerializer().Deserialize<List<DataChange>>(String.Format("[{0}]", jsonData));
            foreach (var item in objectData)
            {
                var idChiTieu = Convert.ToInt32(item.IdRow);
                var idDoiTuong = Convert.ToInt32(item.IdCol);
                var tkItem = _db.TK_ThongKe.FirstOrDefault(tk => tk.ChiTieu_Id == idChiTieu && tk.DoiTuong_Id == idDoiTuong);
                if (!String.IsNullOrEmpty(item.Value))
                {
                    decimal valueTemp;
                    if (!Decimal.TryParse(item.Value, out valueTemp)) continue;

                    if (tkItem != null)
                    {
                        tkItem.GiaTriThongKe = item.Value;
                    }
                    else
                    {
                        tkItem = new TK_ThongKe
                        {
                            ChiTieu_Id = idChiTieu,
                            DoiTuong_Id = idDoiTuong,
                            Nhom_Id = 1,
                            KyBaoCao_Id = 1,
                            DiaPhuong_Id = 1,
                            GiaTriThongKe = item.Value
                        };
                        _db.TK_ThongKe.Add(tkItem);
                    }
                }
                else
                {
                    if (tkItem != null)
                    {
                        _db.TK_ThongKe.Remove(tkItem);
                    }
                }
                _db.SaveChanges();
            }
            return true;
        }

        public string GetListDoiTuong()
        {
            var lstDoiTuong = _db.TK_DoiTuong.Select(dt => new HeaderObject
                                                            {
                                                                Id = dt.Id,
                                                                Title = dt.TenDoiTuong,
                                                                ParentId = dt.ParentId.Value
                                                            }).ToList();
            string result = new JavaScriptSerializer().Serialize(lstDoiTuong);
            return result;
        }

        public string GetListChiTieu(string Nhom_Id)
        {
            int iNhom_Id;
            if (int.TryParse(Nhom_Id, out iNhom_Id))
            {
                var lstChiTieu = _db.TK_ChiTieu.Where(ct => ct.Id == iNhom_Id).Select(dt => new HeaderObject
                {
                    Id = dt.Id,
                    Title = dt.TenChiTieu,
                    ParentId = dt.ParentId.Value,
                }).ToList();
                string result = new JavaScriptSerializer().Serialize(lstChiTieu);
                return result;
            }
            return string.Empty;
        }

        public string GetListThongKe(string lstChiTieu_Id, string lstId)
        {
            if (lstChiTieu_Id != null)
            {
            }
            var chiTieuData = new JavaScriptSerializer().Deserialize<List<HeaderObject>>(lstChiTieu_Id);
            var doiTuongData = new JavaScriptSerializer().Deserialize<List<HeaderObject>>(lstId);
            var lstIdChiTieu = chiTieuData.Select(ct => ct.Id).ToList();
            var lstIdDoiTuong = doiTuongData.Select(dt => dt.Id).ToList();
            var result = _db.TK_ThongKe
                .Where(tk => lstIdChiTieu.Contains(tk.ChiTieu_Id) &&
                             lstIdDoiTuong.Contains(tk.DoiTuong_Id)).ToList();
            //.Select(tk => new DataObject
            //                  {
            //                      IdTop = tk.Id,
            //                      IdLeft = tk.ChiTieu_Id,
            //                      GiaTri = tk.GiaTriThongKe
            //                  }).ToList();
            List<DataObject> LstThongKe = new List<DataObject>();
            foreach (var thongke in result)
            {
                LstThongKe.Add(new DataObject { IdTop = thongke.DoiTuong_Id, IdLeft = thongke.ChiTieu_Id, GiaTri = Convert.ToDecimal(thongke.GiaTriThongKe) });
            }

            return new JavaScriptSerializer().Serialize(LstThongKe);
        }

        public string GetListThongKe2(string lstChiTieu_Id, string lstId)
        {
            var chiTieuData = new JavaScriptSerializer().Deserialize<List<HeaderObject>>(lstChiTieu_Id);
            var doiTuongData = new JavaScriptSerializer().Deserialize<List<HeaderObject>>(lstId);
            var lstIdChiTieu = chiTieuData.Select(ct => ct.Id).ToList();
            var lstIdDoiTuong = doiTuongData.Select(dt => dt.Id).ToList();
            var result = _db.TK_ThongKe
                .Where(tk => lstIdChiTieu.Contains(tk.ChiTieu_Id) &&
                             lstIdDoiTuong.Contains(tk.DoiTuong_Id));
            //.Select(tk => new DataObject
            //{
            //    IdLeft = tk.Id,
            //    IdTop = tk.ChiTieu_Id,
            //    GiaTri = (decimal)tk.GiaTriThongKe
            //}).ToList();

            List<DataObject> LstThongKe = new List<DataObject>();
            foreach (var thongke in result)
            {
                LstThongKe.Add(new DataObject { IdLeft = thongke.ChiTieu_Id, IdTop = thongke.ChiTieu_Id, GiaTri = Convert.ToDecimal(thongke.GiaTriThongKe) });
            }

            return new JavaScriptSerializer().Serialize(LstThongKe);
        }

        public string GetListNhomChiTieu()
        {
            var lstNhomChiTieu = _db.DM_PhanHe.Select(nct => new HeaderObject
            {
                Id = nct.Id,
                Title = nct.TenPhanHe,
                ParentId = 0,
            }).ToList();
            string result = new JavaScriptSerializer().Serialize(lstNhomChiTieu);
            return result;
        }

        public string GetUnitFollowListChiTieu(string lstChiTieu)
        {
            var result = new List<DonViTinhObject>();
            var chiTieuData = new JavaScriptSerializer().Deserialize<List<HeaderObject>>(lstChiTieu);
            var lstIdChiTieu = chiTieuData.Select(ct => ct.Id).ToList();
            var data = _db.TK_ChiTieu
                .Where(ct => lstIdChiTieu.Contains(ct.Id))
                .Select(ct => new DonViTinhObject
                                  {
                                      Id = ct.Id,
                                      Title = ct.DM_DonViTinh.TenDonViTinh,
                                      Value = ct.DM_DonViTinh.ValueFormat
                                  }).ToList();
            lstIdChiTieu.ForEach(ict =>
            {
                var item = data.FirstOrDefault(d => d.Id == ict);
                if (item == null)
                {
                    result.Add(new DonViTinhObject
                    {
                        Id = ict,
                        Title = "Mặc định",
                        Value = "0,0"
                    });
                }
                else
                {
                    result.Add(item);
                }
            });
            return new JavaScriptSerializer().Serialize(result);
        }
    }

    public class HeaderObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }

    public class DonViTinhObject : HeaderObject
    {
        public string Value { get; set; }
    }

    public class DataObject
    {
        public int IdTop { get; set; }
        public decimal GiaTri { get; set; }
        public int IdLeft { get; set; }
    }

    public class DataChange
    {
        public int IdRow { get; set; }
        public int IdCol { get; set; }
        public string ValueOld { get; set; }
        public string Value { get; set; }
    }
}
