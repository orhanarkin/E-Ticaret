using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Abstract
{
    public interface IProductService
    {
        TblUrunler GetById(int id);
        TblUrunler GetProductDetails(int id);
        List<TblUrunler> GetAll();
        List<TblUrunler> GetPopularProducts();
        List<TblUrunler> GetProductsByCategory(string category,int page, int pageSize);
        void Create(TblUrunler entity);
        void Update(TblUrunler entity);
        void Delete(TblUrunler entity);
        int GetCountByCategory(string category);
    }
}
