using thuchanh1.Models;

namespace thuchanh1.Repository
{
    public interface ILoaispRespository
    {
        TLoaiSp Add( TLoaiSp loaiSp);
        TLoaiSp Update( TLoaiSp loaiSp );
        TLoaiSp Delete( String maloaiSp );
        TLoaiSp GetLoaiSp(String maloaiSp );

        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
