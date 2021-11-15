﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceLayer;

namespace ServiceLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200822120747_changed_movie_table-1")]
    partial class changed_movie_table1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceLayer.Model.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.HasIndex("ActorTypeId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            ActorTypeId = 1,
                            InsertedDate = new DateTime(2020, 8, 22, 22, 7, 46, 728, DateTimeKind.Local).AddTicks(7848),
                            Name = "Allu Arjun"
                        },
                        new
                        {
                            ActorId = 2,
                            ActorTypeId = 1,
                            InsertedDate = new DateTime(2020, 8, 22, 22, 7, 46, 733, DateTimeKind.Local).AddTicks(9155),
                            Name = "Ravi Teja"
                        },
                        new
                        {
                            ActorId = 3,
                            ActorTypeId = 1,
                            InsertedDate = new DateTime(2020, 8, 22, 22, 7, 46, 733, DateTimeKind.Local).AddTicks(9289),
                            Name = "Shree Ram"
                        },
                        new
                        {
                            ActorId = 4,
                            ActorTypeId = 1,
                            InsertedDate = new DateTime(2020, 8, 22, 22, 7, 46, 733, DateTimeKind.Local).AddTicks(9306),
                            Name = "Jnr Ntr"
                        });
                });

            modelBuilder.Entity("ServiceLayer.Model.ActorType", b =>
                {
                    b.Property<int>("ActorTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorTypeId");

                    b.ToTable("ActorTypes");

                    b.HasData(
                        new
                        {
                            ActorTypeId = 1,
                            Name = "Actor"
                        },
                        new
                        {
                            ActorTypeId = 2,
                            Name = "Actress"
                        });
                });

            modelBuilder.Entity("ServiceLayer.Model.MovieDetail", b =>
                {
                    b.Property<int>("MovieDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieDetailId");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("ServiceLayer.Model.Movies", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlternateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Awards")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YouTubeLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("imdbId")
                        .HasColumnType("int");

                    b.Property<int>("imdbrating")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            InsertedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Released = new DateTime(2020, 8, 22, 22, 7, 46, 734, DateTimeKind.Local).AddTicks(3060),
                            Title = "Kalyanam",
                            imdbId = 0,
                            imdbrating = 4
                        });
                });

            modelBuilder.Entity("ServiceLayer.Model.Actor", b =>
                {
                    b.HasOne("ServiceLayer.Model.ActorType", null)
                        .WithMany("Actors")
                        .HasForeignKey("ActorTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceLayer.Model.MovieDetail", b =>
                {
                    b.HasOne("ServiceLayer.Model.Actor", "Actor")
                        .WithMany("MovieDetails")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceLayer.Model.Movies", "Movie")
                        .WithMany("MovieDetails")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
