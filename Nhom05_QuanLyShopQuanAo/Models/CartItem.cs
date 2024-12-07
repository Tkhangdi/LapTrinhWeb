using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom05_QuanLyShopQuanAo.Models
{
    public class CartItem
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public string Size { get; set; }
        
        public double ThanhTien { get { return SoLuong * Gia; } }


        public CartItem(string a, string b, double c, int d, string e,string s)
        {
            MaSanPham = a;
            TenSanPham = b;
            Gia = c;
            SoLuong = d;
            MoTa = e;
            Size = s;
        }

        public CartItem()
        {
        }
    }
}