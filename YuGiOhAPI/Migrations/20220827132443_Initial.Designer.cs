﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YuGiOhAPI.Data;

#nullable disable

namespace YuGiOhAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220827132443_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YuGiOhAPI.CardImages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrlSmall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CardImages");
                });

            modelBuilder.Entity("YuGiOhAPI.CardPrice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("amazonPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cardMarketPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coolstuffincPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ebayPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tcgPlayerPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CardPrice");
                });

            modelBuilder.Entity("YuGiOhAPI.CardSets", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("setCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("setName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("setPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("setRarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("setRarityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CardSets");
                });

            modelBuilder.Entity("YuGiOhAPI.Yugioh", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("archetype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("atribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("imageid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priceid")
                        .HasColumnType("int");

                    b.Property<string>("race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("setid")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("imageid");

                    b.HasIndex("priceid");

                    b.HasIndex("setid");

                    b.ToTable("YugiohDb");
                });

            modelBuilder.Entity("YuGiOhAPI.Yugioh", b =>
                {
                    b.HasOne("YuGiOhAPI.CardImages", "image")
                        .WithMany()
                        .HasForeignKey("imageid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuGiOhAPI.CardPrice", "price")
                        .WithMany()
                        .HasForeignKey("priceid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YuGiOhAPI.CardSets", "set")
                        .WithMany()
                        .HasForeignKey("setid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");

                    b.Navigation("price");

                    b.Navigation("set");
                });
#pragma warning restore 612, 618
        }
    }
}