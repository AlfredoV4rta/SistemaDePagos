using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEmpresa.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoidaAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoDeGasto",
                table: "Auditorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTipoDeGasto",
                table: "Auditorias");
        }
    }
}
