using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class FifthtenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuest_Users_UserId",
                table: "WeddingGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuest_Weddings_WeddingId",
                table: "WeddingGuest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingGuest",
                table: "WeddingGuest");

            migrationBuilder.RenameTable(
                name: "WeddingGuest",
                newName: "WeddingGuests");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingGuest_WeddingId",
                table: "WeddingGuests",
                newName: "IX_WeddingGuests_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingGuest_UserId",
                table: "WeddingGuests",
                newName: "IX_WeddingGuests_UserId");

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "WeddingGuests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingGuests",
                table: "WeddingGuests",
                column: "WeddingGuestId");

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsAttending = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NumberOfAttendees = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingGuests_GuestId",
                table: "WeddingGuests",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuests_Guests_GuestId",
                table: "WeddingGuests",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuests_Users_UserId",
                table: "WeddingGuests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuests_Weddings_WeddingId",
                table: "WeddingGuests",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuests_Guests_GuestId",
                table: "WeddingGuests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuests_Users_UserId",
                table: "WeddingGuests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuests_Weddings_WeddingId",
                table: "WeddingGuests");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeddingGuests",
                table: "WeddingGuests");

            migrationBuilder.DropIndex(
                name: "IX_WeddingGuests_GuestId",
                table: "WeddingGuests");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "WeddingGuests");

            migrationBuilder.RenameTable(
                name: "WeddingGuests",
                newName: "WeddingGuest");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingGuests_WeddingId",
                table: "WeddingGuest",
                newName: "IX_WeddingGuest_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_WeddingGuests_UserId",
                table: "WeddingGuest",
                newName: "IX_WeddingGuest_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeddingGuest",
                table: "WeddingGuest",
                column: "WeddingGuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuest_Users_UserId",
                table: "WeddingGuest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuest_Weddings_WeddingId",
                table: "WeddingGuest",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
