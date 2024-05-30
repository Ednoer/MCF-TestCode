﻿// <auto-generated />
using System;
using BpkbApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BpkbApi.Migrations
{
    [DbContext(typeof(BpkbContext))]
    [Migration("20240530161922_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BpkbApi.Models.MsStorageLocation", b =>
                {
                    b.Property<string>("LocationId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LocationId");

                    b.ToTable("MsStorageLocations");
                });

            modelBuilder.Entity("BpkbApi.Models.MsUser", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("MsUsers");
                });

            modelBuilder.Entity("BpkbApi.Models.TrBpkb", b =>
                {
                    b.Property<string>("AgreementNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BpkbDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BpkbDateIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("BpkbNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FakturDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FakturNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PoliceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgreementNumber");

                    b.HasIndex("LocationId");

                    b.ToTable("TrBpkbs");
                });

            modelBuilder.Entity("BpkbApi.Models.TrBpkb", b =>
                {
                    b.HasOne("BpkbApi.Models.MsStorageLocation", "Location")
                        .WithMany("TrBpkbs")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("BpkbApi.Models.MsStorageLocation", b =>
                {
                    b.Navigation("TrBpkbs");
                });
#pragma warning restore 612, 618
        }
    }
}
