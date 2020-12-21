﻿// <auto-generated />
using System;
using EduX.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduX.Migrations
{
    [DbContext(typeof(EduxContext))]
    [Migration("20201216214927_UpdateUser2")]
    partial class UpdateUser2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EduX.Domains.AlunoTurma", b =>
                {
                    b.Property<Guid>("IdAlunoTurma")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdTurma")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Matricula")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdAlunoTurma")
                        .HasName("PK__AlunoTur__8F3223BDF943BECF");

                    b.HasIndex("IdTurma");

                    b.HasIndex("IdUsuario");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("EduX.Domains.Categoria", b =>
                {
                    b.Property<Guid>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__A3C02A1023BB3B1B");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("EduX.Domains.Curso", b =>
                {
                    b.Property<Guid>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdInstituicao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdCurso")
                        .HasName("PK__Curso__085F27D6CB9DBD19");

                    b.HasIndex("IdInstituicao");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("EduX.Domains.Curtida", b =>
                {
                    b.Property<Guid>("IdCurtida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdDica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdCurtida")
                        .HasName("PK__Curtida__2169583A8C8A7FA7");

                    b.HasIndex("IdDica");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Curtida");
                });

            modelBuilder.Entity("EduX.Domains.Dica", b =>
                {
                    b.Property<Guid>("IdDica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Texto")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("UrlImagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDica")
                        .HasName("PK__Dica__F168851655469158");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Dica");
                });

            modelBuilder.Entity("EduX.Domains.Instituicao", b =>
                {
                    b.Property<Guid>("IdInstituicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Cep")
                        .HasColumnName("CEP")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Uf")
                        .HasColumnName("UF")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("IdInstituicao")
                        .HasName("PK__Institui__B771C0D87B018A53");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("EduX.Domains.Objetivo", b =>
                {
                    b.Property<Guid>("IdObjetivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<Guid?>("IdCategoria")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdObjetivo")
                        .HasName("PK__Objetivo__E210F071A6858F4A");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Objetivo");
                });

            modelBuilder.Entity("EduX.Domains.ObjetivoAluno", b =>
                {
                    b.Property<Guid>("IdObjetivoAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlcancado")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("IdAlunoTurma")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdObjetivo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdObjetivoAluno")
                        .HasName("PK__Objetivo__07A3F088E738038F");

                    b.HasIndex("IdAlunoTurma");

                    b.HasIndex("IdObjetivo");

                    b.ToTable("ObjetivoAluno");
                });

            modelBuilder.Entity("EduX.Domains.Perfil", b =>
                {
                    b.Property<Guid>("IdPerfil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permissao")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdPerfil")
                        .HasName("PK__Perfil__C7BD5CC16CF01EC5");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("EduX.Domains.ProfessorTurma", b =>
                {
                    b.Property<Guid>("IdProfessorTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<Guid?>("IdTurma")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProfessorTurma")
                        .HasName("PK__Professo__D4E74F9E8C3E5288");

                    b.HasIndex("IdTurma");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("EduX.Domains.Turma", b =>
                {
                    b.Property<Guid>("IdTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<Guid?>("IdCurso")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdTurma")
                        .HasName("PK__Turma__C1ECFFC90B321EB4");

                    b.HasIndex("IdCurso");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("EduX.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurtidasTotais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataUltimoAcesso")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid?>("IdPerfil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("PostagensTotais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__5B65BF97104F600C");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("EduX.Domains.AlunoTurma", b =>
                {
                    b.HasOne("EduX.Domains.Turma", "IdTurmaNavigation")
                        .WithMany("AlunoTurma")
                        .HasForeignKey("IdTurma")
                        .HasConstraintName("FK__AlunoTurm__IdTur__4F7CD00D");

                    b.HasOne("EduX.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("AlunoTurma")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__AlunoTurm__IdUsu__4E88ABD4");
                });

            modelBuilder.Entity("EduX.Domains.Curso", b =>
                {
                    b.HasOne("EduX.Domains.Instituicao", "IdInstituicaoNavigation")
                        .WithMany("Curso")
                        .HasForeignKey("IdInstituicao")
                        .HasConstraintName("FK__Curso__IdInstitu__3C69FB99");
                });

            modelBuilder.Entity("EduX.Domains.Curtida", b =>
                {
                    b.HasOne("EduX.Domains.Dica", "IdDicaNavigation")
                        .WithMany("Curtida")
                        .HasForeignKey("IdDica")
                        .HasConstraintName("FK__Curtida__IdDica__5812160E");

                    b.HasOne("EduX.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Curtida")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Curtida__IdUsuar__571DF1D5");
                });

            modelBuilder.Entity("EduX.Domains.Dica", b =>
                {
                    b.HasOne("EduX.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Dica")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Dica__IdUsuario__47DBAE45");
                });

            modelBuilder.Entity("EduX.Domains.Objetivo", b =>
                {
                    b.HasOne("EduX.Domains.Categoria", "IdCategoriaNavigation")
                        .WithMany("Objetivo")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__Objetivo__IdCate__44FF419A");
                });

            modelBuilder.Entity("EduX.Domains.ObjetivoAluno", b =>
                {
                    b.HasOne("EduX.Domains.AlunoTurma", "IdAlunoTurmaNavigation")
                        .WithMany("ObjetivoAluno")
                        .HasForeignKey("IdAlunoTurma")
                        .HasConstraintName("FK__ObjetivoA__IdAlu__534D60F1");

                    b.HasOne("EduX.Domains.Objetivo", "IdObjetivoNavigation")
                        .WithMany("ObjetivoAluno")
                        .HasForeignKey("IdObjetivo")
                        .HasConstraintName("FK__ObjetivoA__IdObj__5441852A");
                });

            modelBuilder.Entity("EduX.Domains.ProfessorTurma", b =>
                {
                    b.HasOne("EduX.Domains.Turma", "IdTurmaNavigation")
                        .WithMany("ProfessorTurma")
                        .HasForeignKey("IdTurma")
                        .HasConstraintName("FK__Professor__IdTur__4BAC3F29");

                    b.HasOne("EduX.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("ProfessorTurma")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Professor__IdUsu__4AB81AF0");
                });

            modelBuilder.Entity("EduX.Domains.Turma", b =>
                {
                    b.HasOne("EduX.Domains.Curso", "IdCursoNavigation")
                        .WithMany("Turma")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK__Turma__IdCurso__4222D4EF");
                });

            modelBuilder.Entity("EduX.Domains.Usuario", b =>
                {
                    b.HasOne("EduX.Domains.Perfil", "IdPerfilNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("IdPerfil")
                        .HasConstraintName("FK__Usuario__IdPerfi__3F466844");
                });
#pragma warning restore 612, 618
        }
    }
}
