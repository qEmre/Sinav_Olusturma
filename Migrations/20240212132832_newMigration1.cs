using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinavOlusturma.Migrations
{
    /// <inheritdoc />
    public partial class newMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rssItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rssItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sinavs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sinavs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sorus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    soruMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secenekA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secenekB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secenekC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secenekD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dogruCevap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinavId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sorus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sorus_sinavs_SinavId",
                        column: x => x.SinavId,
                        principalTable: "sinavs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sorus_SinavId",
                table: "sorus",
                column: "SinavId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rssItems");

            migrationBuilder.DropTable(
                name: "sorus");

            migrationBuilder.DropTable(
                name: "sinavs");
        }
    }
}
