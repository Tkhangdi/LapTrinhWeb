using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom05_QuanLyShopQuanAo.Models;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult HienThi()
        {
            ViewBag.DonHangList = db.DonHangs.ToList();
            ViewBag.Count = db.DonHangs.ToList().Count;
            return View();
        }
        [HttpGet]
        public ActionResult ChiTietDH(string id)
        {
            var selectedDH = db.DonHangs.FirstOrDefault(dh => id == dh.MaDonHang);
            if (selectedDH == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChiTietList = db.ChiTietDonHangs.Where(c => id == c.MaDonHang).ToList();
            var khach = db.KhachHangs.FirstOrDefault(k => selectedDH.MaKhachHang == k.TenDangNhap);
            ViewBag.TenKH = khach?.Ho + " " + khach?.Ten;

            return View(selectedDH);
        }
        [HttpPost]
        public ActionResult ChiTietDH(string id, bool temp = true)
        {
            var selectedDH = db.DonHangs.FirstOrDefault(dh => id == dh.MaDonHang);
            if (selectedDH == null)
            {
                return HttpNotFound();
            }
            var selectedCT = db.ChiTietDonHangs.Where(ct => ct.MaDonHang == selectedDH.MaDonHang).ToList();
            foreach (var ct in selectedCT)
            {
                var size_sp = db.Size_SanPhams.FirstOrDefault(s => s.MaSanPham == ct.MaSanPham && s.MaSize == ct.MaSize);
                size_sp.SoLuong -= ct.SoLuong;
            }
            selectedDH.TrangThaiDonHang = "Đã xác nhận";
            db.SubmitChanges();
            ViewBag.ChiTietList = db.ChiTietDonHangs.Where(c => id == c.MaDonHang).ToList();
            var khach = db.KhachHangs.FirstOrDefault(k => selectedDH.MaKhachHang == k.TenDangNhap);
            ViewBag.TenKH = khach?.Ho + " " + khach?.Ten;

            return View(selectedDH);
        }
        public ActionResult ChiTiet(string id)
        {
            var selectedCT = db.ChiTietDonHangs.FirstOrDefault(c => id == c.MaChiTietDonHang);
            var chitietsp = db.SanPhams.FirstOrDefault(c => selectedCT.MaSanPham == c.MaSanPham);
            ViewBag.CT = chitietsp;
            ViewBag.TenDM = db.DanhMucs.FirstOrDefault(d => chitietsp.MaDanhMuc == d.MaDanhMuc).TenDanhMuc;
            ViewBag.TenTH = db.ThuongHieus.FirstOrDefault(t => chitietsp.MaThuongHieu == t.MaThuongHieu).TenThuongHieu;
            return View(selectedCT);
        }
    }
}