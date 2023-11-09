﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Author", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Pierce",
                            LastName = "Brown"
                        });
                });

            modelBuilder.Entity("backend.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int?>("SeriesId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SeriesId");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            SeriesId = 1,
                            Title = "Red Rising"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            SeriesId = 1,
                            Title = "Golden Son"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            SeriesId = 1,
                            Title = "Morning Star"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 1,
                            SeriesId = 1,
                            Title = "Iron Gold"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 1,
                            SeriesId = 1,
                            Title = "Dark Age"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 1,
                            SeriesId = 1,
                            Title = "Light Bringer"
                        });
                });

            modelBuilder.Entity("backend.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("PostId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("backend.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Series", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Name = "Red Rising"
                        });
                });

            modelBuilder.Entity("backend.Models.Book", b =>
                {
                    b.HasOne("backend.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Series", "Series")
                        .WithMany("Books")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("backend.Models.Series", b =>
                {
                    b.HasOne("backend.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("backend.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("backend.Models.Series", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
