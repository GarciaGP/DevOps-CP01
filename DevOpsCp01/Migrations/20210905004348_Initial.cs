using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOpsCp01.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAB_CLIENTE",
                columns: table => new
                {
                    id_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_nome = table.Column<string>(nullable: true),
                    nr_cpf = table.Column<int>(nullable: false),
                    nm_endereco = table.Column<string>(nullable: true),
                    nm_email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_CLIENTE", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "TAB_CARTAO",
                columns: table => new
                {
                    id_cartao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nr_cartao = table.Column<int>(nullable: false),
                    ds_cartao = table.Column<string>(nullable: true),
                    nr_cvv = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    vl_limite = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_CARTAO", x => x.id_cartao);
                    table.ForeignKey(
                        name: "FK_TAB_CARTAO_TAB_CLIENTE_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TAB_CLIENTE",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAB_CARTAO_ClienteId",
                table: "TAB_CARTAO",
                column: "ClienteId");
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
