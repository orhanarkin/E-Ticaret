using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ETicaret.Business.Abstract;
using ETicaret.Entities;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            return View(new ProductListModel() 
            { 
                Products = _productService.GetAll()
            });
        }
        public IActionResult CreateProduct()
        {
            ViewBag.Kategoriler = _categoryService.GetAll();
            return View(new ProductModel());
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new TblUrunler()
                {
                    UrunAdi = model.UrunAdi,
                    Fiyat = model.Fiyat,
                    KategoriId = model.KategoriId,
                    MarkaId = model.MarkaId,
                    KisaAciklama = model.KisaAciklama,
                    Aciklama = model.Aciklama,
                    Resim1 = model.Resim1
                };

                _productService.Create(entity);
                return RedirectToAction("ProductList", "Admin");
            }
            return View(model);
        }
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                UrunAdi = entity.UrunAdi,
                Resim1 = entity.Resim1,
                Fiyat = entity.Fiyat,
                KategoriId = entity.KategoriId,
                MarkaId = entity.MarkaId,
                KisaAciklama = entity.KisaAciklama,
                Aciklama = entity.Aciklama
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.UrunAdi = model.UrunAdi;
                entity.Fiyat = model.Fiyat;
                entity.KisaAciklama = model.KisaAciklama;
                entity.Aciklama = model.Aciklama;
                entity.KategoriId = model.KategoriId;
                entity.MarkaId = model.MarkaId;
                if (file != null)
                {
                    entity.Resim1 = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _productService.Update(entity);
                return RedirectToAction("ProductList", "Admin");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("ProductList","Admin");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            { 
                Categories = _categoryService.GetAll()
            });
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new TblKategoriler()
            {
                KategoriAdi = model.KategoriAdi
            };

            _categoryService.Create(entity);
            return RedirectToAction("CategoryList", "Admin"); ;
        }
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CategoryModel()
            {
                KategoriAdi = entity.KategoriAdi
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.KategoriAdi = model.KategoriAdi;

            _categoryService.Update(entity);
            return RedirectToAction("CategoryList", "Admin");
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList", "Admin");
        }
    }
}