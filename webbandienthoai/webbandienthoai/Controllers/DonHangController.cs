using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webbandienthoai.Models;

namespace webbandienthoai.Controllers
{
    public class DonHangController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: DonHang
        // Hiển thị danh sách đơn hàng
        public ActionResult Index()
        {
            //Kiểm tra đang đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            NguoiDung kh = (NguoiDung)Session["use"];
            int maND = kh.MaNguoiDung;
            var donhangs = db.Donhangs.Include(d => d.Nguoidung).Where(d => d.MaNguoidung == maND);
            return View(donhangs.ToList());
        }


    }
}
