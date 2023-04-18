using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdopetAPI.Migrations
{
    /// <inheritdoc />
    public partial class StartMigrationBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Resp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Resp_Nome = table.Column<string>(type: "longtext", nullable: false),
                    Resp_Telefone = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DtUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Resp_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Pet_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Pet_Nome = table.Column<string>(type: "longtext", nullable: false),
                    Pet_Idade = table.Column<int>(type: "int", nullable: false),
                    Pet_Especie = table.Column<int>(type: "int", nullable: false),
                    Pet_Caracteristicas = table.Column<string>(type: "longtext", nullable: true),
                    Pet_Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Pet_UF = table.Column<string>(type: "longtext", nullable: false),
                    Pet_ResponsavelResp_Id = table.Column<int>(type: "int", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Pet_Id);
                    table.ForeignKey(
                        name: "FK_Pets_Responsaveis_Pet_ResponsavelResp_Id",
                        column: x => x.Pet_ResponsavelResp_Id,
                        principalTable: "Responsaveis",
                        principalColumn: "Resp_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_Pet_ResponsavelResp_Id",
                table: "Pets",
                column: "Pet_ResponsavelResp_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Responsaveis");
        }
    }
}
