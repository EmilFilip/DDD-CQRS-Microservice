﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STC.Customer.Infrastructure.DBContexts;

namespace STC.Customer.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20210420170434_CustomerTableAddUpdatedColumn")]
    partial class CustomerTableAddUpdatedColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("STC.Customer.Infrastructure.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Updated")
                        .HasColumnType("bit");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
