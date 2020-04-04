using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Abstract
{
    public interface ICategoryService
    {
        TblKategoriler GetById(int id);
        List<TblKategoriler> GetAll();
        void Create(TblKategoriler entity);
        void Update(TblKategoriler entity);
        void Delete(TblKategoriler entity);
    }
}
