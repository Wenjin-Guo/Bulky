﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230620120845_1stMigration")]
    partial class _1stMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Horri"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Absolutely the best baby soap",
                            ImageUrl = "",
                            ListPrice = 20.0,
                            Manufacturer = "Delta",
                            Price = 18.0,
                            Price100 = 13.0,
                            Price50 = 15.0,
                            Title = "Baby sope",
                            UPCode = "SWD999901"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "xcvwert3rsdf",
                            ImageUrl = "",
                            ListPrice = 20.0,
                            Manufacturer = "Adidas",
                            Price = 18.0,
                            Price100 = 13.0,
                            Price50 = 15.0,
                            Title = "Bike",
                            UPCode = "SWD999902"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "e56cdzcwer5tdsfgdf",
                            ImageUrl = "",
                            ListPrice = 20.0,
                            Manufacturer = "Spicy Pot",
                            Price = 18.0,
                            Price100 = 13.0,
                            Price50 = 15.0,
                            Title = "Rice cooker",
                            UPCode = "SWD999903"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "sdafgrtuyrejs",
                            ImageUrl = "",
                            ListPrice = 20.0,
                            Manufacturer = "Yiwu",
                            Price = 18.0,
                            Price100 = 13.0,
                            Price50 = 15.0,
                            Title = "T shirt",
                            UPCode = "SWD999904"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.HasOne("Bulky.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
