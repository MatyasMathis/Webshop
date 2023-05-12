using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebshopAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("073b6e00-c538-4869-af59-83ad5374f8a1"), "manager" },
                    { new Guid("20147f57-964d-451d-98d9-3fd2e761aff7"), "admin" },
                    { new Guid("cc4e27d5-2a5d-41d3-8a16-52cb5d76689e"), "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("073b6e00-c538-4869-af59-83ad5374f8a1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("20147f57-964d-451d-98d9-3fd2e761aff7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cc4e27d5-2a5d-41d3-8a16-52cb5d76689e"));
        }
    }
}
