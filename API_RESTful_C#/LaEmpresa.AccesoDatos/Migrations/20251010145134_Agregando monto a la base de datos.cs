using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEmpresa.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Agregandomontoalabasededatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Monto",
                table: "Pagos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Pagos");
        }
    }
}
