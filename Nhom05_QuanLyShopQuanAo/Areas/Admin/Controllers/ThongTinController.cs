using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class ThongTinController : Controller
    {
        // GET: Admin/ThongTin
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult ThongTinAdmin()
        {
            var user = (UserAccount)Session["quanly"];
            if (user == null)
            {
                return RedirectToAction("Login_Admin", "DangNhapAdmin");
            }

            var ad = db.NhanViens.FirstOrDefault(kh => kh.TenDangNhap == user.TenDangNhap);
            return View(ad);
        }


        [HttpPost]
        public ActionResult CapNhatThongTin(NhanVien model)
        {
            var user = (UserAccount)Session["quanly"];
            if (user == null)
            {
                ViewBag.Message = "Cập nhật thất bại!";
                return RedirectToAction("Login_Admin", "DangNhapAdmin");
            }

            var ad = db.NhanViens.FirstOrDefault(kh => kh.TenDangNhap == user.TenDangNhap);
            if (ad != null)
            {
                ad.Ho = model.Ho;
                ad.Ten = model.Ten;
                ad.GioiTinh = model.GioiTinh;
                ad.DienThoai = model.DienThoai;
                ad.Email = model.Email;

                db.SubmitChanges();
                ViewBag.Message = "Cập nhật thành công!";
            }
            else
            {
                ViewBag.Message = "Cập nhật thất bại!";
            }

            return View("ThongTinAdmin", ad);
        }




    }
}