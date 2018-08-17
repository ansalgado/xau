﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using xau.Models;

namespace xau.Migrations
{
    [DbContext(typeof(XauContext))]
    [Migration("20180816234458_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("xau.Models.Entrega", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Fecha");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProveedorID");

                    b.Property<int>("RecolectorID");

                    b.HasKey("ID");

                    b.HasIndex("ProveedorID");

                    b.HasIndex("RecolectorID");

                    b.ToTable("Entrega");
                });

            modelBuilder.Entity("xau.Models.Proveedor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("xau.Models.Recolector", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Recolector");
                });

            modelBuilder.Entity("xau.Models.Entrega", b =>
                {
                    b.HasOne("xau.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("xau.Models.Recolector", "Recolector")
                        .WithMany()
                        .HasForeignKey("RecolectorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
