﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShiloApi;

namespace ShiloApi.Migrations
{
    [DbContext(typeof(ShiloShopContext))]
    [Migration("20220101205823_Students.studentID")]
    partial class StudentsstudentID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShiloApi.Custumer", b =>
                {
                    b.Property<string>("CustumerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PasWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("CustumerID");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShiloApi.Orders", b =>
                {
                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustumerAddres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustumerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("prodactbandName")
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("date");

                    b.HasIndex("CustumerID");

                    b.HasIndex("prodactbandName");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShiloApi.Prodacts", b =>
                {
                    b.Property<string>("bandName")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("conectionNumber")
                        .HasColumnType("int");

                    b.Property<string>("instrument")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bandName");

                    b.HasIndex("bandName")
                        .IsUnique();

                    b.ToTable("Prodacts");
                });

            modelBuilder.Entity("ShiloApi.Students", b =>
                {
                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instrument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("date");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ShiloApi.Orders", b =>
                {
                    b.HasOne("ShiloApi.Custumer", null)
                        .WithMany("orders")
                        .HasForeignKey("CustumerID");

                    b.HasOne("ShiloApi.Prodacts", "prodact")
                        .WithMany()
                        .HasForeignKey("prodactbandName");
                });
#pragma warning restore 612, 618
        }
    }
}