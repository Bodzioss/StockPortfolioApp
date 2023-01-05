using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockPortfolioApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PortfolioId",
                table: "Transactions",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StockId",
                table: "Transactions",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockExchangeId",
                table: "Stocks",
                column: "StockExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDatas_StockId",
                table: "StockDatas",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComponents_PortfolioId",
                table: "PortfolioComponents",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComponents_StockId",
                table: "PortfolioComponents",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComponents_Portfolios_PortfolioId",
                table: "PortfolioComponents",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComponents_Stocks_StockId",
                table: "PortfolioComponents",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Users_UserId",
                table: "Portfolios",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockDatas_Stocks_StockId",
                table: "StockDatas",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_StockExchange_StockExchangeId",
                table: "Stocks",
                column: "StockExchangeId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Portfolios_PortfolioId",
                table: "Transactions",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Stocks_StockId",
                table: "Transactions",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComponents_Portfolios_PortfolioId",
                table: "PortfolioComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComponents_Stocks_StockId",
                table: "PortfolioComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Users_UserId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_StockDatas_Stocks_StockId",
                table: "StockDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_StockExchange_StockExchangeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Portfolios_PortfolioId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Stocks_StockId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PortfolioId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StockId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_StockExchangeId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_StockDatas_StockId",
                table: "StockDatas");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioComponents_PortfolioId",
                table: "PortfolioComponents");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioComponents_StockId",
                table: "PortfolioComponents");
        }
    }
}
