using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEmpresa.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CambiendoEmailComplto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_SiglaApellido",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email_SiglaNombre",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email_SiglaApellido",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email_SiglaNombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
