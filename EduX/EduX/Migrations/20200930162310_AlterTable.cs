using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduX.Migrations
{
    public partial class AlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__A3C02A1023BB3B1B", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    IdInstituicao = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Logradouro = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Numero = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Complemento = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Bairro = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Cidade = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    UF = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    CEP = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Institui__B771C0D87B018A53", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    IdPerfil = table.Column<Guid>(nullable: false),
                    Permissao = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Perfil__C7BD5CC16CF01EC5", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Objetivo",
                columns: table => new
                {
                    IdObjetivo = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdCategoria = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Objetivo__E210F071A6858F4A", x => x.IdObjetivo);
                    table.ForeignKey(
                        name: "FK__Objetivo__IdCate__44FF419A",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdInstituicao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curso__085F27D6CB9DBD19", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK__Curso__IdInstitu__3C69FB99",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Senha = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataUltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdPerfil = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF97104F600C", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__IdPerfi__3F466844",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    IdTurma = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdCurso = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turma__C1ECFFC90B321EB4", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK__Turma__IdCurso__4222D4EF",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dica",
                columns: table => new
                {
                    IdDica = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    UrlImagem = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dica__F168851655469158", x => x.IdDica);
                    table.ForeignKey(
                        name: "FK__Dica__IdUsuario__47DBAE45",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    IdAlunoTurma = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    IdTurma = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AlunoTur__8F3223BDF943BECF", x => x.IdAlunoTurma);
                    table.ForeignKey(
                        name: "FK__AlunoTurm__IdTur__4F7CD00D",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AlunoTurm__IdUsu__4E88ABD4",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    IdProfessorTurma = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    IdTurma = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professo__D4E74F9E8C3E5288", x => x.IdProfessorTurma);
                    table.ForeignKey(
                        name: "FK__Professor__IdTur__4BAC3F29",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Professor__IdUsu__4AB81AF0",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curtida",
                columns: table => new
                {
                    IdCurtida = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    IdDica = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curtida__2169583A8C8A7FA7", x => x.IdCurtida);
                    table.ForeignKey(
                        name: "FK__Curtida__IdDica__5812160E",
                        column: x => x.IdDica,
                        principalTable: "Dica",
                        principalColumn: "IdDica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Curtida__IdUsuar__571DF1D5",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivoAluno",
                columns: table => new
                {
                    IdOjetivoAluno = table.Column<Guid>(nullable: false),
                    Nome = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    DataAlcancado = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdAlunoTurma = table.Column<Guid>(nullable: true),
                    IdObjetivo = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Objetivo__07A3F088E738038F", x => x.IdOjetivoAluno);
                    table.ForeignKey(
                        name: "FK__ObjetivoA__IdAlu__534D60F1",
                        column: x => x.IdAlunoTurma,
                        principalTable: "AlunoTurma",
                        principalColumn: "IdAlunoTurma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ObjetivoA__IdObj__5441852A",
                        column: x => x.IdObjetivo,
                        principalTable: "Objetivo",
                        principalColumn: "IdObjetivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_IdTurma",
                table: "AlunoTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_IdUsuario",
                table: "AlunoTurma",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdInstituicao",
                table: "Curso",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Curtida_IdDica",
                table: "Curtida",
                column: "IdDica");

            migrationBuilder.CreateIndex(
                name: "IX_Curtida_IdUsuario",
                table: "Curtida",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Dica_IdUsuario",
                table: "Dica",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_IdCategoria",
                table: "Objetivo",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoAluno_IdAlunoTurma",
                table: "ObjetivoAluno",
                column: "IdAlunoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivoAluno_IdObjetivo",
                table: "ObjetivoAluno",
                column: "IdObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_IdTurma",
                table: "ProfessorTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_IdUsuario",
                table: "ProfessorTurma",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtida");

            migrationBuilder.DropTable(
                name: "ObjetivoAluno");

            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.DropTable(
                name: "Dica");

            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
