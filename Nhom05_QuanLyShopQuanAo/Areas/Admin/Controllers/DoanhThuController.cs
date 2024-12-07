using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom05_QuanLyShopQuanAo.Areas.Admin.Data;
namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class DoanhThuController : Controller
    {
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Where(dh => dh.TrangThaiDonHang == "Đã xác nhận").ToList();
            var doanhThuTheoThang = new decimal[12];
            List<DGHang> tong = new List<DGHang>();
            foreach (var dh in donHangs)
            {
                int thang = dh.NgayDat.Value.Month - 1;
                decimal tongGia = decimal.Parse(dh.ChiTietDonHangs.Sum(ct => ct.GiaDonVi).ToString());
                doanhThuTheoThang[thang] += tongGia;
                tong.Add(new DGHang (dh.MaDonHang, tongGia, dh.NgayDat));
            }
            ViewBag.ListTongHang = tong;
            ViewBag.TongGia = tong.Sum(t => t.TongTien);
            ViewBag.DoanhThu = doanhThuTheoThang;
            return View();
        }
    }
}