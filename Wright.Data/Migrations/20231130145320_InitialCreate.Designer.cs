﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wright.Data;

#nullable disable

namespace Wright.Data.Migrations
{
    [DbContext(typeof(WrightDbContext))]
    [Migration("20231130145320_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wright.Data.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryEntityId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Wright.Data.Entities.ListingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListingEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ListingEntityId");

                    b.HasIndex("TypeId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Wright.Data.Entities.MowerTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Electric")
                        .HasColumnType("bit");

                    b.Property<int?>("MowerTypeEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PoweredAssist")
                        .HasColumnType("bit");

                    b.Property<bool>("RidingMower")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MowerTypeEntityId");

                    b.ToTable("MowerTypes");
                });

            modelBuilder.Entity("Wright.Data.Entities.SalesInventoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("ListingNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("SalesInventoryEntities");
                });

            modelBuilder.Entity("Wright.Data.Entities.CategoryEntity", b =>
                {
                    b.HasOne("Wright.Data.Entities.CategoryEntity", null)
                        .WithMany("Categories")
                        .HasForeignKey("CategoryEntityId");
                });

            modelBuilder.Entity("Wright.Data.Entities.ListingEntity", b =>
                {
                    b.HasOne("Wright.Data.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wright.Data.Entities.ListingEntity", null)
                        .WithMany("Listings")
                        .HasForeignKey("ListingEntityId");

                    b.HasOne("Wright.Data.Entities.MowerTypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Wright.Data.Entities.MowerTypeEntity", b =>
                {
                    b.HasOne("Wright.Data.Entities.MowerTypeEntity", null)
                        .WithMany("MowerTypes")
                        .HasForeignKey("MowerTypeEntityId");
                });

            modelBuilder.Entity("Wright.Data.Entities.SalesInventoryEntity", b =>
                {
                    b.HasOne("Wright.Data.Entities.ListingEntity", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("Wright.Data.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Wright.Data.Entities.ListingEntity", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("Wright.Data.Entities.MowerTypeEntity", b =>
                {
                    b.Navigation("MowerTypes");
                });
#pragma warning restore 612, 618
        }
    }
}