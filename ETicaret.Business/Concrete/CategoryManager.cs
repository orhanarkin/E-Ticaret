using ETicaret.Business.Abstract;
using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(TblKategoriler entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(TblKategoriler entity)
        {
            _categoryRepository.Delete(entity);
        }

        public List<TblKategoriler> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public TblKategoriler GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(TblKategoriler entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
