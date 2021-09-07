using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOpsCp01.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAB_CARTAO",
                columns: table => new
                {
                    id_cartao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nr_cartao = table.Column<long>(nullable: false),
                    ds_cartao = table.Column<string>(maxLength: 50, nullable: false),
                    nr_cvv = table.Column<int>(nullable: false),
                    vl_limite = table.Column<float>(nullable: false),
                    id_cliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_CARTAO", x => x.id_cartao);
                });

            migrationBuilder.CreateTable(
                name: "TAB_CLIENTE",
                columns: table => new
                {
                    id_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_nome = table.Column<string>(maxLength: 180, nullable: false),
                    nr_cpf = table.Column<long>(nullable: false),
                    nm_endereco = table.Column<string>(maxLength: 300, nullable: false),
                    nm_email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_cliente", x => x.id_cliente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAB_CARTAO");

            migrationBuilder.DropTable(
                name: "TAB_CLIENTE");
        }
    }
}
