﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopOnline.Api.Data;

#nullable disable

namespace ShopOnline.Api.Migrations
{
    [DbContext(typeof(ShopOnlineDbContext))]
    partial class ShopOnlineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShopOnline.Api.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "	Position all 4 balls to the inside, then all to the outside",
                            ImageURL = "/Images/Puzzle/Crossroads.png",
                            IsActive = false,
                            Name = "Crossroads",
                            Price = 20m,
                            Qty = 45
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Remove the ring",
                            ImageURL = "/Images/Puzzle/IqTest.png",
                            IsActive = false,
                            Name = "IQ Test",
                            Price = 20m,
                            Qty = 60
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Open the box",
                            ImageURL = "/Images/Puzzle/LotusBox.png",
                            IsActive = false,
                            Name = "Lotus Box",
                            Price = 30m,
                            Qty = 85
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Place all pieces into the frame with square in a different",
                            ImageURL = "/Images/Puzzle/NoFit.png",
                            IsActive = false,
                            Name = "No Fit",
                            Price = 25m,
                            Qty = 50
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Remove the Owl from the Cage",
                            ImageURL = "/Images/Puzzle/OwlInCage.png",
                            IsActive = false,
                            Name = "Owl In Cage",
                            Price = 40m,
                            Qty = 200
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Take apart the pieces and put back together.",
                            ImageURL = "/Images/Puzzle/AztecSunStone.png",
                            IsActive = false,
                            Name = "Aztec Sun Stone",
                            Price = 10m,
                            Qty = 20
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Remove the marble from the box",
                            ImageURL = "/Images/Puzzle/FreeTheMarble.png",
                            IsActive = false,
                            Name = "Free The Marble",
                            Price = 20m,
                            Qty = 30
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Description = "Release the round tap.",
                            ImageURL = "/Images/Puzzle/TheTap.png",
                            IsActive = false,
                            Name = "The Tap",
                            Price = 30m,
                            Qty = 100
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            Description = "Open the lock",
                            ImageURL = "/Images/Puzzle/Voidlock.png",
                            IsActive = false,
                            Name = "Voidlock",
                            Price = 45m,
                            Qty = 20
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IconCSS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IconCSS = "fas fa-heartbeat",
                            IsActive = false,
                            Level = 1,
                            Name = "Mortal"
                        },
                        new
                        {
                            Id = 2,
                            IconCSS = "fas fa-gavel",
                            IsActive = false,
                            Level = 2,
                            Name = "Hero"
                        },
                        new
                        {
                            Id = 3,
                            IconCSS = "fas fa-shield",
                            IsActive = false,
                            Level = 3,
                            Name = "Spartan"
                        },
                        new
                        {
                            Id = 4,
                            IconCSS = "fas fa-bolt",
                            IsActive = false,
                            Level = 4,
                            Name = "Godlike"
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DbCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumberOfLogins")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DbCreationDate = new DateTime(2023, 2, 20, 20, 48, 14, 715, DateTimeKind.Local).AddTicks(1772),
                            Password = "Password",
                            UserName = "Bob"
                        },
                        new
                        {
                            Id = 2,
                            DbCreationDate = new DateTime(2023, 2, 20, 20, 48, 14, 715, DateTimeKind.Local).AddTicks(1826),
                            Password = "Password",
                            UserName = "Sarah"
                        });
                });

            modelBuilder.Entity("ShopOnline.Api.Entities.Product", b =>
                {
                    b.HasOne("ShopOnline.Api.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
