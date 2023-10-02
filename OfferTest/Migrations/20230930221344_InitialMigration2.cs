using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Buyer_ID",
                table: "Amounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Amounts_Buyer_ID",
                table: "Amounts",
                column: "Buyer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Amounts_Buyers_Buyer_ID",
                table: "Amounts",
                column: "Buyer_ID",
                principalTable: "Buyers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amounts_Buyers_Buyer_ID",
                table: "Amounts");

            migrationBuilder.DropIndex(
                name: "IX_Amounts_Buyer_ID",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "Buyer_ID",
                table: "Amounts");
        }
    }
}
