using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEBEEJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SendingAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Users_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Items_ItemEntityId",
                        column: x => x.ItemEntityId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" },
                    { 3, "Sold" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "Birthday", "Created", "Email", "IsActive", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "Thuis-Straat", new DateTime(1980, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2664), "Buddy@hotmail.com", false, "Buddy", "1230", "1234567890", 0 },
                    { 2, "Parque De Triumph", new DateTime(1995, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2722), "JaJa2015@hotmail.com", false, "Jacky Jackouis", "EnglishFrench", "9876543210", 0 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Created", "EndDate", "EstimatedValueMax", "EstimatedValueMin", "IsActive", "IsSold", "ItemDescription", "ItemName", "LastModified", "SellerId", "SendingAdress", "StartingPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2864), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2867), 50000m, 10m, false, false, "Doodoo", "Dada item", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dok", 1m },
                    { 2, 2, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2874), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2875), 200m, 50m, false, false, "Tight Shorts that make you pretty", "A TS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dok", 50m },
                    { 3, 3, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2878), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2880), 99m, 15m, false, false, "A book about the wonders of Belgium", "Tiny Treasure Box", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ghent", 15m },
                    { 4, 4, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2882), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2884), 400m, 99m, false, false, "An used old couch", "Hang Bank", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "My home", 80m },
                    { 5, 5, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2887), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2888), 400m, 299m, false, false, "A grownups toy", "The Big Sheep Anatomy S-Doll", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "My home", 250m },
                    { 6, 6, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2892), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2893), 20000m, 959m, false, false, "A painting from the Holy Roman Empire Time Period, for reals", "Holy Pope punching the heretic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Centrum Brussel", 850m },
                    { 7, 3, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2896), new DateTime(2024, 6, 10, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2898), 20000m, 959m, false, false, "A book about how to read books", "Reading Book for dummies", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Centrum Brussel", 200m }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "BidValue", "BidderId", "Created", "IsActive", "ItemID" },
                values: new object[,]
                {
                    { 1, 500m, 2, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2924), false, 1 },
                    { 2, 600m, 1, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2927), false, 1 },
                    { 3, 700m, 2, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(2929), false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BuyerId", "Created", "IsActive", "ItemEntityId", "PaymentMethod", "SellerName", "SendAdress", "StatusId", "TotalCost" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(3014), false, 3, "Paypal", "Jeff", "test", 1, 700m },
                    { 2, 2, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(3019), false, 2, "Credit Card", "Joff", "test", 2, 600m },
                    { 3, 1, new DateTime(2024, 6, 3, 23, 40, 53, 252, DateTimeKind.Local).AddTicks(3023), false, 1, "Paypal", "Dante", "test", 3, 700m }
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
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SellerId",
                table: "Items",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemEntityId",
                table: "Orders",
                column: "ItemEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
