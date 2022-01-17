﻿// <auto-generated />
using System;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Perstistance.Migrations
{
    [DbContext(typeof(WikiBeerSqlContext))]
    [Migration("20220117075527_tt2")]
    partial class tt2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeerEntityIngredientEntity", b =>
                {
                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BeerId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("BeerIngredient", (string)null);
                });

            modelBuilder.Entity("Entities.BeerColorEntity", b =>
                {
                    b.Property<Guid>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorID");

                    b.ToTable("BeerColor");
                });

            modelBuilder.Entity("Entities.BeerEntity", b =>
                {
                    b.Property<Guid>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BreweryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Degree")
                        .HasColumnType("real");

                    b.Property<float>("Ibu")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StyleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BeerId");

                    b.HasIndex("BreweryId");

                    b.HasIndex("ColorID");

                    b.HasIndex("StyleId");

                    b.ToTable("Beer");
                });

            modelBuilder.Entity("Entities.BeerStyleEntity", b =>
                {
                    b.Property<Guid>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StyleId");

                    b.ToTable("BeerStyle");
                });

            modelBuilder.Entity("Entities.BreweryEntity", b =>
                {
                    b.Property<Guid>("BreweryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BreweryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Brewery");
                });

            modelBuilder.Entity("Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Entities.IngredientEntity", b =>
                {
                    b.Property<Guid>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Discriminator")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HopEntity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredient");

                    b.HasDiscriminator<string>("HopEntity").HasValue("IngredientEntity");
                });

            modelBuilder.Entity("Entities.AdditiveEntity", b =>
                {
                    b.HasBaseType("Entities.IngredientEntity");

                    b.Property<string>("Use")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Ingredient");

                    b.HasDiscriminator().HasValue("AdditiveEntity");
                });

            modelBuilder.Entity("Entities.CerealEntity", b =>
                {
                    b.HasBaseType("Entities.IngredientEntity");

                    b.Property<float>("Ebc")
                        .HasColumnType("real");

                    b.ToTable("Ingredient");

                    b.HasDiscriminator().HasValue("CerealEntity");
                });

            modelBuilder.Entity("Entities.HopEntity", b =>
                {
                    b.HasBaseType("Entities.IngredientEntity");

                    b.Property<float>("AlphaAcid")
                        .HasColumnType("real");

                    b.ToTable("Ingredient");

                    b.HasDiscriminator().HasValue("HopEntity");
                });

            modelBuilder.Entity("BeerEntityIngredientEntity", b =>
                {
                    b.HasOne("Entities.BeerEntity", null)
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.IngredientEntity", null)
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.BeerEntity", b =>
                {
                    b.HasOne("Entities.BreweryEntity", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.BeerColorEntity", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.BeerStyleEntity", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");

                    b.Navigation("Color");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("Entities.BreweryEntity", b =>
                {
                    b.HasOne("Entities.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
