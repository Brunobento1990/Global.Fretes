﻿// <auto-generated />
using System;
using Global.Fretes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Global.Fretes.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240526170403_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Global.Fretes.Domain.Entities.ConfiguracaoContaTransportador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("CodigoEmailVerificado")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DataExpiracaoCodigoEmail")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("EmailVerificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<long>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Numero"));

                    b.Property<Guid>("TransportadorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CodigoEmailVerificado")
                        .IsUnique();

                    b.HasIndex("TransportadorId")
                        .IsUnique();

                    b.ToTable("ConfiguracoesContasTransportador");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.ConfiguracaoFreteTransportador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<long>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Numero"));

                    b.Property<decimal>("PrecoPorKm")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.Property<string>("RegiaoDeAtendimento")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("TransportadorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RegiaoDeAtendimento");

                    b.HasIndex("TransportadorId")
                        .IsUnique();

                    b.ToTable("ConfiguracoesFretesTransportador");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.Transportador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Foto")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<long>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Numero"));

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Telefone")
                        .IsUnique();

                    b.ToTable("Transportadores");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Foto")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<long>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Numero"));

                    b.Property<decimal>("PesoMaximo")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.Property<int>("TipoVeiculo")
                        .HasColumnType("integer");

                    b.Property<Guid>("TransportadorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TipoVeiculo");

                    b.HasIndex("TransportadorId")
                        .IsUnique();

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.ConfiguracaoContaTransportador", b =>
                {
                    b.HasOne("Global.Fretes.Domain.Entities.Transportador", "Transportador")
                        .WithOne("ConfiguracaoContaTransportador")
                        .HasForeignKey("Global.Fretes.Domain.Entities.ConfiguracaoContaTransportador", "TransportadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Transportador");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.ConfiguracaoFreteTransportador", b =>
                {
                    b.HasOne("Global.Fretes.Domain.Entities.Transportador", "Transportador")
                        .WithOne("ConfiguracaoFreteTransportador")
                        .HasForeignKey("Global.Fretes.Domain.Entities.ConfiguracaoFreteTransportador", "TransportadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Transportador");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("Global.Fretes.Domain.Entities.Transportador", "Transportador")
                        .WithOne("Veiculo")
                        .HasForeignKey("Global.Fretes.Domain.Entities.Veiculo", "TransportadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Transportador");
                });

            modelBuilder.Entity("Global.Fretes.Domain.Entities.Transportador", b =>
                {
                    b.Navigation("ConfiguracaoContaTransportador")
                        .IsRequired();

                    b.Navigation("ConfiguracaoFreteTransportador")
                        .IsRequired();

                    b.Navigation("Veiculo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}