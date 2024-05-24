using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEBEEJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedValueMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedValueMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    SendingAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    BidderId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Other" },
                    { 2, "Fashion" },
                    { 3, "Readables" },
                    { 4, "Furniture" },
                    { 5, "Toys" },
                    { 6, "Decoration" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Created", "EndDate", "EstimatedValueMax", "EstimatedValueMin", "IsActive", "IsSold", "ItemDescription", "ItemName", "LastModified", "SellerID", "SendingAdress", "StartingPrice", "UserEntityId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6471), new DateTime(2024, 5, 31, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6474), 50000m, 10m, false, false, "Doodoo", "Dada item", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dok", 1m, null },
                    { 2, 1, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6481), new DateTime(2024, 5, 31, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6483), 200m, 50m, false, false, "Tight Shorts that make you pretty", "A TS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dok", 50m, null },
                    { 3, 2, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6486), new DateTime(2024, 5, 31, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6487), 99m, 15m, false, false, "A book about the wonders of Belgium", "Tiny Treasure Box", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ghent", 15m, null },
                    { 4, 3, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6490), new DateTime(2024, 5, 31, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6492), 400m, 99m, false, false, "An used old couch", "Hang Bank", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "My home", 80m, null },
                    { 5, 4, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6495), new DateTime(2024, 5, 31, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6496), 400m, 299m, false, false, "A grownups toy", "The Big Sheep Anatomy S-Doll", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "My home", 250m, null },
                    { 6, 5, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6500), new DateTime(2024, 5, 31, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6501), 20000m, 959m, false, false, "A painting from the Holy Roman Empire Time Period, for reals", "Holy Pope punching the heretic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Centrum Brussel", 850m, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "Birthday", "Created", "Email", "IsActive", "Name", "Password", "PhoneNumber", "Role", "UserEntityId" },
                values: new object[,]
                {
                    { 1, "Thuis-Straat", new DateTime(1980, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6235), "Buddy@hotmail.com", false, "Buddy", "1230", "1234567890", 0, null },
                    { 2, "Parque De Triumph", new DateTime(1995, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6307), "JaJa2015@hotmail.com", false, "Jacky Jackouis", "EnglishFrench", "9876543210", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "BidValue", "BidderId", "Created", "IsActive", "ItemID" },
                values: new object[,]
                {
                    { 1, 500m, 2, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6537), false, 1 },
                    { 2, 600m, 1, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6541), false, 1 },
                    { 3, 700m, 2, new DateTime(2024, 5, 24, 14, 5, 36, 256, DateTimeKind.Local).AddTicks(6543), false, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidderId",
                table: "Bids",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ItemID",
                table: "Bids",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserEntityId",
                table: "Items",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEntityId",
                table: "Users",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
