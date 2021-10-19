﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderItemDetailsAPI.Models;

namespace OrderItemDetailsAPI.Migrations
{
    [DbContext(typeof(OrderItemDetailsAPIContext))]
    [Migration("20211011164140_initialM")]
    partial class initialM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderItemDetailsAPI.Models.OrderItemDetail", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("ItemID");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int")
                        .HasColumnName("ToppingID");

                    b.HasKey("ItemId", "ToppingId")
                        .HasName("PK__OrderIte__3C9EAF25821F4CBA");

                    b.ToTable("OrderItemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}