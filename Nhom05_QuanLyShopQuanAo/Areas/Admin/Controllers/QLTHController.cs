using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class QLTHController : Controller
    {
        // GET: Admin/QLTH
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult HienThiThuongHieu()
        {
            var list = db.ThuongHieus.ToList();
            return View(list);
        }


        //tạo thương hiệu mới
        public ActionResult TaoTH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoTH(ThuongHieu th)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem MaThuongHieu đã tồn tại trong cơ sở dữ liệu chưa
                    var existingTH = db.ThuongHieus.FirstOrDefault(p => p.MaThuongHieu == th.MaThuongHieu);

                    if (existingTH != null)
                    {
                        ModelState.AddModelError("MaThuongHieu", "MaThuongHieu đã tồn tại. Vui lòng chọn MaThuongHieu khác.");
                        return View(th);
                    }

                    // Thêm sản phẩm mới vào bảng ThuongHieus
                    db.ThuongHieus.InsertOnSubmit(th);
                    db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                    return RedirectToAction("HienThiThuongHieu", "QLTH");
                }
                catch
                {
                    // Nếu có lỗi trong quá trình lưu, thêm lỗi vào ModelState
                    ModelState.AddModelError("", "Có lỗi xảy ra khi thêm sản phẩm.");
                }
            }

            return View(th);
        }

        public ActionResult CapNhatTH(string MaThuongHieu)
        {
            var th = db.ThuongHieus.FirstOrDefault(p => p.MaThuongHieu == MaThuongHieu);
            if (th == null)
            {
                return HttpNotFound();
            }

            return View(th);
        }

        [HttpPost]
        public ActionResult CapNhatTH(ThuongHieu th)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingTH = db.ThuongHieus.FirstOrDefault(p => p.MaThuongHieu == th.MaThuongHieu);
                    if (existingTH != null)
                    {
                        // Cập nhật các thuộc tính của existingTH từ danh mục
                        existingTH.TenThuongHieu = th.TenThuongHieu;

                        db.SubmitChanges();

                        return RedirectToAction("HienThiThuongHieu", "QLTH");
                    }
                }
                catch
                {
                    ModelState.AddModelError("MaThuongHieu", "Đã xảy ra lỗi!!!");
                }
            }

            return View(th);
        }
        public ActionResult XoaTH(string MaThuongHieu)
        {
            var th = db.ThuongHieus.FirstOrDefault(p => p.MaThuongHieu == MaThuongHieu);
            if (th == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Sử dụng DeleteOnSubmit để đánh dấu sản phẩm cần xóa
                db.ThuongHieus.DeleteOnSubmit(th);

                db.SubmitChanges();

                return RedirectToAction("HienThiThuongHieu", "QLTH");
            }
            catch
            {
                ModelState.AddModelError("MaThuongHieu", "Đã xảy ra lỗi khi xóa danh mục.");
                return View(th); // Nếu lỗi, hiển thị lại thông tin sản phẩm
            }
        }
    }
}