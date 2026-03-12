using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class Kutuphane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KitapTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Soyad = table.Column<string>(type: "TEXT", nullable: false),
                    Eposta = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YayinEvleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEvleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Soyad = table.Column<string>(type: "TEXT", nullable: false),
                    Biyografi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 17, nullable: false),
                    SayfaSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    YayinEviId = table.Column<int>(type: "INTEGER", nullable: false),
                    YazarId = table.Column<int>(type: "INTEGER", nullable: false),
                    TurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitaplar_KitapTurleri_TurId",
                        column: x => x.TurId,
                        principalTable: "KitapTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_YayinEvleri_YayinEviId",
                        column: x => x.YayinEviId,
                        principalTable: "YayinEvleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oduncler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UyeId = table.Column<int>(type: "INTEGER", nullable: false),
                    KitapId = table.Column<int>(type: "INTEGER", nullable: false),
                    VerilisTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GetirmesiIstenenTarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Durum = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oduncler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oduncler_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oduncler_Uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uyeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cezalilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OduncId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tutar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    OdendiMi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cezalilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cezalilar_Oduncler_OduncId",
                        column: x => x.OduncId,
                        principalTable: "Oduncler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cezalilar_OduncId",
                table: "Cezalilar",
                column: "OduncId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_TurId",
                table: "Kitaplar",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YayinEviId",
                table: "Kitaplar",
                column: "YayinEviId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarId",
                table: "Kitaplar",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Oduncler_KitapId",
                table: "Oduncler",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_Oduncler_UyeId",
                table: "Oduncler",
                column: "UyeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cezalilar");

            migrationBuilder.DropTable(
                name: "Oduncler");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "KitapTurleri");

            migrationBuilder.DropTable(
                name: "YayinEvleri");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
