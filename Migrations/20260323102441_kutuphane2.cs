using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class kutuphane2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SinifAdi",
                table: "Uyeler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Siniflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Seviye = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siniflar");

            migrationBuilder.DropColumn(
                name: "SinifAdi",
                table: "Uyeler");
        }
    }
}
