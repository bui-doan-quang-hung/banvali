using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuchanh1.Models;
using thuchanh1.Models.ProductModels;

namespace thuchanh1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QuanlibanvaliContext db = new QuanlibanvaliContext();
        [HttpGet("{maloai}")]
        public List<Product> GetAllProduct(string maloai)
        {
            var sanpham = (from p in db.TDanhMucSps
                           where p.MaLoai == maloai
                           select new Product
                           {
                               Masp = p.MaSp,
                               Tensp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat,
                               GiaLonNhat = p.GiaLonNhat
                           }).ToList();
            return sanpham;
        }

    }
}
