using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Entities
{
    public class TblUrunler
    {
        public int Id { get; set; }
        public int? KategoriId { get; set; } = null;
        public int? MarkaId { get; set; } = null;
        public string UrunAdi { get; set; } = null;
        public string KisaAciklama { get; set; } = null;
        public string Aciklama { get; set; } = null;
        public string Kod { get; set; } = null;
        public string Barkod { get; set; } = null;
        public string Url { get; set; } = null;
        public string Resim1 { get; set; } = null;
        public string Resim2 { get; set; } = null;
        public string Resim3 { get; set; } = null;
        public string Resim4 { get; set; } = null;
        public string Resim5 { get; set; } = null;
        public decimal? Fiyat { get; set; } = null;
        public decimal? IndirimliFiyat { get; set; } = null;
        public bool? IndirimliMi { get; set; } = null;
        public decimal? AlisFiyati { get; set; } = null;
        public int? Kdv { get; set; } = null;
        public bool? KdvDahilMi { get; set; } = null;
        public int? BirimId { get; set; } = null;
        public string ParaBirimi { get; set; } = null;
        public int? Stok { get; set; } = null;
        public int? Desi { get; set; } = null;
        public string Video { get; set; } = null;
        public string Meta { get; set; } = null;
        public int? AnaUrunId { get; set; } = null;
        public bool? GarantiSuresi { get; set; } = null;
        public bool? Goruntuleme { get; set; } = null;
        public bool? HizliKargo { get; set; } = null;
        public bool? UcretsizKargo { get; set; } = null;
        public bool? AyniGunTeslim { get; set; } = null;
        public bool? SinirliSayida { get; set; } = null;
        public bool? OzelUrun { get; set; } = null;
        public bool? FirsatUrunu { get; set; } = null;
        public bool? Vitrin { get; set; } = null;
        public string Etiketler { get; set; } = null;
        public decimal? ToptanFiyati { get; set; } = null;
        public decimal? PerakendeFiyati { get; set; } = null;
        public List<TblUrunKategori> UrunKategori { get; set; }
    }
}
