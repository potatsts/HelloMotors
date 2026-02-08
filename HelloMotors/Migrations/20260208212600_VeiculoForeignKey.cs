using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMotors.Migrations
{
    /// <inheritdoc />
    public partial class VeiculoForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Proprietarios_ProprietarioIdProprietario",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_ProprietarioIdProprietario",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "ProprietarioIdProprietario",
                table: "Veiculos");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdProprietario",
                table: "Veiculos",
                column: "IdProprietario");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Proprietarios_IdProprietario",
                table: "Veiculos",
                column: "IdProprietario",
                principalTable: "Proprietarios",
                principalColumn: "IdProprietario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Proprietarios_IdProprietario",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_IdProprietario",
                table: "Veiculos");

            migrationBuilder.AddColumn<int>(
                name: "ProprietarioIdProprietario",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ProprietarioIdProprietario",
                table: "Veiculos",
                column: "ProprietarioIdProprietario");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Proprietarios_ProprietarioIdProprietario",
                table: "Veiculos",
                column: "ProprietarioIdProprietario",
                principalTable: "Proprietarios",
                principalColumn: "IdProprietario");
        }
    }
}
