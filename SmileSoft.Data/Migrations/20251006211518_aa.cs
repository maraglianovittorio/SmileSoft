using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Odontologos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Odontologos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Odontologos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OdontologoId",
                table: "ObrasSociales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObrasSociales_OdontologoId",
                table: "ObrasSociales",
                column: "OdontologoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObrasSociales_Odontologos_OdontologoId",
                table: "ObrasSociales",
                column: "OdontologoId",
                principalTable: "Odontologos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObrasSociales_Odontologos_OdontologoId",
                table: "ObrasSociales");

            migrationBuilder.DropIndex(
                name: "IX_ObrasSociales_OdontologoId",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Odontologos");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Odontologos");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Odontologos");

            migrationBuilder.DropColumn(
                name: "OdontologoId",
                table: "ObrasSociales");
        }
    }
}
