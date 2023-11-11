﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecipeBoxBE.Migrations
{
    [DbContext(typeof(RecipeBoxDbContext))]
    [Migration("20231111174829_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecipeBoxBE.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Quick Recipes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "American"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Holiday"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Indian"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Chinese"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Korean"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("RecipeBoxBE.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("CookTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Directions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CookTime = "5 Minutes",
                            Directions = "Put peanut butter on one piece of bread and jelly on the other. Combine",
                            Ingredients = "Peanut Butter, Jelly, 2 Slices Bread",
                            Name = "Peanut Butter and Jelly",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("RecipeBoxBE.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RecipeId = 1,
                            ReviewString = "I love making this because it is so quick and easy!",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("RecipeBoxBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirebaseUid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ThisisanEmail@email.com",
                            FirebaseUid = "123abc",
                            Name = "Madds"
                        });
                });

            modelBuilder.Entity("RecipeUser", b =>
                {
                    b.Property<int>("FavoriteRecipesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("FavoriteRecipesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RecipeUser");
                });

            modelBuilder.Entity("RecipeBoxBE.Models.Recipe", b =>
                {
                    b.HasOne("RecipeBoxBE.Models.Category", null)
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeBoxBE.Models.Review", b =>
                {
                    b.HasOne("RecipeBoxBE.Models.Recipe", null)
                        .WithMany("Reviews")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeUser", b =>
                {
                    b.HasOne("RecipeBoxBE.Models.Recipe", null)
                        .WithMany()
                        .HasForeignKey("FavoriteRecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeBoxBE.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeBoxBE.Models.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeBoxBE.Models.Recipe", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
