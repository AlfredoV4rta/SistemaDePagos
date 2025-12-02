using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEmpresa.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Agregandounicoyrecurrente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_TipoDeGastos_TipoGastoId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Usuarios_UsuarioId",
                table: "Pagos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pagos",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "TipoGastoId",
                table: "Pagos",
                newName: "IdTipoGasto");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_UsuarioId",
                table: "Pagos",
                newName: "IX_Pagos_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_TipoGastoId",
                table: "Pagos",
                newName: "IX_Pagos_IdTipoGasto");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pagos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDePago",
                table: "Pagos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDesde",
                table: "Pagos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHasta",
                table: "Pagos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NroRecibo",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEquipo",
                table: "Usuarios",
                column: "IdEquipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_TipoDeGastos_IdTipoGasto",
                table: "Pagos",
                column: "IdTipoGasto",
                principalTable: "TipoDeGastos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Usuarios_IdUsuario",
                table: "Pagos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Equipos_IdEquipo",
                table: "Usuarios",
                column: "IdEquipo",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_TipoDeGastos_IdTipoGasto",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Usuarios_IdUsuario",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Equipos_IdEquipo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdEquipo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "FechaDePago",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "FechaDesde",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "FechaHasta",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "NroRecibo",
                table: "Pagos");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Pagos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdTipoGasto",
                table: "Pagos",
                newName: "TipoGastoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_IdUsuario",
                table: "Pagos",
                newName: "IX_Pagos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_IdTipoGasto",
                table: "Pagos",
                newName: "IX_Pagos_TipoGastoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_TipoDeGastos_TipoGastoId",
                table: "Pagos",
                column: "TipoGastoId",
                principalTable: "TipoDeGastos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Usuarios_UsuarioId",
                table: "Pagos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
