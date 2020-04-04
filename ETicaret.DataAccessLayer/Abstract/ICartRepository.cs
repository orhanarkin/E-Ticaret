using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.DataAccessLayer.Abstract
{
    public interface ICartRepository : IGenericRepository<TblSepet>
    {
        TblSepet GetByUserId(string userId);
        void DeleteFromCart(int cartId, int productId);
    }
}
