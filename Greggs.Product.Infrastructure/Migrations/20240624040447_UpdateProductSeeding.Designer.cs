﻿// <auto-generated />
using System;
using Greggs.Products.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Greggs.Products.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240624040447_UpdateProductSeeding")]
    partial class UpdateProductSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Greggs.Products.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "BREAKFAST"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "HOT FOOD"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "SAVOURIES & BAKES"
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "DRINKS & SNACKS"
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "SANDWICHES & SALADS"
                        },
                        new
                        {
                            CategoryID = 6,
                            Name = "SWEET TREATS"
                        });
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExchangeRateToPounds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            Code = "EU",
                            Currency = "EUR",
                            ExchangeRateToPounds = 1.11m,
                            Name = "Europe"
                        });
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.Nutrient", b =>
                {
                    b.Property<int>("NutrientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NutrientID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NutrientID");

                    b.ToTable("Nutrients");

                    b.HasData(
                        new
                        {
                            NutrientID = 1,
                            Name = "Carbohydrates",
                            Unit = "g"
                        },
                        new
                        {
                            NutrientID = 2,
                            Name = "Protein",
                            Unit = "g"
                        },
                        new
                        {
                            NutrientID = 3,
                            Name = "Fats",
                            Unit = "g"
                        },
                        new
                        {
                            NutrientID = 4,
                            Name = "Energy kJ",
                            Unit = "kcal"
                        },
                        new
                        {
                            NutrientID = 5,
                            Name = "Energy kcal",
                            Unit = "kJ"
                        },
                        new
                        {
                            NutrientID = 6,
                            Name = "Sugars",
                            Unit = "g"
                        },
                        new
                        {
                            NutrientID = 7,
                            Name = "Salt",
                            Unit = "g"
                        },
                        new
                        {
                            NutrientID = 8,
                            Name = "of which Saturates",
                            Unit = "g"
                        },
                        new
                        {
                            NutrientID = 9,
                            Name = "of which Sugars",
                            Unit = "g"
                        });
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.NutritionalInformation", b =>
                {
                    b.Property<int>("NutritionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NutritionID"));

                    b.Property<decimal>("Measurement")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NutrientID")
                        .HasColumnType("int");

                    b.Property<decimal>("NutritionalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("NutritionID");

                    b.HasIndex("NutrientID");

                    b.HasIndex("ProductID");

                    b.ToTable("NutritionalInformation");

                    b.HasData(
                        new
                        {
                            NutritionID = 1,
                            Measurement = 100m,
                            NutrientID = 1,
                            NutritionalValue = 30m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 2,
                            Measurement = 100m,
                            NutrientID = 2,
                            NutritionalValue = 12m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 3,
                            Measurement = 100m,
                            NutrientID = 3,
                            NutritionalValue = 15m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 4,
                            Measurement = 100m,
                            NutrientID = 4,
                            NutritionalValue = 300m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 5,
                            Measurement = 100m,
                            NutrientID = 5,
                            NutritionalValue = 1256m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 6,
                            Measurement = 100m,
                            NutrientID = 6,
                            NutritionalValue = 3m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 7,
                            Measurement = 100m,
                            NutrientID = 7,
                            NutritionalValue = 1.5m,
                            ProductID = 1
                        },
                        new
                        {
                            NutritionID = 8,
                            Measurement = 100m,
                            NutrientID = 1,
                            NutritionalValue = 28m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 9,
                            Measurement = 100m,
                            NutrientID = 2,
                            NutritionalValue = 10m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 10,
                            Measurement = 100m,
                            NutrientID = 3,
                            NutritionalValue = 14m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 11,
                            Measurement = 100m,
                            NutrientID = 4,
                            NutritionalValue = 280m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 12,
                            Measurement = 100m,
                            NutrientID = 5,
                            NutritionalValue = 1172m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 13,
                            Measurement = 100m,
                            NutrientID = 6,
                            NutritionalValue = 2.5m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 14,
                            Measurement = 100m,
                            NutrientID = 7,
                            NutritionalValue = 1.2m,
                            ProductID = 2
                        },
                        new
                        {
                            NutritionID = 15,
                            Measurement = 100m,
                            NutrientID = 1,
                            NutritionalValue = 29m,
                            ProductID = 3
                        },
                        new
                        {
                            NutritionID = 16,
                            Measurement = 100m,
                            NutrientID = 2,
                            NutritionalValue = 11m,
                            ProductID = 3
                        },
                        new
                        {
                            NutritionID = 17,
                            Measurement = 100m,
                            NutrientID = 3,
                            NutritionalValue = 18m,
                            ProductID = 3
                        },
                        new
                        {
                            NutritionID = 18,
                            Measurement = 100m,
                            NutrientID = 4,
                            NutritionalValue = 290m,
                            ProductID = 3
                        },
                        new
                        {
                            NutritionID = 19,
                            Measurement = 100m,
                            NutrientID = 5,
                            NutritionalValue = 1215m,
                            ProductID = 3
                        },
                        new
                        {
                            NutritionID = 20,
                            Measurement = 100m,
                            NutrientID = 6,
                            NutritionalValue = 3m,
                            ProductID = 3
                        },
                        new
                        {
                            NutritionID = 21,
                            Measurement = 100m,
                            NutrientID = 7,
                            NutritionalValue = 1.7m,
                            ProductID = 3
                        });
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("PriceInPounds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 3,
                            CreatedDate = new DateTime(2018, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A delicious sausage roll.",
                            IsDeleted = false,
                            PriceInPounds = 1m,
                            ProductName = "Sausage Roll",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2641)
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 3,
                            CreatedDate = new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A tasty vegan sausage roll.",
                            IsDeleted = false,
                            PriceInPounds = 1.1m,
                            ProductName = "Vegan Sausage Roll",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2727)
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 3,
                            CreatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2732),
                            Description = "A savory steak bake.",
                            IsDeleted = false,
                            PriceInPounds = 1.2m,
                            ProductName = "Steak Bake",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2733)
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 6,
                            CreatedDate = new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A sweet treat.",
                            IsDeleted = false,
                            PriceInPounds = 0.7m,
                            ProductName = "Yum Yum",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2738)
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 6,
                            CreatedDate = new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A delicious pink jammie.",
                            IsDeleted = false,
                            PriceInPounds = 0.5m,
                            ProductName = "Pink Jammie",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2742)
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 5,
                            CreatedDate = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A spicy Mexican baguette.",
                            IsDeleted = false,
                            PriceInPounds = 2.1m,
                            ProductName = "Mexican Baguette",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2747)
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryID = 1,
                            CreatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2751),
                            Description = "A delicious bacon sandwich.",
                            IsDeleted = false,
                            PriceInPounds = 1.95m,
                            ProductName = "Bacon Sandwich",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2754)
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryID = 4,
                            CreatedDate = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A refreshing Coca Cola.",
                            IsDeleted = false,
                            PriceInPounds = 1.2m,
                            ProductName = "Coca Cola",
                            UpdatedDate = new DateTime(2024, 6, 24, 5, 4, 47, 95, DateTimeKind.Local).AddTicks(2759)
                        });
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.NutritionalInformation", b =>
                {
                    b.HasOne("Greggs.Products.Domain.Entities.Nutrient", "Nutrient")
                        .WithMany()
                        .HasForeignKey("NutrientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Greggs.Products.Domain.Entities.Product", "Product")
                        .WithMany("NutritionalInformations")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutrient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.Product", b =>
                {
                    b.HasOne("Greggs.Products.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Greggs.Products.Domain.Entities.Product", b =>
                {
                    b.Navigation("NutritionalInformations");
                });
#pragma warning restore 612, 618
        }
    }
}