using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom05_QuanLyShopQuanAo.Models;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/NhanVien
        // Khởi tạo data context từ file .dbml
        private ShopQuanAoDataContext db = new ShopQuanAoDataContext();

        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.ToList();
            return View(nhanViens);
        }

        // GET: Admin/NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tài khoản đã tồn tại trong UserAccount chưa
                var existingNhanVien = db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == nhanVien.TenDangNhap);
                if (existingNhanVien != null)
                {
                    // Sử dụng ViewBag để lưu thông báo lỗi nếu tên đăng nhập đã tồn tại
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.";
                    return View(nhanVien);
                }


                // Kiểm tra xem email đã tồn tại trong bảng NhanVien chưa
                var existingEmail = db.NhanViens.FirstOrDefault(nv => nv.Email == nhanVien.Email);
                if (existingEmail != null)
                {
                    ViewBag.ErrorMessage = "Email này đã được sử dụng. Vui lòng chọn email khác.";
                    return View(nhanVien);
                }

                // Thêm tài khoản vào bảng UserAccount trước
                var existingUser = db.UserAccounts.FirstOrDefault(u => u.TenDangNhap == nhanVien.TenDangNhap);
                if (existingUser == null)
                {
                    UserAccount newUser = new UserAccount
                    {
                        TenDangNhap = nhanVien.TenDangNhap,
                        MatKhau = "default_password", // Bạn có thể đặt một mật khẩu mặc định
                        ChucVu = "Nhân viên"
                    };


                    db.UserAccounts.InsertOnSubmit(newUser);
                    db.SubmitChanges();
                }

                if (nhanVien.ChucVu == null)
                {
                    nhanVien.ChucVu = "Nhân viên";
                }

                // Thêm nhân viên vào bảng NhanVien
                db.NhanViens.InsertOnSubmit(nhanVien);
                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }


        // GET: Admin/NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                var existingNhanVien = db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == nhanVien.TenDangNhap);
                if (existingNhanVien != null)
                {
                    existingNhanVien.Ho = nhanVien.Ho;
                    existingNhanVien.Ten = nhanVien.Ten;
                    existingNhanVien.GioiTinh = nhanVien.GioiTinh;
                    existingNhanVien.Email = nhanVien.Email;
                    existingNhanVien.DienThoai = nhanVien.DienThoai;
                    existingNhanVien.ChucVu = nhanVien.ChucVu;

                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(nhanVien);
        }


        // GET: Admin/NhanVien/Details/5
        public ActionResult Details(string id)
        {
            var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Tìm nhân viên cần xóa
            var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == id);
            if (nhanVien != null)
            {
                // Xóa tài khoản tương ứng trong bảng UserAccount (nếu có ràng buộc khóa ngoại)
                var userAccount = db.UserAccounts.FirstOrDefault(ua => ua.TenDangNhap == id);
                if (userAccount != null)
                {
                    db.UserAccounts.DeleteOnSubmit(userAccount);
                }

                // Sau khi xóa UserAccount, xóa bản ghi trong bảng NhanVien
                db.NhanViens.DeleteOnSubmit(nhanVien);
                db.SubmitChanges();
            }
            return RedirectToAction("Index");
        }





    }
}