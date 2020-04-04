using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Entities
{
    public class TblSepetUrunleri
    {
        public int Id { get; set; }

        public TblUrunler Urun { get; set; }
        public int? UrunId { get; set; } = null;

        public TblSepet Sepet { get; set; }
        public int? SepetId { get; set; } = null;

        public int? Miktar { get; set; } = null;
    }
}
