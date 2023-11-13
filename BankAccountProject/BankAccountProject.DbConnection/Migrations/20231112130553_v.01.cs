using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccountProject.DbConnection.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    hesap_kodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hesap_adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ust_hesap_id = table.Column<int>(type: "int", nullable: false),
                    borc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    alacak = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    borc_sistem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    alacak_sistem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    borc_doviz = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    alacak_doviz = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    borc_islem_doviz = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    alacak_islem_doviz = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    birim_adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bakiye_sekli = table.Column<int>(type: "int", nullable: false),
                    aktif = table.Column<int>(type: "int", nullable: false),
                    dovizkod = table.Column<int>(type: "int", nullable: false)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
