using Nhom05_QuanLyShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Data
{
    public class DGHang
    {
        public string MaDonHang { get; set; }
        public System.Nullable<System.DateTime> NgayDat { get; set; }
        public decimal TongTien { get; set; }
        public DGHang(string maDonHang, decimal tongTien, DateTime? ngayDat)
        {
            MaDonHang = maDonHang;
            TongTien = tongTien;
            NgayDat = ngayDat;
        }
    }
}