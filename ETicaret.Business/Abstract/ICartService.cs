using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        TblSepet GetCartByUserId(string userId);
        void AddToCart(string userId, int productId, int miktar);
        void DeleteFromCart(string userId, int productId);
    }
}
