using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaret.Business.Abstract;
using ETicaret.Entities;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ProductListModel()
            { 
                Products = _productService.GetAll()
            });
        }
        public IActionResult List(string category, int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                PageModel = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            });
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TblUrunler urun = _productService.GetById((int)id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }
    }
}