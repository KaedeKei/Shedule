using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shedule.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    IsDebtor = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerName = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerPassword = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerStatus = table.Column<string>(type: "TEXT", nullable: false),
                    IsEnable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PointName = table.Column<string>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    ThisCustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ThisManagerId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsEnable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryPoints_Customers_ThisCustomerId",
                        column: x => x.ThisCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPoints_Managers_ThisManagerId",
                        column: x => x.ThisManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventPointId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventManagerId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRelevant = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryEvents_DeliveryPoints_EventPointId",
                        column: x => x.EventPointId,
                        principalTable: "DeliveryPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryEvents_Managers_EventManagerId",
                        column: x => x.EventManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryEvents_EventManagerId",
                table: "DeliveryEvents",
                column: "EventManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryEvents_EventPointId",
                table: "DeliveryEvents",
                column: "EventPointId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPoints_ThisCustomerId",
                table: "DeliveryPoints",
                column: "ThisCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPoints_ThisManagerId",
                table: "DeliveryPoints",
                column: "ThisManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryEvents");

            migrationBuilder.DropTable(
                name: "DeliveryPoints");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
