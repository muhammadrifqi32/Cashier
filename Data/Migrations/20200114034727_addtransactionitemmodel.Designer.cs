﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200114034727_addtransactionitemmodel")]
    partial class addtransactionitemmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Data.Model.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Data.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Data.Model.TransactionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DeleteDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionItems");
                });

            modelBuilder.Entity("Data.Model.Item", b =>
                {
                    b.HasOne("Data.Model.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Data.Model.TransactionItem", b =>
                {
                    b.HasOne("Data.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Data.Model.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");
                });
#pragma warning restore 612, 618
        }
    }
}
