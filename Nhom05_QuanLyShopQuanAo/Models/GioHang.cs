using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom05_QuanLyShopQuanAo.Models;

namespace Nhom05_QuanLyShopQuanAo.Models
{
    public class GioHang
    {
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public List<CartItem> lst { get; set; }

        public GioHang()
        {
            lst = new List<CartItem>();
        }

        public bool themCartItem(CartItem sp)
        {
            CartItem x = new CartItem();

            x = lst.FirstOrDefault(t => t.MaSanPham == sp.MaSanPham);
            if(sp == null) { return false; }


            if (x != null)
            {
                x.SoLuong += 1;
                
            }
            else
            {
                lst.Add(sp);
            }

            return true;
        }

        public int SoMatHang()
        {
            return lst.Count();
        }

        public bool xoaCartItem(string id)
        {
            if (id == null)
                return false;
            lst.Remove(lst.FirstOrDefault(t => t.MaSanPham == id));
            return true;
        }

        public bool thayDoiSoLuong(string id, int sl)
        {
            var sp = lst.FirstOrDefault(t => t.MaSanPham == id);
            if (sp == null) return false;
            sp.SoLuong = sl;
            return true;
        }

        
        public int tinhSoLuong()
        {
            return lst.Sum(t => t.SoLuong);
        }

        
    }
}