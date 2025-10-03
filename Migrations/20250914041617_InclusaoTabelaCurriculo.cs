using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpregaAI.Migrations
{
    public partial class InclusaoTabelaCurriculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curriculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NivelEducacional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodoCargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoAtividade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instituto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodoInstituto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituicaoCertificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodoCertificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Excluido = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curriculos");
        }
    }
}
