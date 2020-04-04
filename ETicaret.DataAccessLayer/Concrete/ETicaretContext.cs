using ETicaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.DataAccessLayer.Concrete
{
    public class ETicaretContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ARKIN\SQLEXPRESS;Database=ETicaretDb;Integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUrunKategori>().HasKey(c => new { c.UrunId, c.KategoriId });
        }
        public DbSet<TblUrunler> TblUrunler { get; set; }
        public DbSet<TblKategoriler> TblKategoriler { get; set; }
        public DbSet<TblSepet> TblSepet { get; set; }
    }
}
