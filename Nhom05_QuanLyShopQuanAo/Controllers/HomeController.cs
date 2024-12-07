using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_QuanLyShopQuanAo.Controllers
{
    public class HomeController : Controller
    {
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();

        // GET: Home
        public ActionResult Index()
        {

            var allProducts = db.SanPhams.ToList();

            // Tính số lượng đã bán
            var soLuongDaBan = db.ChiTietDonHangs
                .GroupBy(c => c.MaSanPham)
                .Select(g => new
                {
                    MaSanPham = g.Key,
                    SoLuongDaBan = g.Sum(x => x.SoLuong)
                }).ToList();

            // Kết hợp số lượng đã bán vào danh sách sản phẩm
            foreach (var product in allProducts)
            {
                var ban = soLuongDaBan.FirstOrDefault(x => x.MaSanPham == product.MaSanPham);
                product.SoLuongDaBan = (int)(ban != null ? ban.SoLuongDaBan : 0);
            }

            // Phân loại sản phẩm theo danh mục
            var tab1Products = allProducts.Where(p => p.MaDanhMuc == "DM01").ToList(); // Áo
            var tab2Products = allProducts.Where(p => p.MaDanhMuc == "DM02").ToList(); // Quần
            var tab3Products = allProducts.Where(p => p.MaDanhMuc == "DM07").ToList(); // Áo khoác
            var tab4Products = allProducts.Where(p => p.MaDanhMuc == "DM10").ToList(); // Đồ thể thao

            // Chọn sản phẩm nổi bật (bán chạy nhất)
            var featuredProducts = allProducts.OrderByDescending(p => p.SoLuongDaBan).Take(5).ToList();

            ViewBag.Tab1Products = tab1Products;
            ViewBag.Tab2Products = tab2Products;
            ViewBag.Tab3Products = tab3Products;
            ViewBag.Tab4Products = tab4Products;
            ViewBag.FeaturedProducts = featuredProducts;

            return View();


        }


        public ActionResult DetailSanPham(string id)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.sizeSP = db.Size_SanPhams.ToList();

            return View(sanPham);
        }


        // GET: Trang liên hệ
        public ActionResult Contact()
        {
            return View(); // Trả về view liên hệ
        }

        [HttpPost]
        public ActionResult SubmitContact(string name, string email, string message)
        {
            // Xử lý dữ liệu từ biểu mẫu liên hệ
            ViewBag.Message = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi sớm nhất.";
            return View("Contact"); // Trả về trang liên hệ với thông báo
        }
    }
}