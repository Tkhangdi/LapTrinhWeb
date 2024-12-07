using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom05_QuanLyShopQuanAo.Areas.Admin.Data
{
    public class CTDH
    {
        public string MaCT { get; set; }
        public string MaSP { get; set; }
        public string Size { get; set; }
        public int? SL { get; set; }
        public decimal? Gia { get; set; }
        public CTDH(string maCT, string maSP, string size, int? sL, decimal? gia)
        {
            MaCT = maCT;
            MaSP = maSP;
            Size = size;
            SL = sL;
            Gia = gia;
        }
    }
}