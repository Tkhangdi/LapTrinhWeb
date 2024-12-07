using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class QLSPController : Controller
    {
        // GET: Admin/QLSP
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult HienThiSanPham()
        {
            var list = db.SanPhams.ToList();
            return View(list);
        }

        //Tạo mã tự động
        private string GenerateMaSanPham()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd"); // Phần ngày hiện tại, định dạng "yyyyMMdd"
            string prefix = "SP" + datePart; // Tiền tố mã sản phẩm
            int lastNumber = 1; // Số thứ tự mặc định

            // Tìm mã sản phẩm có số thứ tự cao nhất trong ngày hiện tại
            var lastProduct = db.SanPhams
                .Where(sp => sp.MaSanPham.StartsWith(prefix))
                .OrderByDescending(sp => sp.MaSanPham)
                .FirstOrDefault();

            if (lastProduct != null)
            {
                // Lấy số thứ tự cuối cùng từ mã sản phẩm và tăng lên 1
                string lastCode = lastProduct.MaSanPham;
                lastNumber = int.Parse(lastCode.Substring(prefix.Length)) + 1;
            }

            // Sinh mã mới với hai chữ số
            return prefix + lastNumber.ToString();
        }





        // Thêm mới sản phẩm
        public ActionResult TaoSP()
        {
            var genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "Nam" },
                new SelectListItem { Text = "Nữ", Value = "Nữ" }
            };

            var danhmuc = db.DanhMucs
                .Select(x => new SelectListItem()
                {
                    Value = x.MaDanhMuc.ToString(),
                    Text = x.TenDanhMuc,
                }).ToList();

            var thuonghieu = db.ThuongHieus
                .Select(x => new SelectListItem()
                {
                    Value = x.MaThuongHieu.ToString(),
                    Text = x.TenThuongHieu,
                }).ToList();

            ViewBag.Genders = genders;
            ViewBag.Danhmuc = danhmuc;
            ViewBag.Thuonghieu = thuonghieu;

            // Tự động tạo mã sản phẩm
            ViewBag.GeneratedMaSanPham = GenerateMaSanPham();

            return View();
        }



        //[HttpPost]
        //public ActionResult TaoSP(SanPham sp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //           
        //            var existingProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == sp.MaSanPham);

        //            if (existingProduct != null)
        //            {
        //                ModelState.AddModelError("MaSanPham", "Mã sản phẩm đã tồn tại. Vui lòng chọn mã sản phẩm khác.");

        //                // Khởi tạo lại ViewBag khi có lỗi để tránh lỗi dropdown
        //                ViewBag.Genders = new List<SelectListItem>
        //                {
        //                    new SelectListItem { Text = "Nam", Value = "Nam" },
        //                    new SelectListItem { Text = "Nữ", Value = "Nữ" }
        //                };
        //                ViewBag.Danhmuc = db.DanhMucs.Select(x => new SelectListItem { Value = x.MaDanhMuc.ToString(), Text = x.TenDanhMuc }).ToList();
        //                ViewBag.Thuonghieu = db.ThuongHieus.Select(x => new SelectListItem { Value = x.MaThuongHieu.ToString(), Text = x.TenThuongHieu }).ToList();

        //                return View(sp); // Trả về lại View cùng với thông báo lỗi
        //            }

        //            // Thêm sản phẩm mới vào bảng SanPhams
        //            db.SanPhams.InsertOnSubmit(sp);
        //            db.SubmitChanges();

        //            return RedirectToAction("HienThiSanPham", "QLSP");
        //        }
        //        catch
        //        {
        //            ModelState.AddModelError("", "Có lỗi xảy ra khi thêm sản phẩm.");
        //        }
        //    }

        //    // Khởi tạo lại ViewBag khi ModelState không hợp lệ
        //    ViewBag.Genders = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Nam", Value = "Nam" },
        //        new SelectListItem { Text = "Nữ", Value = "Nữ" }
        //    };
        //    ViewBag.Danhmuc = db.DanhMucs.Select(x => new SelectListItem { Value = x.MaDanhMuc.ToString(), Text = x.TenDanhMuc }).ToList();
        //    ViewBag.Thuonghieu = db.ThuongHieus.Select(x => new SelectListItem { Value = x.MaThuongHieu.ToString(), Text = x.TenThuongHieu }).ToList();

        //    return View(sp); // Trả về lại View cùng với thông báo lỗi
        //}

        [HttpPost]
        public ActionResult TaoSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    sp.MaSanPham = GenerateMaSanPham(); // Tạo mã sản phẩm tự động

                    db.SanPhams.InsertOnSubmit(sp);
                    db.SubmitChanges();

                    return RedirectToAction("HienThiSanPham", "QLSP");
                }
                catch
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi thêm sản phẩm.");
                }
            }

            ViewBag.Genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "Nam" },
                new SelectListItem { Text = "Nữ", Value = "Nữ" }
            };
            ViewBag.Danhmuc = db.DanhMucs.Select(x => new SelectListItem { Value = x.MaDanhMuc.ToString(), Text = x.TenDanhMuc }).ToList();
            ViewBag.Thuonghieu = db.ThuongHieus.Select(x => new SelectListItem { Value = x.MaThuongHieu.ToString(), Text = x.TenThuongHieu }).ToList();

            return View(sp);
        }





        public ActionResult CapNhatSP(string MaSanPham)
        {
            var sp = db.SanPhams.FirstOrDefault(p => p.MaSanPham == MaSanPham);
            if (sp == null)
            {
                return HttpNotFound();
            }
            var genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nam", Value = "Nam" },
                new SelectListItem { Text = "Nữ", Value = "Nữ" }
            };

            var danhmuc = db.DanhMucs
                .Select(x => new SelectListItem()
                {
                    Value = x.MaDanhMuc.ToString(),
                    Text = x.TenDanhMuc,
                }).ToList();

            var thuonghieu = db.ThuongHieus
                .Select(x => new SelectListItem()
                {
                    Value = x.MaThuongHieu.ToString(),
                    Text = x.TenThuongHieu,
                }).ToList();

            ViewBag.Genders = genders;
            ViewBag.Danhmuc = danhmuc;
            ViewBag.Thuonghieu = thuonghieu;

            return View(sp);
        }

        [HttpPost]
        public ActionResult CapNhatSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = db.SanPhams.FirstOrDefault(p => p.MaSanPham == sp.MaSanPham);
                    if (existingProduct != null)
                    {
                        // Cập nhật các thuộc tính của existingEmployee từ employee
                        existingProduct.TenSanPham = sp.TenSanPham;
                        existingProduct.GioiTinh = sp.GioiTinh;
                        existingProduct.MaDanhMuc = sp.MaDanhMuc;
                        existingProduct.MaThuongHieu = sp.MaThuongHieu;
                        existingProduct.Gia = sp.Gia;
                        existingProduct.MoTa = sp.MoTa;

                        db.SubmitChanges();

                        return RedirectToAction("HienThiSanPham", "QLSP");
                    }
                }
                catch
                {
                    ModelState.AddModelError("MaSanPham", "Đã xảy ra lỗi!!!");
                }
            }
            var genders = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "Nam",Text = "Nam"},
                new SelectListItem(){Value = "Nữ",Text = "Nữ"}
            };

            var danhmuc = db.DanhMucs
                .Select(x => new SelectListItem()
                {
                    Value = x.MaDanhMuc.ToString(),
                    Text = x.TenDanhMuc,
                }).ToList();

            var thuonghieu = db.ThuongHieus
                .Select(x => new SelectListItem()
                {
                    Value = x.MaThuongHieu.ToString(),
                    Text = x.TenThuongHieu,
                }).ToList();


            ViewBag.Genders = genders;
            ViewBag.Danhmuc = danhmuc;
            ViewBag.Thuonghieu = thuonghieu;
            return View(sp);
        }

        public ActionResult XoaSanPham(string MaSanPham)
        {
            var sp = db.SanPhams.FirstOrDefault(p => p.MaSanPham == MaSanPham);
            if (sp == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Sử dụng DeleteOnSubmit để đánh dấu sản phẩm cần xóa
                db.SanPhams.DeleteOnSubmit(sp);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Chuyển hướng đến trang danh sách sản phẩm
                return RedirectToAction("HienThiSanPham", "QLSP");
            }
            catch
            {
                ModelState.AddModelError("MaSanPham", "Đã xảy ra lỗi khi xóa sản phẩm.");
                return View(sp); // Nếu lỗi, hiển thị lại thông tin sản phẩm
            }
        }
    }
}