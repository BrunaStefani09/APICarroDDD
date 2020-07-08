using Microsoft.EntityFrameworkCore.Migrations;

namespace AulaProjetoFinal.Infra.Data.Migrations
{
    public partial class CriacaoTabelaCarro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    KM = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    MarcaId = table.Column<int>(nullable: true),
                    ModeloId = table.Column<int>(nullable: true),
                    VersaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carro_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carro_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carro_Versao_VersaoId",
                        column: x => x.VersaoId,
                        principalTable: "Versao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carro_MarcaId",
                table: "Carro",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carro_ModeloId",
                table: "Carro",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Carro_VersaoId",
                table: "Carro",
                column: "VersaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carro");
        }
    }
}
