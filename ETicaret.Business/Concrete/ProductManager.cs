using ETicaret.Business.Abstract;
using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaret.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(TblUrunler entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(TblUrunler entity)
        {
            _productRepository.Delete(entity);
        }

        public List<TblUrunler> GetAll()
        {
            return _productRepository.GetAll();
        }

        public TblUrunler GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<TblUrunler> GetPopularProducts()
        {
            return _productRepository.GetAll();
        }

        public TblUrunler GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }

        public List<TblUrunler> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(category,page,pageSize);
        }

        public void Update(TblUrunler entity)
        {
            _productRepository.Update(entity);
        }
    }
}
