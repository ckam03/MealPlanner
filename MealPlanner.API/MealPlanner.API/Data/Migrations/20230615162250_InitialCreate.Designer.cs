﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MealPlanner.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.API.Migrations
{
    [DbContext(typeof(MealDbContext))]
    [Migration("20230615162250_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealPlanner.API.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pantry");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid?>("MealPlanId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MealPlanId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.MealPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c2909dd-7c82-4234-bad5-4390d8c27061"),
                            Name = "Chickpea Pasta"
                        },
                        new
                        {
                            Id = new Guid("ded9a105-15bf-42de-ba11-f9c74321d2dc"),
                            Name = "Chickpea Salad"
                        },
                        new
                        {
                            Id = new Guid("5975f506-0ef6-4ed6-807c-5cba6463f6c2"),
                            Name = "Chicken Salad"
                        });
                });

            modelBuilder.Entity("MealPlanner.API.Entities.RecipeInstructions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Instructions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId")
                        .IsUnique();

                    b.ToTable("RecipeInstructions");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.ShoppingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.ShoppingListItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ShoppingListId")
                        .HasColumnType("uuid");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ListItems");
                });

            modelBuilder.Entity("MealPlanner.API.Features.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Jwt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.Meal", b =>
                {
                    b.HasOne("MealPlanner.API.Entities.MealPlan", null)
                        .WithMany("Meals")
                        .HasForeignKey("MealPlanId");

                    b.HasOne("MealPlanner.API.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.RecipeInstructions", b =>
                {
                    b.HasOne("MealPlanner.API.Entities.Recipe", null)
                        .WithOne("Instructions")
                        .HasForeignKey("MealPlanner.API.Entities.RecipeInstructions", "RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MealPlanner.API.Entities.ShoppingListItem", b =>
                {
                    b.HasOne("MealPlanner.API.Entities.ShoppingList", null)
                        .WithMany("ListItems")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MealPlanner.API.Entities.MealPlan", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("MealPlanner.API.Entities.Recipe", b =>
                {
                    b.Navigation("Instructions")
                        .IsRequired();
                });

            modelBuilder.Entity("MealPlanner.API.Entities.ShoppingList", b =>
                {
                    b.Navigation("ListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
