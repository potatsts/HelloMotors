using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMotors.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    IdProprietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CpfCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DadosPessoais = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.IdProprietario);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    IdVendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.IdVendedor);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    IdChassi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chassi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersaoSistema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quilometragem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acessorios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProprietario = table.Column<int>(type: "int", nullable: false),
                    ProprietarioIdProprietario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.IdChassi);
                    table.ForeignKey(
                        name: "FK_Veiculos_Proprietarios_ProprietarioIdProprietario",
                        column: x => x.ProprietarioIdProprietario,
                        principalTable: "Proprietarios",
                        principalColumn: "IdProprietario");
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    VendedorIdVendedor = table.Column<int>(type: "int", nullable: true),
                    IdChassi = table.Column<int>(type: "int", nullable: false),
                    VeiculoIdChassi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_Vendas_Veiculos_VeiculoIdChassi",
                        column: x => x.VeiculoIdChassi,
                        principalTable: "Veiculos",
                        principalColumn: "IdChassi");
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_VendedorIdVendedor",
                        column: x => x.VendedorIdVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "IdVendedor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ProprietarioIdProprietario",
                table: "Veiculos",
                column: "ProprietarioIdProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoIdChassi",
                table: "Vendas",
                column: "VeiculoIdChassi");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorIdVendedor",
                table: "Vendas",
                column: "VendedorIdVendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Proprietarios");
        }
    }
}
