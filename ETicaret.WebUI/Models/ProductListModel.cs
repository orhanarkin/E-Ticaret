using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class ProductListModel
    {
        public List<TblUrunler> Products { get; set; }
        public PageInfo PageModel { get; set; }
    }

    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }        
}
