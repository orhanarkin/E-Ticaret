using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ETicaret.DataAccessLayer.Abstract
{
    public interface IProductRepository : IGenericRepository<TblUrunler>
    {
        IEnumerable<TblUrunler> GetPopularProducts();
        List<TblUrunler> GetProductsByCategory(string category, int page, int pageSize);
        TblUrunler GetProductDetails(int id);
        int GetCountByCategory(string category);
    }
}
