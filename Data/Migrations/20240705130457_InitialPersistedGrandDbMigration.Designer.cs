﻿// <auto-generated />
using System;
using CarAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarAPI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240705130457_InitialPersistedGrandDbMigration")]
    partial class InitialPersistedGrandDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarAPI.Models.Light", b =>
                {
                    b.Property<int>("LightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LightId"));

                    b.Property<int>("Angle")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FogLights")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HeadLights")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LightId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Lights");
                });

            modelBuilder.Entity("CarAPI.Models.Light", b =>
                {
                    b.HasOne("CarAPI.Models.Car", "Car")
                        .WithOne("Light")
                        .HasForeignKey("CarAPI.Models.Light", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarAPI.Models.Car", b =>
                {
                    b.Navigation("Light");
                });
#pragma warning restore 612, 618
        }
    }
}