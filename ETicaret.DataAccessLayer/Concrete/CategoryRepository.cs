using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.DataAccessLayer.Concrete
{
    public class CategoryRepository : GenericRepository<TblKategoriler, ETicaretContext>, ICategoryRepository
    {

    }
}
