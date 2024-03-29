﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tech_test_payment_api.Context;

#nullable disable

namespace techtestpaymentapi.Migrations
{
    [DbContext(typeof(VendaContext))]
    [Migration("20230104210614_CriacaoTabelaVenda")]
    partial class CriacaoTabelaVenda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tech_test_payment_api.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPFVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoProdutoVenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdVendedor")
                        .HasColumnType("int");

                    b.Property<string>("NomeVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusVenda")
                        .HasColumnType("int");

                    b.Property<string>("TelefoneVendedor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
