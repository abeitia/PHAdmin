﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PHAdmin.API.DbContexts;

#nullable disable

namespace PHAdmin.API.Migrations
{
    [DbContext(typeof(PHAdminContext))]
    partial class PHAdminContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PHAdmin.API.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Letter")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("CONVERT([varchar](2),[Floor]) + '-' + [Letter]");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(678),
                            Floor = 1,
                            Letter = "A",
                            Status = "A"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(690),
                            Floor = 1,
                            Letter = "B",
                            Status = "A"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(691),
                            Floor = 1,
                            Letter = "C",
                            Status = "A"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2022, 11, 21, 16, 39, 33, 84, DateTimeKind.Local).AddTicks(692),
                            Floor = 2,
                            Letter = "A",
                            Status = "A"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
