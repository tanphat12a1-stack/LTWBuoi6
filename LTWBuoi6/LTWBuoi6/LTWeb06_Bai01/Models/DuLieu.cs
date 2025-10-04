using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTWeb06_Bai01.Models
{
	public class DuLieu
	{
		static string strcon = @"Data Source=A110PC11\CSSQL08;Database=QL_SanPham;User ID=sa;Password=123";

		SqlConnection con = new SqlConnection(strcon);

        public List<NhaSanXuat> dsNSX = new List<NhaSanXuat>();
        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSP = new List<SanPham>();
        public List<KhachHang> dsKH = new List<KhachHang>();
        public List<HoaDon> dsHD = new List<HoaDon>();
        public List<ChiTiet> dsCT = new List<ChiTiet>();

        public void ThietLap_NSX()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblNhaSanXuat", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var nsx = new NhaSanXuat();
                nsx.MaNSX = dr["MaNSX"].ToString();
                nsx.TenNSX = dr["TenNSX"].ToString();

                dsNSX.Add(nsx);
            }
        }

        public void ThietLap_Loai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblLoai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var loai = new Loai();
                loai.MaLoai = dr["MaLoai"].ToString();
                loai.TenLoai = dr["TenLoai"].ToString();

                dsLoai.Add(loai);
            }
        }

        public void ThietLap_SP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblSanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.MaLoai = dr["MaLoai"].ToString();
                sp.MaNSX = dr["MaNSX"].ToString();
                sp.Gia = (decimal)dr["Gia"];
                sp.GhiChu = dr["GhiChu"].ToString();
                sp.Hinh = dr["Hinh"].ToString();

                dsSP.Add(sp);
            }
        }

        public void ThietLap_KH()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblKhachHang", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var kh = new KhachHang();
                kh.MaKhachHang = dr["MaKhachHang"].ToString();
                kh.TenKhachHang = dr["TenKhachHang"].ToString();
                kh.SoDienThoai = dr["SoDienThoai"].ToString();
                kh.MatKhau = dr["MatKhau"].ToString();

                dsKH.Add(kh);
            }
        }

        public void ThietLap_HD()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblHoaDon", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var hd = new HoaDon();
                hd.MaHoaDon = dr["MaHoaDon"].ToString();
                hd.NgayTao = DateTime.Parse(dr["NgayTao"].ToString());
                hd.MaKhachHang = dr["MaKhachHang"].ToString();

                dsHD.Add(hd);
            }
        }

        public void ThietLap_CT()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblChiTiet", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var ct = new ChiTiet();
                ct.MaHoaDon = dr["MaHoaDon"].ToString();
                ct.MaSP = dr["MaSP"].ToString();
                ct.SoLuong = (int)dr["SoLuong"];

                dsCT.Add(ct);
            }
        }

        public DuLieu()
        {
            ThietLap_NSX();
            ThietLap_Loai();
            ThietLap_SP();
            ThietLap_KH();
            ThietLap_HD();
            ThietLap_CT();
        }
    }
}