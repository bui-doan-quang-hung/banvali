using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using thuchanh1.Models;
using thuchanh1.Models.Authentication;
using thuchanh1.ViewModels;
using X.PagedList;

namespace thuchanh1.Controllers
{
    public class HomeController : Controller { 
    
        QuanlibanvaliContext db = new QuanlibanvaliContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().OrderBy(x=>x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(lst);
        }

/*        public IActionResult loaditem(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(lst);
        }*/

        public IActionResult SanPhamTheoLoai( String maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().Where(x=>x.MaLoai==maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }

        public IActionResult ChiTietSanPham( String maSp) {
            var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp==maSp);
            var anhsanpham = db.TAnhSps.Where(x=>x.MaSp==maSp).ToList();
            ViewBag.anhsanpham=anhsanpham;
            return View(sanpham);
        }

        public IActionResult ProductDetail(string maSp)
        {
            var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhsanpham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSp = sanpham,
                anhSps = anhsanpham,
            };
            return View(homeProductDetailViewModel);
        }
        [HttpPost]
        public List<Object> GetChartData()
        {
            List<Object> data = new List<Object>();

            List<string> y = db.TLoaiSps.Select(p => p.Loai).ToList();
            data.Add(y);
/*            List<int?> x = _context.Transactions.Select(p => p.Amount).ToList();
            data.Add(x);*/
            return data;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}