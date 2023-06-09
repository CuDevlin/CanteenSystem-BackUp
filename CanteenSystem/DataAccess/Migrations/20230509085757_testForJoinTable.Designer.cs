﻿// <auto-generated />
using System;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfcDataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230509085757_testForJoinTable")]
    partial class testForJoinTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("AllergenIngredient", b =>
                {
                    b.Property<int>("AllergensCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AllergensCode", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("AllergenIngredient");
                });

            modelBuilder.Entity("Shared.Model.Allergen", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Code");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("Shared.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Shared.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("MenuDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuDate");

                    b.HasIndex("OrderId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Shared.Model.Menu", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Date");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Shared.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shared.Model.SupplyOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.ToTable("SupplyOrders");
                });

            modelBuilder.Entity("Shared.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AllergenIngredient", b =>
                {
                    b.HasOne("Shared.Model.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergensCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Model.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Model.Ingredient", b =>
                {
                    b.HasOne("Shared.Model.Item", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("Shared.Model.Item", b =>
                {
                    b.HasOne("Shared.Model.Menu", null)
                        .WithMany("Items")
                        .HasForeignKey("MenuDate");

                    b.HasOne("Shared.Model.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Shared.Model.Order", b =>
                {
                    b.HasOne("Shared.Model.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Shared.Model.SupplyOrder", b =>
                {
                    b.HasOne("Shared.Model.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Shared.Model.Item", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Shared.Model.Menu", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Shared.Model.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
