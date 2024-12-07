using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Nhom05_QuanLyShopQuanAo.Models;

namespace Nhom05_QuanLyShopQuanAo.Controllers
{
    public class DangNhapController : Controller
    {
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();

        public ActionResult XacNhanRole()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["khach"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login_NguoiDung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_NguoiDung(string username, string password)
        {
            var user = db.UserAccounts.FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);

            if (user != null)
            {
                if (user.ChucVu == "Khách hàng")
                {
                    Session["khach"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Bạn không được phép đăng nhập với vai trò quản trị !";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Username hoặc Password không đúng.";
                return View();
            }
        }


        public ActionResult DangKy_NguoiDung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy_NguoiDung(string tendangnhap,string matkhau,string ho,string ten, string gioitinh,string register_email, string sodienthoai, string diachi, string thanhpho,string tinh)
        {
            var existingUser = db.UserAccounts.FirstOrDefault(u => u.TenDangNhap == tendangnhap);
            if (existingUser != null)
            {
                ViewBag.RegisterErrorMessage = "Username đã tồn tại. Vui lòng chọn username khác.";
                return View("DangKy_NguoiDung");
            }

            var existingEmail = db.KhachHangs.FirstOrDefault(kh => kh.Email == register_email);
            if (existingEmail != null)
            {
                ViewBag.RegisterErrorMessage = "Email đã được sử dụng. Vui lòng sử dụng email khác.";
                return View("DangKy_NguoiDung");
            }

            UserAccount newUser = new UserAccount
            {
                TenDangNhap = tendangnhap,
                MatKhau = matkhau,
                ChucVu = "Khách hàng"
            };

            db.UserAccounts.InsertOnSubmit(newUser);
            db.SubmitChanges();

            KhachHang newKhachHang = new KhachHang
            {
                TenDangNhap = tendangnhap,
                Ho = ho,
                Ten = ten,
                GioiTinh = gioitinh,
                Email = register_email,
                DienThoai = sodienthoai,
                DiaChi = diachi,
                ChucVu = "Khách hàng"
            };

            db.KhachHangs.InsertOnSubmit(newKhachHang);
            db.SubmitChanges();

            return RedirectToAction("Login_NguoiDung", "DangNhap");

        }
        

        public ActionResult TimKiem(string search)
        {
            if (search == "")
            {
                return View();
            }
            List<SanPham> lstSP = db.SanPhams.Where(t => t.MoTa.Contains(search) || t.TenSanPham.Contains(search)).ToList();
            return View(lstSP);
        }



    }
}