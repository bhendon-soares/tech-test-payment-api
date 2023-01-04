using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techtestpaymentapi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoProdutoVenda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    NomeVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPFVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
