using Microsoft.AspNetCore.Mvc;
using thuchanh1.Repository;

namespace thuchanh1.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaispRespository _loaispRespository;
        public LoaiSpMenuViewComponent(ILoaispRespository LoaispRespository)
        {
            _loaispRespository = LoaispRespository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaispRespository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
