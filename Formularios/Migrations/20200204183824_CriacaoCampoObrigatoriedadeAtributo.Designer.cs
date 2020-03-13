﻿// <auto-generated />
using System;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Formularios.Migrations
{
    [DbContext(typeof(FormularioDbContext))]
    [Migration("20200204183824_CriacaoCampoObrigatoriedadeAtributo")]
    partial class CriacaoCampoObrigatoriedadeAtributo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Atributo", b =>
                {
                    b.Property<Guid>("IdAtributo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdConta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTipoAtributo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TamanhoMaximo")
                        .HasColumnType("int");

                    b.HasKey("IdAtributo");

                    b.ToTable("Atributo");
                });

            modelBuilder.Entity("Models.Modelo", b =>
                {
                    b.Property<Guid>("IdModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdModelo");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("Models.ModeloAtributo", b =>
                {
                    b.Property<Guid>("IdModeloAtributo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdAtributo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdModelo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Obrigatorio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<long>("Versao")
                        .HasColumnType("bigint");

                    b.HasKey("IdModeloAtributo");

                    b.ToTable("ModeloAtributo");
                });

            modelBuilder.Entity("Models.TipoAtributo", b =>
                {
                    b.Property<Guid>("IdTipoAtributo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdConta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoAtributo");

                    b.ToTable("TipoAtributo");
                });
#pragma warning restore 612, 618
        }
    }
}
