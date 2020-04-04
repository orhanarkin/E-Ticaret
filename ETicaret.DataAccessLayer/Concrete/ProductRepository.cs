using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ETicaret.DataAccessLayer.Concrete
{
    public class ProductRepository : GenericRepository<TblUrunler, ETicaretContext>, IProductRepository
    {
        public int GetCountByCategory(string category)
        {
            using (var ctx = new ETicaretContext())
            {
                var products = ctx.TblUrunler.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.UrunKategori)
                                .ThenInclude(i => i.Kategori)
                                .Where(i => i.UrunKategori.Any(a => a.Kategori.KategoriAdi.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }

        public IEnumerable<TblUrunler> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public TblUrunler GetProductDetails(int id)
        {
            using (var ctx = new ETicaretContext())
            {
                return ctx.TblUrunler
                    .Where(i => i.Id == id)
                    .Include(i => i.UrunKategori)
                    .ThenInclude(i => i.Kategori)
                    .FirstOrDefault();
            }
        }

        public List<TblUrunler> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var ctx = new ETicaretContext())
            {
                var products = ctx.TblUrunler.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.UrunKategori)
                                .ThenInclude(i => i.Kategori)
                                .Where(i => i.UrunKategori.Any(a => a.Kategori.KategoriAdi.ToLower() == category.ToLower()));
                }
                return products.Skip((page-1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
