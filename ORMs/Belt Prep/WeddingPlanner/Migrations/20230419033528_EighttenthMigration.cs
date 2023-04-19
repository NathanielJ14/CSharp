using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class EighttenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeddingGuests");

            migrationBuilder.DropColumn(
                name: "IsAttending",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "NumberOfAttendees",
                table: "Guests",
                newName: "WeddingId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UserId",
                table: "Guests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_WeddingId",
                table: "Guests",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Users_UserId",
                table: "Guests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Users_UserId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_UserId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_WeddingId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "WeddingId",
                table: "Guests",
                newName: "NumberOfAttendees");

            migrationBuilder.AddColumn<bool>(
                name: "IsAttending",
                table: "Guests",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Guests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
