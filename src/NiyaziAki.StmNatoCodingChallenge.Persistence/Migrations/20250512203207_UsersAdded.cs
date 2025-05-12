using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiyaziAki.StmNatoCodingChallenge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UsersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CreatedAt",
                schema: "StmNato",
                table: "Transaction",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionType",
                schema: "StmNato",
                table: "Transaction",
                column: "TransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                schema: "StmNato",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_UserId",
                schema: "StmNato",
                table: "Transaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_UserId",
                schema: "StmNato",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CreatedAt",
                schema: "StmNato",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_TransactionType",
                schema: "StmNato",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_UserId",
                schema: "StmNato",
                table: "Transaction");
        }
    }
}
