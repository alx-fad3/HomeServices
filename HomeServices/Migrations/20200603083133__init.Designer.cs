﻿// <auto-generated />
using System;
using HomeServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeServices.Migrations
{
    [DbContext(typeof(HomeDbContext))]
    [Migration("20200603083133__init")]
    partial class _init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeServices.Models.DirectoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DirectoryModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Init"
                        });
                });

            modelBuilder.Entity("HomeServices.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DirectoryId")
                        .HasColumnType("int");

                    b.Property<int?>("DirectoryModelId")
                        .HasColumnType("int");

                    b.Property<bool>("Exists")
                        .HasColumnType("bit");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryModelId");

                    b.ToTable("FileModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Exists = false,
                            Name = "Init",
                            Size = 0.0
                        });
                });

            modelBuilder.Entity("HomeServices.Models.FileModel", b =>
                {
                    b.HasOne("HomeServices.Models.DirectoryModel", "DirectoryModel")
                        .WithMany("Files")
                        .HasForeignKey("DirectoryModelId");
                });
#pragma warning restore 612, 618
        }
    }
}