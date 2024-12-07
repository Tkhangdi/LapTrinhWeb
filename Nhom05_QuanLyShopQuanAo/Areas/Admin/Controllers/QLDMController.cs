using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class QLDMController : Controller
    {
        // GET: Admin/QLDM
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult HienThiDanhMuc()
        {
            var list = db.DanhMucs.ToList();
            return View(list);
        }


        //tạo danh mục mới
        public ActionResult TaoDM()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoDM(DanhMuc dm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem MaDanhMuc đã tồn tại trong cơ sở dữ liệu chưa
                    var existingProduct = db.DanhMucs.FirstOrDefault(p => p.MaDanhMuc == dm.MaDanhMuc);

                    if (existingProduct != null)
                    {
                        ModelState.AddModelError("MaDanhMuc", "MaDanhMuc đã tồn tại. Vui lòng chọn MaDanhMuc khác.");
                        return View(dm);
                    }

                    // Thêm sản phẩm mới vào bảng DanhMucs
                    db.DanhMucs.InsertOnSubmit(dm);
                    db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                    return RedirectToAction("HienThiDanhMuc", "QLDM");
                }
                catch
                {
                    // Nếu có lỗi trong quá trình lưu, thêm lỗi vào ModelState
                    ModelState.AddModelError("", "Có lỗi xảy ra khi thêm sản phẩm.");
                }
            }

            return View(dm);
        }

        public ActionResult CapNhatDM(string MaDanhMuc)
        {
            var dm = db.DanhMucs.FirstOrDefault(p => p.MaDanhMuc == MaDanhMuc);
            if (dm == null)
            {
                return HttpNotFound();
            }

            return View(dm);
        }

        [HttpPost]
        public ActionResult CapNhatDM(DanhMuc dm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingDM = db.DanhMucs.FirstOrDefault(p => p.MaDanhMuc == dm.MaDanhMuc);
                    if (existingDM != null)
                    {
                        // Cập nhật các thuộc tính của existingDM từ danh mục
                        existingDM.TenDanhMuc = dm.TenDanhMuc;

                        db.SubmitChanges();

                        return RedirectToAction("HienThiDanhMuc", "QLDM");
                    }
                }
                catch
                {
                    ModelState.AddModelError("MaDanhMuc", "Đã xảy ra lỗi!!!");
                }
            }

            return View(dm);
        }
        public ActionResult XoaDM(string MaDanhMuc)
        {
            var dm = db.DanhMucs.FirstOrDefault(p => p.MaDanhMuc == MaDanhMuc);
            if (dm == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Sử dụng DeleteOnSubmit để đánh dấu sản phẩm cần xóa
                db.DanhMucs.DeleteOnSubmit(dm);

                db.SubmitChanges();

                return RedirectToAction("HienThiDanhMuc", "QLDM");
            }
            catch
            {
                ModelState.AddModelError("MaDanhMuc", "Đã xảy ra lỗi khi xóa danh mục.");
                return View(dm); // Nếu lỗi, hiển thị lại thông tin sản phẩm
            }
        }
    }
}