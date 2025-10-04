using LTWeb06_Bai01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb06_Bai01.Controllers
{
    public class SanPhamController : Controller
    {
        DuLieu dl = new DuLieu();

        public ActionResult SanPhamTheoLoai(string maloai, string gia)
        {
            var ds = dl.dsSP;

            if (!string.IsNullOrEmpty(maloai))
            {
                ds = ds.Where(sp => sp.MaLoai == maloai).ToList();
            }

            if (!string.IsNullOrEmpty(gia))
            {
                switch (gia)
                {
                    case "0-30000":
                        ds = ds.Where(sp => sp.Gia <= 30000).ToList();
                        break;
                    case "30000-60000":
                        ds = ds.Where(sp => sp.Gia > 30000 && sp.Gia <= 60000).ToList();
                        break;
                    case "60000-100000":
                        ds = ds.Where(sp => sp.Gia > 60000 && sp.Gia <= 100000).ToList();
                        break;
                    case "100000":
                        ds = ds.Where(sp => sp.Gia > 100000).ToList();
                        break;
                }
            }

            ViewBag.Loai = dl.dsLoai;
            return View(ds);
        }

        public ActionResult ChiTietSanPham(string masp)
        {
            var sp = dl.dsSP.FirstOrDefault(s => s.MaSP == masp);
            if (sp == null)
            {
                return HttpNotFound();
            }

            ViewBag.Loai = dl.dsLoai;
            return View(sp);
        }
    }
}