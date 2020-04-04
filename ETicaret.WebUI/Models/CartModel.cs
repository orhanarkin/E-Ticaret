using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public decimal ToplamTutar()
        {
            return Convert.ToDecimal(CartItems.Sum(i => i.Fiyat * i.Miktar));
        }
    }

    public class CartItemModel
    {
        public int SepetUrunleriId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public string Resim1 { get; set; }
        public int? Miktar { get; set; }
    }
}
