using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Migrations
{
    public partial class IDchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Customer_ID",
                table: "Adres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adres",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Adres");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Customer",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AdresID",
                table: "Adres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adres",
                table: "Adres",
                column: "AdresID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Customer_AdresID",
                table: "Adres",
                column: "AdresID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Customer_AdresID",
                table: "Adres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adres",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AdresID",
                table: "Adres");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Adres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adres",
                table: "Adres",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Customer_ID",
                table: "Adres",
                column: "ID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
