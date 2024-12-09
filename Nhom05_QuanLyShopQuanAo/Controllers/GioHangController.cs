using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();

        public ActionResult Index()
        {
            var gioHang = (GioHang)Session["gh"] ?? new GioHang();
            return View(gioHang);
        }

        [HttpPost]
        public ActionResult ThemVaoGioHang(string maSanPham, string sizeSP, int? sl)
        {
            if (string.IsNullOrEmpty(sizeSP) || !sl.HasValue)
            {
                TempData["Error"] = "Vui lòng chọn size và số lượng sản phẩm!";
                return RedirectToAction("DetailSanPham", "Home", new { id = maSanPham });
            }
            GioHang gh;

            if (Session["gh"] == null)
            {
                gh = new GioHang();
                Session["gh"] = gh;
            }
            else
            {
                gh = Session["gh"] as GioHang;

            }
            var sp = db.Size_SanPhams.FirstOrDefault(t => t.MaSanPham == maSanPham && t.MaSize == sizeSP);
            CartItem item = new CartItem();
            item.TenSanPham = sp.SanPham.TenSanPham;
            item.MaSanPham = sp.MaSanPham;
            item.SoLuong = int.Parse(sl.ToString());
            item.Gia = double.Parse(sp.SanPham.Gia.ToString());
            item.MoTa = sp.SanPham.MoTa;
            item.Size = sizeSP;

            gh.themCartItem(item);


            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult XoaKhoiGioHang(string id)
        {
            var gh = Session["gh"] as GioHang;

            bool kt = gh.xoaCartItem(id);

            Session["gh"] = gh;

            return View("Index", gh);
        }


        [HttpPost]
        public ActionResult CapNhatSoLuong(string maSanPham, int soLuong)
        {
            var gh = Session["gh"] as GioHang;

            gh.thayDoiSoLuong(maSanPham, soLuong);

            Session["gh"] = gh;
            return RedirectToAction("Index");
        }

        //public int GetCartItemCount()
        //{
        //    //var gioHang = (List<GioHang>)Session["GioHang"] ?? new List<GioHang>();
        //    //return gioHang.Sum(item => item.SoLuong);
        //}

        //public JsonResult GetCartCount()
        //{
        //    int count = GetCartItemCount();
        //    return Json(count, JsonRequestBehavior.AllowGet);
        //}



        //Tạo mã đơn hàng tự động
        //private string GenerateMaDonHang()
        //{
        //    string datePart = DateTime.Now.ToString("yyyyMMdd"); // Phần ngày hiện tại theo định dạng YYYYMMDD
        //    string prefix = "DH" + datePart; // Tiền tố mã đơn hàng
        //    int lastNumber = 1; // Số thứ tự mặc định

        //    // Tìm mã đơn hàng có số thứ tự cao nhất trong ngày hiện tại
        //    var lastOrder = db.DonHangs
        //        .Where(d => d.MaDonHang.StartsWith(prefix))
        //        .OrderByDescending(d => d.MaDonHang)
        //        .FirstOrDefault();

        //    if (lastOrder != null)
        //    {
        //        // Lấy số thứ tự cuối cùng từ mã đơn hàng và tăng lên 1
        //        string lastCode = lastOrder.MaDonHang;
        //        lastNumber = int.Parse(lastCode.Substring(prefix.Length)) + 1;
        //    }

        //    // Tạo mã đơn hàng mới với hai chữ số cho số thứ tự
        //    return prefix + lastNumber.ToString();
        //}

        private string GenerateMaDonHang()
        {
            string datePart = DateTime.Now.ToString("yyyyMMddHHmmssfff"); // Ngày và thời gian đến mili giây
            return $"DH{datePart}"; // Ví dụ: DH202312091230456
        }




        //Tạo mã chi tiết đơn hàng tự động
        //private string GenerateMaChiTietDonHang()
        //{
        //    string datePart = DateTime.Now.ToString("yyyyMMdd"); // Phần ngày hiện tại theo định dạng YYYYMMDD
        //    string prefix = "CTDH" + datePart; // Tiền tố mã chi tiết đơn hàng
        //    int lastNumber = 1; // Số thứ tự mặc định

        //    // Tìm mã chi tiết đơn hàng có số thứ tự cao nhất trong ngày hiện tại
        //    var lastDetail = db.ChiTietDonHangs
        //        .Where(d => d.MaChiTietDonHang.StartsWith(prefix))
        //        .OrderByDescending(d => d.MaChiTietDonHang)
        //        .FirstOrDefault();

        //    if (lastDetail != null)
        //    {
        //        // Lấy số thứ tự cuối cùng từ mã chi tiết đơn hàng và tăng lên 1
        //        string lastCode = lastDetail.MaChiTietDonHang;
        //        lastNumber = int.Parse(lastCode.Substring(prefix.Length)) + 1;
        //    }

        //    // Tạo mã chi tiết đơn hàng mới với hai chữ số cho số thứ tự
        //    return prefix + lastNumber.ToString();
        //}

        private string GenerateMaChiTietDonHang(string maDonHang, int sequence)
        {
            string prefix = maDonHang; // Dùng mã đơn hàng làm tiền tố
            return $"{prefix}-CT{sequence:D3}"; // Ví dụ: DH20231209-CT001
        }







        //Chức năng Đặt Hàng
        public ActionResult DatHang()
        {
            // Kiểm tra nếu người dùng chưa đăng nhập
            if (Session["khach"] == null)
            {
                TempData["LoginRequired"] = "Bạn chưa đăng nhập !";
                return RedirectToAction("Login_NguoiDung", "DangNhap");
            }

            UserAccount kh = Session["khach"] as UserAccount;
            // Lấy giỏ hàng từ Session
            var gioHang = (GioHang)Session["gh"] ?? new GioHang();
            if (!gioHang.lst.Any())
            {
                TempData["CartEmpty"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToAction("Index");
            }

            //// Kiểm tra số lượng đặt cho từng sản phẩm
            foreach (var item in gioHang.lst)
            {
                if (item.SoLuong <= 0)
                {
                    TempData["StockError"] = "Số lượng đặt phải lớn hơn 0.";
                    return RedirectToAction("Index");
                }
            }

            // Kiểm tra số lượng tồn kho cho từng sản phẩm
            foreach (var item in gioHang.lst)
            {
                var sizeSanPham = db.Size_SanPhams.FirstOrDefault(
                    s => s.MaSanPham == item.MaSanPham && s.MaSize == item.Size
                );

                if (sizeSanPham == null || item.SoLuong > sizeSanPham.SoLuong)
                {
                    TempData["StockError"] = $"Sản phẩm '{item.TenSanPham}' không đủ số lượng trong kho.";
                    return RedirectToAction("Index");
                }
            }


            GioHang gh = Session["gh"] as GioHang;

            DonHang dh = new DonHang();
            dh.MaDonHang = GenerateMaDonHang();
            dh.MaKhachHang = kh.TenDangNhap;
            dh.NgayDat = (DateTime.Now);
            dh.DiaChiGiaoHang = kh.KhachHang.DiaChi;
            dh.TrangThaiDonHang = "Đang xử lý";
            dh.TongTien = decimal.Parse(gh.lst.Sum(t => t.ThanhTien).ToString());
            db.DonHangs.InsertOnSubmit(dh);
            db.SubmitChanges();

            int sequence = 1; // Biến đếm số thứ tự để sinh mã duy nhất

            foreach (var item in gh.lst)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.MaChiTietDonHang = GenerateMaChiTietDonHang(dh.MaDonHang, sequence);
                ct.MaDonHang = dh.MaDonHang;
                ct.MaSanPham = item.MaSanPham;
                ct.SoLuong = item.SoLuong;
                ct.GiaDonVi = decimal.Parse(item.Gia.ToString());
                ct.MaSize = item.Size;
                ct.ThanhTien = decimal.Parse(item.ThanhTien.ToString());
                db.ChiTietDonHangs.InsertOnSubmit(ct);
                db.SubmitChanges();
                sequence++;
            }

            gh.lst.Clear();

            return RedirectToAction("Index", "GioHang");
        }







        //////-----Bổ sung--------/////
        /////////Bổ sung



        [HttpPost]
        public ActionResult DatHang(string phuongThucThanhToan)
        {
            // Kiểm tra nếu người dùng chưa đăng nhập
            if (Session["khach"] == null)
            {
                TempData["LoginRequired"] = "Bạn chưa đăng nhập!";
                return RedirectToAction("Login_NguoiDung", "DangNhap");
            }

            UserAccount kh = Session["khach"] as UserAccount;
            var gioHang = (GioHang)Session["gh"] ?? new GioHang();

            if (!gioHang.lst.Any())
            {
                TempData["CartEmpty"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToAction("Index");
            }

            foreach (var item in gioHang.lst)
            {
                var sizeSanPham = db.Size_SanPhams.FirstOrDefault(
                    s => s.MaSanPham == item.MaSanPham && s.MaSize == item.Size
                );

                if (sizeSanPham == null || item.SoLuong > sizeSanPham.SoLuong)
                {
                    TempData["StockError"] = $"Sản phẩm '{item.TenSanPham}' không đủ số lượng trong kho.";
                    return RedirectToAction("Index");
                }
            }

            DonHang dh = new DonHang
            {
                MaDonHang = GenerateMaDonHang(),
                MaKhachHang = kh.TenDangNhap,
                NgayDat = DateTime.Now,
                DiaChiGiaoHang = kh.KhachHang.DiaChi,
                TrangThaiDonHang = "Đang xử lý",
                TongTien = decimal.Parse(gioHang.lst.Sum(t => t.ThanhTien).ToString()),
                PhuongThucThanhToan = phuongThucThanhToan
            };

            db.DonHangs.InsertOnSubmit(dh);
            db.SubmitChanges();

            int sequence = 1; // Biến đếm số thứ tự để sinh mã duy nhất

            foreach (var item in gioHang.lst)
            {
                ChiTietDonHang ct = new ChiTietDonHang
                {
                    MaChiTietDonHang = GenerateMaChiTietDonHang(dh.MaDonHang, sequence),
                    MaDonHang = dh.MaDonHang,
                    MaSanPham = item.MaSanPham,
                    SoLuong = item.SoLuong,
                    GiaDonVi = decimal.Parse(item.Gia.ToString()),
                    MaSize = item.Size,
                    ThanhTien = decimal.Parse(item.ThanhTien.ToString())
                };

                db.ChiTietDonHangs.InsertOnSubmit(ct);

                sequence++; // Tăng số thứ tự sau mỗi lần thêm
            }



            db.SubmitChanges();
            gioHang.lst.Clear();

            TempData["OrderSuccess"] = "Đặt hàng thành công!";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult XacNhanThanhToan()
        {
            // Kiểm tra nếu người dùng chưa đăng nhập
            if (Session["khach"] == null)
            {
                TempData["LoginRequired"] = "Bạn chưa đăng nhập!";
                return RedirectToAction("Login_NguoiDung", "DangNhap");
            }

            // Lấy giỏ hàng từ Session
            var gioHang = (GioHang)Session["gh"] ?? new GioHang();
            if (!gioHang.lst.Any())
            {
                TempData["CartEmpty"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToAction("Index");
            }

            return View(gioHang);
        }

    }
}