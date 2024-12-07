using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom05_QuanLyShopQuanAo.Models;

namespace Nhom05_QuanLyShopQuanAo.Controllers
{
    public class DangNhapAdminController : Controller
    {
        // GET: DangNhapAdmin
        private ShopQuanAoDataContext db = new ShopQuanAoDataContext();

        public ActionResult Logout()
        {
            Session["quanly"] = null;

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Login_Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_Admin(string username, string password)
        {
            var user = db.UserAccounts.FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);

            if (user != null)
            {
                if (user.ChucVu == "Nhân viên")
                {
                    Session["quanly"] = user;
                    return Redirect("~/Admin/Home/Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Tài khoản không có quyền truy cập với vai trò này!";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Username hoặc Password không đúng!";
                return View();
            }
        }
    }
}