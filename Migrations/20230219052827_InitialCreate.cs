using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSqlAsp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    Telefone = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    Ano = table.Column<int>(type: "INT", nullable: false),
                    Cor = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNames = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false),
                    Autorizacao = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendido = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    ClienteId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoDeVenda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloId = table.Column<int>(type: "INT", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", nullable: false),
                    EstadoDeVendaId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_EstadoDeVenda_EstadoDeVendaId",
                        column: x => x.EstadoDeVendaId,
                        principalTable: "EstadoDeVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carros_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_EstadoDeVendaId",
                table: "Carros",
                column: "EstadoDeVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ModeloId",
                table: "Carros",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoDeVenda_ClienteId",
                table: "EstadoDeVenda",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EstadoDeVenda");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
