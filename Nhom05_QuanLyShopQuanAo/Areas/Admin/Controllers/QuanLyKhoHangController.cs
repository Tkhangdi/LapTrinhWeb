using Nhom05_QuanLyShopQuanAo.Areas.Admin.Data;
using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Controllers
{
    public class QuanLyKhoHangController : Controller
    {
        // GET: Admin/QuanLyKhoHang
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();

        [HttpGet]
        public List<SanPhamInfor> loadctsp(string MaDanhMuc)
        {
            var sanPhams = string.IsNullOrEmpty(MaDanhMuc)
                           ? db.SanPhams.ToList()
                           : db.SanPhams.Where(sp => sp.MaDanhMuc == MaDanhMuc).ToList();

            List<SanPhamInfor> spIn4s = new List<SanPhamInfor>();
            var sizes = db.Size_SanPhams.ToList();

            foreach (var sanPham in sanPhams)
            {
                string DM = db.DanhMucs.FirstOrDefault(d => sanPham.MaDanhMuc == d.MaDanhMuc)?.TenDanhMuc ?? "N/A";

                var productSizes = sizes.Where(size => size.MaSanPham == sanPham.MaSanPham);
                if (productSizes.Any())
                {
                    foreach (var size in productSizes)
                    {
                        if (size.SoLuong > 0)
                            spIn4s.Add(new SanPhamInfor(sanPham.MaSanPham, sanPham.TenSanPham, DM, size.SoLuong, size.MaSize));
                    }
                }
                else
                {
                    if (sanPham.Size_SanPhams.Count() > 0)
                        spIn4s.Add(new SanPhamInfor(sanPham.MaSanPham, sanPham.TenSanPham, DM, sanPham.Size_SanPhams.Count(), "Không có size"));
                }
            }
            return spIn4s;
        }

        public List<SanPhamInfor> loadsp(string MaDanhMuc)
        {
            var sanPhams = string.IsNullOrEmpty(MaDanhMuc)
                           ? db.SanPhams.ToList()
                           : db.SanPhams.Where(sp => sp.MaDanhMuc == MaDanhMuc).ToList();

            List<SanPhamInfor> spIn4s = new List<SanPhamInfor>();

            foreach (var sanPham in sanPhams)
            {
                string DM = db.DanhMucs.FirstOrDefault(d => sanPham.MaDanhMuc == d.MaDanhMuc)?.TenDanhMuc ?? "N/A";
                spIn4s.Add(new SanPhamInfor(sanPham.MaSanPham, sanPham.TenSanPham, DM, null, "Không có size"));
            }
            return spIn4s;
        }

        public ActionResult Index()
        {
            var ctsanphams = loadctsp("");
            ViewBag.SoLuong = ctsanphams.Sum(x => x.SoLuong ?? 0);
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            return View(ctsanphams);
        }

        [HttpPost]
        public ActionResult Index(string MaDanhMuc)
        {
            var ctsanphams = loadctsp(MaDanhMuc);
            ViewBag.SoLuong = ctsanphams.Sum(x => x.SoLuong ?? 0);
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            return View(ctsanphams);
        }

        [HttpGet]
        public ActionResult ChonSanPham()
        {
            var ctsanphams = loadsp("");
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            return View(ctsanphams);
        }

        [HttpPost]
        public ActionResult ChonSanPham(string MaDanhMuc)
        {
            var ctsanphams = loadsp(MaDanhMuc);
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            return View(ctsanphams);
        }

        [HttpGet]
        public ActionResult AddKhoHang(string id)
        {
            var sanpham = db.SanPhams.FirstOrDefault(ct => ct.MaSanPham == id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }

            ViewBag.DanhMuc = db.DanhMucs.FirstOrDefault(dm => sanpham.MaDanhMuc == dm.MaDanhMuc)?.TenDanhMuc ?? "N/A";
            ViewBag.Size = db.Sizes.ToList();
            return View(sanpham);
        }

        [HttpPost]
        public ActionResult AddKhoHang(string MaSanPham, string Size, int SoLuong)
        {
            var sanpham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == MaSanPham);
            Session["masp"] = MaSanPham;
            Session["size"] = Size;
            Session["soluong"] = SoLuong;
            return RedirectToAction("HoaDonNhapKho", "QuanLyKhoHang", new { id = MaSanPham });
        }
        // in hóa đơn và lưu vào LichSuNhapHang
        [HttpGet]
        public ActionResult HoaDonNhapKho(string id)
        {
            var sanpham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == id);
            ViewBag.Size = Session["size"].ToString();
            int sl = int.Parse(Session["soluong"].ToString());
            ViewBag.TongGia = sl * sanpham.Gia;
            Session["tong"] = sl * sanpham.Gia;
            ViewBag.SoLuong = sl;
            ViewBag.NgayNhap = DateTime.Now;
            var account = (UserAccount)Session["quanly"];
            var nhanvien = db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == account.TenDangNhap);
            ViewBag.NhanVien = nhanvien.Ho + " " + nhanvien.Ten;
            return View(sanpham);
        }
        [HttpPost]
        public ActionResult HoaDonNhapKho()
        {
            if (ModelState.IsValid)
            {
                var selectedSize = db.Size_SanPhams.FirstOrDefault(s => s.MaSize == Session["size"].ToString() && s.MaSanPham == Session["masp"].ToString());
                string datePart = DateTime.Now.ToString("yyyyMMdd");
                string prefix = "LSNH" + datePart;
                int lastNumber = 1;
                var lastOrder = db.LichSuNhapHangs
                .Where(d => d.MaLSNH.StartsWith(prefix))
                .OrderByDescending(d => d.MaLSNH)
                .FirstOrDefault();
                if (lastOrder != null)
                {
                    string lastCode = lastOrder.MaLSNH;
                    lastNumber = int.Parse(lastCode.Substring(prefix.Length)) + 1;
                }
                if (selectedSize != null)
                {
                    selectedSize.SoLuong += int.Parse(Session["soluong"].ToString());
                }
                else
                {
                    var sanpham = db.SanPhams.FirstOrDefault(sp => Session["masp"].ToString() == sp.MaSanPham);
                    var size = new Size_SanPham
                    {
                        MaSize = Session["size"].ToString(),
                        MaSanPham = sanpham.MaSanPham.ToString(),
                        SoLuong = int.Parse(Session["soluong"].ToString()),
                        TrangThai = "Còn hàng"
                    };
                    db.Size_SanPhams.InsertOnSubmit(size);
                    db.SubmitChanges();
                }
                var nv = (UserAccount)Session["quanly"];
                var nhaphang = new LichSuNhapHang
                {
                    MaLSNH = prefix + lastNumber.ToString(),
                    MaSP = Session["masp"].ToString(),
                    MaSize = Session["size"].ToString(),
                    SoLuong = int.Parse(Session["soluong"].ToString()),
                    NgayNhap = DateTime.Now,
                    TongGia = decimal.Parse(Session["tong"].ToString()),
                    MaNhanVien = nv.TenDangNhap
                };
                db.LichSuNhapHangs.InsertOnSubmit(nhaphang);
                db.SubmitChanges();
                return RedirectToAction("Index", "QuanLyKhoHang");
            }
            return View();
        }
        public ActionResult LichSuNhapHang()
        {
            var lichsu = db.LichSuNhapHangs.ToList();
            return View(lichsu);
        }
    }
}