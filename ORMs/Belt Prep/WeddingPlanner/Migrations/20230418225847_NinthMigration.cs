using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class NinthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Weddings_WeddingId",
                table: "Guest");

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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UserId",
                table: "Guests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Users_UserId",
                table: "Guests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Users_UserId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Weddings_WeddingId",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_UserId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "UserId",
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
        }
    }
}
