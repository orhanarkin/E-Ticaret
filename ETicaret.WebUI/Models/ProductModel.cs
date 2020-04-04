using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategori boş bırakılamaz")]
        public int? KategoriId { get; set; } = null;
        [Required(ErrorMessage ="Marka boş bırakılamaz")]
        public int? MarkaId { get; set; } = null;
        [Required(ErrorMessage ="Ürün adı boş bırakılamaz")]
        public string UrunAdi { get; set; } = null;
        [Required(ErrorMessage ="Kısa açıklama boş bırakılamaz")]
        public string KisaAciklama { get; set; } = null;
        [Required(ErrorMessage ="Açıklama boş bırakılamaz")]
        public string Aciklama { get; set; } = null;
        public string Kod { get; set; } = null;
        public string Barkod { get; set; } = null;
        [Required(ErrorMessage ="Lütfen bir resim seçiniz")]
        public string Resim1 { get; set; } = null;
        public string Resim2 { get; set; } = null;
        public string Resim3 { get; set; } = null;
        public string Resim4 { get; set; } = null;
        public string Resim5 { get; set; } = null;
        [Required(ErrorMessage ="Fiyat alanı boş bırakılamaz")]
        [Range(1,999999999)]
        public decimal? Fiyat { get; set; } = null;
        public decimal? IndirimliFiyat { get; set; } = null;
        public bool? IndirimliMi { get; set; } = null;
        public decimal? AlisFiyati { get; set; } = null;
        public decimal? Kdv { get; set; } = null;
        public bool? KdvDahilMi { get; set; } = null;
        public int? BirimId { get; set; } = null;
        public string ParaBirimi { get; set; } = null;
        public int? Stok { get; set; } = null;
        public int? Desi { get; set; } = null;
        public string Video { get; set; } = null;
        public int? AnaUrunId { get; set; } = null;
        public string Etiketler { get; set; } = null;
        public decimal? ToptanFiyati { get; set; } = null;
        public decimal? PerakendeFiyati { get; set; } = null;
    }
}
