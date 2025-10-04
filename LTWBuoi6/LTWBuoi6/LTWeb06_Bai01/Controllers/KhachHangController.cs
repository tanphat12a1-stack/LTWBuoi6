using LTWeb06_Bai01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb06_Bai01.Controllers
{
    public class KhachHangController : Controller
    {
        DuLieu dl = new DuLieu();
        public ActionResult DangNhap()
        {
            ViewBag.Loai = dl.dsLoai;
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string soDienThoai, string matKhau)
        {
            var kh = dl.dsKH.FirstOrDefault(k => k.SoDienThoai == soDienThoai && k.MatKhau == matKhau);

            if (kh != null)
            {
                Session["KhachHang"] = kh;
                TempData["ThongBao"] = "Đăng nhập thành công!";

                return RedirectToAction("SanPhamTheoLoai", "SanPham");
            }
            else
            {
                ViewBag.Error = "Sai số điện thoại hoặc mật khẩu!";
                ViewBag.Loai = dl.dsLoai;
                return View();
            }
        }

        public ActionResult DangXuat()
        {
            Session["KhachHang"] = null;
            return RedirectToAction("DangNhap");
        }

        public ActionResult LichSuGiaoDich()
        {
            var kh = Session["KhachHang"] as KhachHang;
            if (kh == null)
            {
                return RedirectToAction("DangNhap");
            }

            var dsHD = dl.dsHD.Where(h => h.MaKhachHang == kh.MaKhachHang).ToList();

            ViewBag.ChiTiet = dl.dsCT;
            ViewBag.Loai = dl.dsLoai;

            return View(dsHD);
        }
    }
}