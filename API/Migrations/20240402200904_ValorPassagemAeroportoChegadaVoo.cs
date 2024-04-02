using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ValorPassagemAeroportoChegadaVoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AeroportoChegadaId",
                table: "Voos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Valor",
                table: "Passagens",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Voos_AeroportoChegadaId",
                table: "Voos",
                column: "AeroportoChegadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voos_Aeroportos_AeroportoChegadaId",
                table: "Voos",
                column: "AeroportoChegadaId",
                principalTable: "Aeroportos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voos_Aeroportos_AeroportoChegadaId",
                table: "Voos");

            migrationBuilder.DropIndex(
                name: "IX_Voos_AeroportoChegadaId",
                table: "Voos");

            migrationBuilder.DropColumn(
                name: "AeroportoChegadaId",
                table: "Voos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Passagens");
        }
    }
}
