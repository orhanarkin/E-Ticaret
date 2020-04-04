using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class CategoryListViewModel
    {
        public List<TblKategoriler> KategoriList { get; set; }
        public string SelectedCategory { get; set; }
    }
}
