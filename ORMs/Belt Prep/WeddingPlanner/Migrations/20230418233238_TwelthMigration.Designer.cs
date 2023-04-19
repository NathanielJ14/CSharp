﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingPlanner.Models;

#nullable disable

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230418233238_TwelthMigration")]
    partial class TwelthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeddingPlanner.Models.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("WeddingId")
                        .HasColumnType("int");

                    b.HasKey("GuestId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WedderOne")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WedderTwo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WeddingId");

                    b.HasIndex("UserId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.WeddingGuests", b =>
                {
                    b.Property<int>("WeddingGuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WeddingId")
                        .HasColumnType("int");

                    b.HasKey("WeddingGuestId");

                    b.HasIndex("GuestId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("WeddingGuests");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Guest", b =>
                {
                    b.HasOne("WeddingPlanner.Models.Wedding", null)
                        .WithMany("AllGuests")
                        .HasForeignKey("WeddingId");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "User")
                        .WithMany("AllWeddings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeddingPlanner.Models.WeddingGuests", b =>
                {
                    b.HasOne("WeddingPlanner.Models.Guest", null)
                        .WithMany("AllGuests")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingPlanner.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("WeddingPlanner.Models.Wedding", "Wedding")
                        .WithMany()
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Guest", b =>
                {
                    b.Navigation("AllGuests");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Navigation("AllWeddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Navigation("AllGuests");
                });
#pragma warning restore 612, 618
        }
    }
}