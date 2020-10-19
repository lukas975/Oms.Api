﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oms.Infrastructure;

namespace Oms.Api.Migrations
{
    [DbContext(typeof(OmsContext))]
    [Migration("20201019090707_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Oms.Domain.Entities.Cm", b =>
                {
                    b.Property<Guid>("CmsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FactoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Products")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CmsId");

                    b.HasIndex("FactoryId");

                    b.ToTable("Cms","oms");
                });

            modelBuilder.Entity("Oms.Domain.Entities.OrderDetails", b =>
                {
                    b.Property<Guid>("FactoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExpectedStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactoryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactoryCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionLineId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FactoryId");

                    b.ToTable("OrderDatails","oms");
                });

            modelBuilder.Entity("Oms.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<Guid>("Gtin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("SerialNumberType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Gtin");

                    b.ToTable("OrderProduct","oms");
                });

            modelBuilder.Entity("Oms.Domain.Entities.Cm", b =>
                {
                    b.HasOne("Oms.Domain.Entities.OrderDetails", "OrderDetails")
                        .WithMany("Cms")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}