﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecipeBoxBE.Migrations
{
    [DbContext(typeof(RecipeBoxDbContext))]
    partial class RecipeBoxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ImgUrl")
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
                            ImgUrl = "data:image/jpeg;base64,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",
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

                    b.Property<string>("photoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RecipeId = 1,
                            ReviewString = "I love making this because it is so quick and easy!",
                            UserId = 1,
                            photoUrl = "https://avatars.githubusercontent.com/u/77301013?v=4",
                            userName = "Maddihalee"
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
