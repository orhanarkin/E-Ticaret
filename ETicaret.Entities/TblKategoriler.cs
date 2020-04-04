using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Entities
{
    public class TblKategoriler
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; } = null;
        public int? UstId { get; set; } = null;
        public string KisaKod { get; set; } = null;
        public string Aciklama { get; set; } = null;
        public string Url { get; set; } = null;
        public DateTime? Tarih { get; set; } = null;
        public string MetaKeywords { get; set; } = null;
        public string MetaDescription { get; set; } = null;
        public int? GoogleKategorisi { get; set; } = null;
        public string Resim { get; set; } = null;
        public string Aktif { get; set; } = null;
        public int? sira { get; set; } = null;
        public List<TblUrunKategori> UrunKategori { get; set; }
    }
}
