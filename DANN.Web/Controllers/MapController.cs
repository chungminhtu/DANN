using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using WebMatrix.WebData;
using DANN.Web.Filters;
using DANN.Web.Models;

namespace DANN.Web.Controllers
{
    public class MapController : Controller
    {
        BDVTW_DBEntities _db = new BDVTW_DBEntities();
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            return View();
        }

        public ActionResult IndexRewriteId()
        {
            return View();
        }

        public ActionResult CallBackIndexRewriteId()
        {
            //UpdateIdDiaPhuong(string.Empty, string.Empty, string.Empty, 0);
            //UpdateIdBanDo();
            ReNameTinhHuyen(@"D:\Work\PhungThuc\Du An\duanbdv\WebBDV_Final\Web BDV Devexpress 14.2\DANN.Web\DANN.Web\maps\vn\ORIGINAL");

            return PartialView("IndexRewriteId");
        }

        //private async void UpdateIdDiaPhuong(string path)
        //{
        //    var directory = new DirectoryInfo(path);
        //    var lstFile = directory.GetFiles("*.*");
        //    foreach (var item in lstFile)
        //    {
        //        if(item.Name.Contains("_"))
        //        {
        //            var arrName = item.Name.Split('_');
        //            item.MoveTo(string.Format("{0}/{1}", path, arrName[arrName.Length-1]));
        //        }
        //    }
        //    var lstDirectory = directory.GetDirectories();
        //    foreach (var item in lstDirectory)
        //    {
        //        UpdateIdDiaPhuong(item.FullName);
        //    }
        //}

        private void ReNameTinhHuyen(string path)
        {
            var directory = new DirectoryInfo(path);
            var lstFile = directory.GetFiles("*.*");
            foreach (var item in lstFile)
            {
                string name = string.Format("{0}/{1}", path, item.Name);

                string text = System.IO.File.ReadAllText(name);
                var dk = true;
                while (dk)
                {
                    var startSub = text.IndexOf("___", System.StringComparison.Ordinal);
                    if (startSub <= 0)
                    {
                        dk = false;
                        continue;
                    }
                    var endSub = text.IndexOf('"', startSub);
                    if (endSub > startSub)
                    {
                        var removeItem = text.Substring(startSub, endSub - startSub);
                        if (string.IsNullOrEmpty(removeItem))
                        {
                            dk = false;
                        }
                        else
                        {
                            text = text.Replace(removeItem, "");
                        }
                    }
                    else
                    {
                        dk = false;
                    }
                }

                System.IO.File.WriteAllText(name, text);

                if (item.Name.Contains("_"))
                {
                    var arrName = item.Name.Split('_');
                    var itemDirectory = new DirectoryInfo(String.Format("{0}/{1}", path, arrName[0]));
                    if (!itemDirectory.Exists)
                    {
                        itemDirectory.Create();
                    }
                    name = string.Format("{0}/{1}/{2}", path, arrName[0], arrName[arrName.Length - 1]);
                    item.MoveTo(name);

                }
            }
        }

        private void UpdateIdBanDo()
        {
            var items = _db.DanhMucDiaPhuongs.ToList();
            items.ForEach(item =>
            {
                var newUpdate = new ThongKe
                {
                    MaThongKe = Guid.NewGuid(),
                    MaDiaPhuong = item.DiaPhuongID,
                    MaChiTieu = Guid.Parse("539a6083-2aa3-4d73-a18f-a1bd51d9d694"),
                    TenKyBaoCao = "Kỳ báo cáo năm 2014",
                    CapSoLieu = 1,
                    GiaTriThongKe = new Random().Next(10, 1000).ToString(CultureInfo.InvariantCulture),
                    NguoiTao = "Administrator"
                };
                _db.ThongKes.Add(newUpdate);
                _db.SaveChanges();
            });
        }
        //
        //		private async Task<int> UpdateIdDiaPhuong(string nameCha, int idChaOld, int idChaNew, int id)
        //		{
        //			var items = _db.DanhMucDiaPhuongs.Where(dp => dp.DiaPhuongIDCha == idChaOld).ToList();
        //			if(items.Count == 0)return id;
        //			items.ForEach(async item =>
        //			{
        //				var idBanDo = string.Empty;
        //				if(!string.IsNullOrEmpty(item.TenDiaPhuong))
        //					idBanDo = nameCha + item.TenDiaPhuong.Replace(" ", "").Trim();
        //				var currentId = ++id;
        //				id = await UpdateIdDiaPhuong(string.IsNullOrEmpty(idBanDo) ? string.Empty : idBanDo + "_", item.DiaPhuongID, id, id);
        //				var itemUpdate = _db.DanhMucDiaPhuongs.First(dp => item.DiaPhuongID == dp.DiaPhuongID);
        //				var newItem = new DanhMucDiaPhuong
        //				{
        //					DiaPhuongID = currentId,
        //					DiaPhuongIDCha = idChaNew,
        //					IDBanDo = idBanDo,
        //					MaCapDP = itemUpdate.MaCapDP,
        //					MaVungDP = itemUpdate.MaVungDP,
        //					MoTaThem = itemUpdate.MoTaThem,
        //					TenDiaPhuong = itemUpdate.TenDiaPhuong
        //				};
        //				_db.DanhMucDiaPhuongs.Remove(itemUpdate);
        //				_db.DanhMucDiaPhuongs.Add(newItem);
        //				_db.SaveChanges();
        //			});
        //			return id;
        //		}

        public string GetDataThongKe()
        {
            var dataThongKe = _db.ThongKes.Select(dp => new { IdBanDo = dp.DanhMucDiaPhuong.IDBanDo, Value = dp.GiaTriThongKe }).ToList();
            var lstDataItem = dataThongKe.Select(dp => string.Format("\"{0}\":\"{1}\"", dp.IdBanDo, dp.Value));
            var result = String.Join(",", lstDataItem);
            return String.Format("{0}{1}{2}", "{", result, "}");
        }
    }
}