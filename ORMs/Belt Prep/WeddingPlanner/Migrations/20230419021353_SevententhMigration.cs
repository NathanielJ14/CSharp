using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class SevententhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Weddings_WeddingId",
                table: "Guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_WeddingId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "WeddingId",
                table: "Guest");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "GuestId");

            migrationBuilder.CreateTable(
                name: "WeddingGuests",
                columns: table => new
                {
                    WeddingGuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    WeddingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingGuests", x => x.WeddingGuestId);
                    table.ForeignKey(
                        name: "FK_WeddingGuests_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeddingGuests_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingGuests_GuestId",
                table: "WeddingGuests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingGuests_WeddingId",
                table: "WeddingGuests",
                column: "WeddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeddingGuests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.AddColumn<int>(
                name: "WeddingId",
                table: "Guest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_WeddingId",
                table: "Guest",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Weddings_WeddingId",
                table: "Guest",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
