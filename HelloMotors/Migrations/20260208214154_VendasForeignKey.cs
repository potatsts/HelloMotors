using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMotors.Migrations
{
    /// <inheritdoc />
    public partial class VendasForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_VeiculoIdChassi",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorIdVendedor",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VeiculoIdChassi",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VendedorIdVendedor",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "VeiculoIdChassi",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "VendedorIdVendedor",
                table: "Vendas");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdChassi",
                table: "Vendas",
                column: "IdChassi");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdVendedor",
                table: "Vendas",
                column: "IdVendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_IdChassi",
                table: "Vendas",
                column: "IdChassi",
                principalTable: "Veiculos",
                principalColumn: "IdChassi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_IdVendedor",
                table: "Vendas",
                column: "IdVendedor",
                principalTable: "Vendedores",
                principalColumn: "IdVendedor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_IdChassi",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_IdVendedor",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdChassi",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_IdVendedor",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "VeiculoIdChassi",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendedorIdVendedor",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoIdChassi",
                table: "Vendas",
                column: "VeiculoIdChassi");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorIdVendedor",
                table: "Vendas",
                column: "VendedorIdVendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_VeiculoIdChassi",
                table: "Vendas",
                column: "VeiculoIdChassi",
                principalTable: "Veiculos",
                principalColumn: "IdChassi");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorIdVendedor",
                table: "Vendas",
                column: "VendedorIdVendedor",
                principalTable: "Vendedores",
                principalColumn: "IdVendedor");
        }
    }
}
