using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdopetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelasEInsercaoTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tutores",
                columns: table => new
                {
                    Tutor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tutor_Nome = table.Column<string>(type: "longtext", nullable: false),
                    Tutor_Telefone = table.Column<string>(type: "longtext", nullable: false),
                    Tutor_Email = table.Column<string>(type: "longtext", nullable: false),
                    Pet_Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Pet_UF = table.Column<string>(type: "longtext", nullable: false),
                    DtInsert = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DtUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutores", x => x.Tutor_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tutores");
        }
    }
}
