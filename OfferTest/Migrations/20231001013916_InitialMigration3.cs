using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PossibleAmountss_Amounts_AmountID",
                table: "PossibleAmountss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amounts",
                table: "Amounts");

            migrationBuilder.DropIndex(
                name: "IX_Amounts_Buyer_ID",
                table: "Amounts");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Amounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amounts",
                table: "Amounts",
                column: "Buyer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Previous_Statuses_IsActive",
                table: "Previous_Statuses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleAmountss_IsActive",
                table: "PossibleAmountss",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_date",
                table: "Offers",
                column: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_PossibleAmountss_Amounts_AmountID",
                table: "PossibleAmountss",
                column: "AmountID",
                principalTable: "Amounts",
                principalColumn: "Buyer_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PossibleAmountss_Amounts_AmountID",
                table: "PossibleAmountss");

            migrationBuilder.DropIndex(
                name: "IX_Previous_Statuses_IsActive",
                table: "Previous_Statuses");

            migrationBuilder.DropIndex(
                name: "IX_PossibleAmountss_IsActive",
                table: "PossibleAmountss");

            migrationBuilder.DropIndex(
                name: "IX_Offers_date",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amounts",
                table: "Amounts");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Amounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amounts",
                table: "Amounts",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Amounts_Buyer_ID",
                table: "Amounts",
                column: "Buyer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PossibleAmountss_Amounts_AmountID",
                table: "PossibleAmountss",
                column: "AmountID",
                principalTable: "Amounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
