using ETicaret.Business.Abstract;
using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(string userId, int productId, int miktar)
        { // burda userkontrollü sepete ekleme işlemi yapıyorum daha sonra user girişi olmadan da sipariş alıyor olmam gerek
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {  //sepete ürün eklerken önce o üründen var mı kontrolü varsa miktarı artırıcam yoksa yeni ürünü sepete ekliycem
                var index = cart.SepetUrunleri.FindIndex(i => i.UrunId == productId);
                if (index < 0)
                {
                    cart.SepetUrunleri.Add(new TblSepetUrunleri()
                    {
                        UrunId = productId,
                        Miktar = miktar,
                        SepetId = cart.Id
                    });
                }
                else
                {
                    cart.SepetUrunleri[index].Miktar += miktar;
                }

                _cartRepository.Update(cart);
            }
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                _cartRepository.DeleteFromCart(cart.Id,productId);
            }
        }

        public TblSepet GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new TblSepet() { UserId = userId });
        }
    }
}
