using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaret.DataAccessLayer.Concrete
{
    public class CartRepository : GenericRepository<TblSepet, ETicaretContext>, ICartRepository
    {
        public override void Update(TblSepet entity)
        {
            using (var ctx = new ETicaretContext())
            {
                ctx.TblSepet.Update(entity);
                ctx.SaveChanges();
            }
        }

        public TblSepet GetByUserId(string userId)
        {
            using (var ctx = new ETicaretContext())
            {
                return ctx.TblSepet
                    .Include(i => i.SepetUrunleri)
                    .ThenInclude(i => i.Urun)
                    .FirstOrDefault(i => i.UserId == userId);
            }
        }
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var ctx = new ETicaretContext())
            {
                var cmd = @"delete from TblSepetUrunleri where SepetId=@p0 And UrunId=@p1";
                ctx.Database.ExecuteSqlCommand(cmd, cartId, productId);
            }
        }
    }
}
