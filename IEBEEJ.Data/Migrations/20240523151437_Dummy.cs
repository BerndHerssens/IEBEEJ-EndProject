using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEBEEJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class Dummy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Created", "EndDate", "EstimatedValueMax", "EstimatedValueMin", "IsActive", "IsSold", "ItemDescription", "ItemName", "LastModified", "SellerID", "SendingAdress", "StartingPrice", "UserEntityId" },
                values: new object[] { 1, 1, new DateTime(2024, 5, 23, 17, 14, 37, 162, DateTimeKind.Local).AddTicks(7164), new DateTime(2024, 5, 30, 17, 14, 37, 162, DateTimeKind.Local).AddTicks(7166), 50000m, 10m, false, false, "Doodoo", "Dada item", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dok", 1m, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "Birthday", "Created", "Email", "IsActive", "Name", "Password", "PhoneNumber", "Role", "UserEntityId" },
                values: new object[] { 1, "Buddy straat", new DateTime(2024, 5, 23, 17, 14, 37, 162, DateTimeKind.Local).AddTicks(6970), new DateTime(2024, 5, 23, 17, 14, 37, 162, DateTimeKind.Local).AddTicks(6879), "Buddy@hotmail.com", false, "Buddy", "1230", "1234567890", 0, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
