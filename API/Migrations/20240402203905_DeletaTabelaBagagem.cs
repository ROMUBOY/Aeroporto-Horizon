using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class DeletaTabelaBagagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagens_Bagagens_BagagemId",
                table: "Passagens");

            migrationBuilder.DropTable(
                name: "Bagagens");

            migrationBuilder.DropIndex(
                name: "IX_Passagens_BagagemId",
                table: "Passagens");

            migrationBuilder.DropColumn(
                name: "BagagemId",
                table: "Passagens");

            migrationBuilder.AddColumn<string>(
                name: "BagagemCodigo",
                table: "Passagens",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BagagemCodigo",
                table: "Passagens");

            migrationBuilder.AddColumn<int>(
                name: "BagagemId",
                table: "Passagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bagagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagagens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagens_BagagemId",
                table: "Passagens",
                column: "BagagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagens_Bagagens_BagagemId",
                table: "Passagens",
                column: "BagagemId",
                principalTable: "Bagagens",
                principalColumn: "Id");
        }
    }
}
