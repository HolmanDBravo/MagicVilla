using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablavilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenURL", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa....", new DateTime(2024, 4, 29, 15, 57, 47, 142, DateTimeKind.Local).AddTicks(3678), new DateTime(2024, 4, 29, 15, 57, 47, 142, DateTimeKind.Local).AddTicks(3656), "", 40.0, "Villa Real", 5, 200.0 },
                    { 2, "", "Premium de la Villa....", new DateTime(2024, 4, 29, 15, 57, 47, 142, DateTimeKind.Local).AddTicks(3686), new DateTime(2024, 4, 29, 15, 57, 47, 142, DateTimeKind.Local).AddTicks(3684), "", 50.0, "Premium vista a la piscina", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
