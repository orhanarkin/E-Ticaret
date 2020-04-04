using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class ProductDetailsModel
    {
        public TblUrunler Urun { get; set; }
        public List<TblKategoriler> Kategoriler { get; set; }
    }
}
