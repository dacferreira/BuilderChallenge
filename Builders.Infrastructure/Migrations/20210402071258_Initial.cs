using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Builders.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ArvoreBusca",
                schema: "dbo",
                columns: table => new
                {
                    IdArvoreBusca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArvoreBusca", x => x.IdArvoreBusca);
                });

            migrationBuilder.CreateTable(
                name: "NoArvore",
                schema: "dbo",
                columns: table => new
                {
                    IdNoArvore = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdArvoreBusca = table.Column<int>(nullable: false),
                    Altura = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    IdNoEsquerdo = table.Column<int>(nullable: true),
                    IdNoDireito = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoArvore", x => x.IdNoArvore);
                    table.ForeignKey(
                        name: "FK_NoArvore_ArvoreBusca_IdArvoreBusca",
                        column: x => x.IdArvoreBusca,
                        principalSchema: "dbo",
                        principalTable: "ArvoreBusca",
                        principalColumn: "IdArvoreBusca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoArvore_NoArvore_IdNoDireito",
                        column: x => x.IdNoDireito,
                        principalSchema: "dbo",
                        principalTable: "NoArvore",
                        principalColumn: "IdNoArvore",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NoArvore_NoArvore_IdNoEsquerdo",
                        column: x => x.IdNoEsquerdo,
                        principalSchema: "dbo",
                        principalTable: "NoArvore",
                        principalColumn: "IdNoArvore",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoArvore_IdArvoreBusca",
                schema: "dbo",
                table: "NoArvore",
                column: "IdArvoreBusca",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoArvore_IdNoDireito",
                schema: "dbo",
                table: "NoArvore",
                column: "IdNoDireito",
                unique: true,
                filter: "[IdNoDireito] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NoArvore_IdNoEsquerdo",
                schema: "dbo",
                table: "NoArvore",
                column: "IdNoEsquerdo",
                unique: true,
                filter: "[IdNoEsquerdo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoArvore",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ArvoreBusca",
                schema: "dbo");
        }
    }
}
