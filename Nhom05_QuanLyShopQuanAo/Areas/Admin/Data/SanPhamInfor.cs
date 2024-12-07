using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Data
{
    public class SanPhamInfor
    {
        public String MaSanPham { get; set; }
        public String TenSanPham { get; set; }
        public String DanhMuc { get; set; }
        public int? SoLuong { get; set; }
        public String Size { get; set; }
        public SanPhamInfor(string ma, string ten, string dm, int? sl, string size)
        {
            MaSanPham = ma;
            TenSanPham = ten;
            DanhMuc = dm;
            SoLuong = sl;
            Size = size;
        }
    }
}