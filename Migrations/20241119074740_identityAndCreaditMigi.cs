using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_store_ziad.Migrations
{
    /// <inheritdoc />
    public partial class identityAndCreaditMigi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ceridetCards",
                columns: table => new
                {
                    CeridetCardDtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeridetCardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ceridetCards", x => x.CeridetCardDtoId);
                    table.ForeignKey(
                        name: "FK_ceridetCards_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityCards",
                columns: table => new
                {
                    IdentityCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityCardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identityCards", x => x.IdentityCardId);
                    table.ForeignKey(
                        name: "FK_identityCards_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ceridetCards_AuthorId",
                table: "ceridetCards",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_identityCards_AuthorId",
                table: "identityCards",
                column: "AuthorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ceridetCards");

            migrationBuilder.DropTable(
                name: "identityCards");
        }
    }
}
