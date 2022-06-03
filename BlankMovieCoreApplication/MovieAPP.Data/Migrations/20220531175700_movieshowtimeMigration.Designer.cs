﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAPP.Data.DataConnections;

namespace MovieAPP.Data.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    [Migration("20220531175700_movieshowtimeMigration")]
    partial class movieshowtimeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MovieAPP.Entity.MovieModel", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MovieLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("movieModel");
                });

            modelBuilder.Entity("MovieAPP.Entity.MovieShowTimeModel", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ShowTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.HasKey("ShowId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheaterId");

                    b.ToTable("movieShowTimeModels");
                });

            modelBuilder.Entity("MovieAPP.Entity.TheaterModel", b =>
                {
                    b.Property<int>("TheaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheaterLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheaterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TheaterId");

                    b.ToTable("theaterModel");
                });

            modelBuilder.Entity("MovieAPP.Entity.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("userModel");
                });

            modelBuilder.Entity("MovieAPP.Entity.MovieShowTimeModel", b =>
                {
                    b.HasOne("MovieAPP.Entity.MovieModel", "movieModel")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPP.Entity.TheaterModel", "theaterModel")
                        .WithMany()
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movieModel");

                    b.Navigation("theaterModel");
                });
#pragma warning restore 612, 618
        }
    }
}
