﻿// <auto-generated />
using System;
using BankAccountProject.DbConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankAccountProject.DbConnection.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231112130553_v.01")]
    partial class v01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankAccountProject.Entities.BankAccount", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("aktif")
                        .HasColumnType("int");

                    b.Property<decimal?>("alacak")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("alacak_doviz")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("alacak_islem_doviz")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("alacak_sistem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("bakiye_sekli")
                        .HasColumnType("int");

                    b.Property<string>("birim_adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("borc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("borc_doviz")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("borc_islem_doviz")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("borc_sistem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("dovizkod")
                        .HasColumnType("int");

                    b.Property<string>("hesap_adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hesap_kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ust_hesap_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("BankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
