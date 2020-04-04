using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Entities
{
    public class TblUrunKategori
    {
        public int UrunId { get; set; }
        public TblUrunler Urun { get; set; }
        public int KategoriId { get; set; }
        public TblKategoriler Kategori { get; set; }
    }
}
