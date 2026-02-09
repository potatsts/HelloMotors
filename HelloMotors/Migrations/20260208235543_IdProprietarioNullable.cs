using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMotors.Migrations
{
    /// <inheritdoc />
    public partial class IdProprietarioNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Proprietarios_IdProprietario",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "IdProprietario",
                table: "Veiculos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Proprietarios_IdProprietario",
                table: "Veiculos",
                column: "IdProprietario",
                principalTable: "Proprietarios",
                principalColumn: "IdProprietario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Proprietarios_IdProprietario",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "IdProprietario",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Proprietarios_IdProprietario",
                table: "Veiculos",
                column: "IdProprietario",
                principalTable: "Proprietarios",
                principalColumn: "IdProprietario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
