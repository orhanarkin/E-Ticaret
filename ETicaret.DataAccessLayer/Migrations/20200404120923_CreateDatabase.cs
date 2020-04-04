using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETicaret.DataAccessLayer.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(nullable: true),
                    UstId = table.Column<int>(nullable: true),
                    KisaKod = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Tarih = table.Column<DateTime>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    GoogleKategorisi = table.Column<int>(nullable: true),
                    Resim = table.Column<string>(nullable: true),
                    Aktif = table.Column<string>(nullable: true),
                    sira = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSepet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSepet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblUrunler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(nullable: true),
                    MarkaId = table.Column<int>(nullable: true),
                    UrunAdi = table.Column<string>(nullable: true),
                    KisaAciklama = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    Kod = table.Column<string>(nullable: true),
                    Barkod = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Resim1 = table.Column<string>(nullable: true),
                    Resim2 = table.Column<string>(nullable: true),
                    Resim3 = table.Column<string>(nullable: true),
                    Resim4 = table.Column<string>(nullable: true),
                    Resim5 = table.Column<string>(nullable: true),
                    Fiyat = table.Column<decimal>(nullable: true),
                    IndirimliFiyat = table.Column<decimal>(nullable: true),
                    IndirimliMi = table.Column<bool>(nullable: true),
                    AlisFiyati = table.Column<decimal>(nullable: true),
                    Kdv = table.Column<int>(nullable: true),
                    KdvDahilMi = table.Column<bool>(nullable: true),
                    BirimId = table.Column<int>(nullable: true),
                    ParaBirimi = table.Column<string>(nullable: true),
                    Stok = table.Column<int>(nullable: true),
                    Desi = table.Column<int>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true),
                    AnaUrunId = table.Column<int>(nullable: true),
                    GarantiSuresi = table.Column<bool>(nullable: true),
                    Goruntuleme = table.Column<bool>(nullable: true),
                    HizliKargo = table.Column<bool>(nullable: true),
                    UcretsizKargo = table.Column<bool>(nullable: true),
                    AyniGunTeslim = table.Column<bool>(nullable: true),
                    SinirliSayida = table.Column<bool>(nullable: true),
                    OzelUrun = table.Column<bool>(nullable: true),
                    FirsatUrunu = table.Column<bool>(nullable: true),
                    Vitrin = table.Column<bool>(nullable: true),
                    Etiketler = table.Column<string>(nullable: true),
                    ToptanFiyati = table.Column<decimal>(nullable: true),
                    PerakendeFiyati = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUrunler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSepetUrunleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(nullable: true),
                    SepetId = table.Column<int>(nullable: true),
                    Miktar = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSepetUrunleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSepetUrunleri_TblSepet_SepetId",
                        column: x => x.SepetId,
                        principalTable: "TblSepet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblSepetUrunleri_TblUrunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "TblUrunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblUrunKategori",
                columns: table => new
                {
                    UrunId = table.Column<int>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUrunKategori", x => new { x.UrunId, x.KategoriId });
                    table.ForeignKey(
                        name: "FK_TblUrunKategori_TblKategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "TblKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUrunKategori_TblUrunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "TblUrunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSepetUrunleri_SepetId",
                table: "TblSepetUrunleri",
                column: "SepetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSepetUrunleri_UrunId",
                table: "TblSepetUrunleri",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUrunKategori_KategoriId",
                table: "TblUrunKategori",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblSepetUrunleri");

            migrationBuilder.DropTable(
                name: "TblUrunKategori");

            migrationBuilder.DropTable(
                name: "TblSepet");

            migrationBuilder.DropTable(
                name: "TblKategoriler");

            migrationBuilder.DropTable(
                name: "TblUrunler");
        }
    }
}
