using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom05_QuanLyShopQuanAo.Models;

namespace Nhom05_QuanLyShopQuanAo.Controllers
{
    public class ThongTinController : Controller
    {
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        // GET: ThongTin
        public ActionResult ThongTinNguoiDung()
        {
            var user = (UserAccount)Session["khach"];
            if (user == null)
            {
                return RedirectToAction("Login_NguoiDung", "DangNhap");
            }

            var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.TenDangNhap == user.TenDangNhap);
            return View(khachHang);
        }

        [HttpPost]
        public ActionResult CapNhatThongTin(KhachHang model)
        {
            var user = (UserAccount)Session["khach"];
            if (user == null)
            {
                ViewBag.Message = "Cập nhật thất bại!";
                return RedirectToAction("Login_NguoiDung", "DangNhap");
            }

            var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.TenDangNhap == user.TenDangNhap);
            if (khachHang != null)
            {
                khachHang.Ho = model.Ho;
                khachHang.Ten = model.Ten;
                khachHang.GioiTinh = model.GioiTinh;
                khachHang.DienThoai = model.DienThoai;
                khachHang.Email = model.Email;


                db.SubmitChanges();
                ViewBag.Message = "Cập nhật thành công!";
            }
            else
            {
                ViewBag.Message = "Cập nhật thất bại!";
            }

            return View("ThongTinNguoiDung",khachHang);

        }

        public ActionResult LichSuMuaHang(string id)
        {
            var user = (UserAccount)Session["khach"];

            return View(db.DonHangs.Where(t => t.MaKhachHang == user.TenDangNhap).ToList());
        }

        public ActionResult ChiTietDonHang(string id)
        {
            return View(db.ChiTietDonHangs.Where(t => t.MaDonHang == id).ToList());
        }


        public ActionResult HuyDon(string id)
        {
            var donHang = db.DonHangs.FirstOrDefault(dh => dh.MaDonHang == id);
            if (donHang == null)
            {
                TempData["Message"] = "Đơn hàng không tồn tại!";
                return RedirectToAction("LichSuMuaHang");
            }

            if (!donHang.NgayDat.HasValue)
            {
                TempData["Message"] = "Ngày đặt hàng không hợp lệ!";
                return RedirectToAction("LichSuMuaHang");
            }

            var ngayHienTai = DateTime.Now;
            var ngayDat = donHang.NgayDat.Value;
            if ((ngayHienTai - ngayDat).TotalDays > 2)
            {
                TempData["Message"] = "Đơn hàng đã quá thời hạn hủy (2 ngày)!";
                return RedirectToAction("LichSuMuaHang");
            }

            donHang.TrangThaiDonHang = "Đã hủy";

            var chiTietDonHang = db.ChiTietDonHangs.Where(ct => ct.MaDonHang == id).ToList();
            foreach (var item in chiTietDonHang)
            {
                var sizeSanPham = db.Size_SanPhams.FirstOrDefault(sp => sp.MaSanPham == item.MaSanPham && sp.MaSize == item.MaSize);
                if (sizeSanPham != null)
                {
                    sizeSanPham.SoLuong += item.SoLuong;
                }
            }
            db.SubmitChanges();

            TempData["Message"] = "Hủy đơn hàng thành công!";
            return RedirectToAction("LichSuMuaHang");
        }


    }
}