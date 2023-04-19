using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class EleventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuests_Guests_GuestId",
                table: "WeddingGuests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_WeddingId",
                table: "Guest",
                newName: "IX_Guest_WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Weddings_WeddingId",
                table: "Guest",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuests_Guest_GuestId",
                table: "WeddingGuests",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Weddings_WeddingId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingGuests_Guest_GuestId",
                table: "WeddingGuests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_WeddingId",
                table: "Guests",
                newName: "IX_Guests_WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingGuests_Guests_GuestId",
                table: "WeddingGuests",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
