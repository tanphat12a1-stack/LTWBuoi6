﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb06_Bai01.Models
{
	public class SanPham
	{
		public string MaSP { get; set; }
		public string TenSP { get; set; }
		public string MaLoai { get; set; }
		public string MaNSX { get; set; }
		public decimal Gia { get; set; }
		public string GhiChu { get; set; }
		public string Hinh { get; set; }
	}
}