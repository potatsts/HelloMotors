using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMotors.Migrations
{
    /// <inheritdoc />
    public partial class UniqueRequiredUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_IdChassi",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "IdChassi",
                table: "Vendas",
                newName: "IdVeiculo");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_IdChassi",
                table: "Vendas",
                newName: "IX_Vendas_IdVeiculo");

            migrationBuilder.RenameColumn(
                name: "IdChassi",
                table: "Veiculos",
                newName: "IdVeiculo");

            migrationBuilder.AlterColumn<string>(
                name: "VersaoSistema",
                table: "Veiculos",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Veiculos",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Veiculos",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Proprietarios",
                type: "varchar(900)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Chassi",
                table: "Veiculos",
                column: "Chassi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_CpfCnpj",
                table: "Proprietarios",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_IdVeiculo",
                table: "Vendas",
                column: "IdVeiculo",
                principalTable: "Veiculos",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Veiculos_IdVeiculo",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_Chassi",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Proprietarios_CpfCnpj",
                table: "Proprietarios");

            migrationBuilder.RenameColumn(
                name: "IdVeiculo",
                table: "Vendas",
                newName: "IdChassi");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_IdVeiculo",
                table: "Vendas",
                newName: "IX_Vendas_IdChassi");

            migrationBuilder.RenameColumn(
                name: "IdVeiculo",
                table: "Veiculos",
                newName: "IdChassi");

            migrationBuilder.AlterColumn<string>(
                name: "VersaoSistema",
                table: "Veiculos",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Veiculos",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Veiculos",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "Proprietarios",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(900)",
                oldUnicode: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Veiculos_IdChassi",
                table: "Vendas",
                column: "IdChassi",
                principalTable: "Veiculos",
                principalColumn: "IdChassi",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
