﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nomina.Models;

#nullable disable

namespace Nomina.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240620233257_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nomina.Entities.Abono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaAbono")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoAbono")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Abonos");
                });

            modelBuilder.Entity("Nomina.Entities.BonificacionDeGasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("concepto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("empleadoId")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("empleadoId");

                    b.ToTable("BonificacionDeGastos");
                });

            modelBuilder.Entity("Nomina.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("curp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("diasLaborales")
                        .HasColumnType("int");

                    b.Property<int>("empleoID")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salarioSem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("empleoID");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Nomina.Entities.Empleo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empleos");
                });

            modelBuilder.Entity("Nomina.Entities.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoOriginal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoRestante")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Nomina.Entities.Abono", b =>
                {
                    b.HasOne("Nomina.Entities.Prestamo", "Prestamo")
                        .WithMany("Abonos")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("Nomina.Entities.BonificacionDeGasto", b =>
                {
                    b.HasOne("Nomina.Entities.Empleado", "Empleado")
                        .WithMany("BonificacionesDeGastos")
                        .HasForeignKey("empleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Nomina.Entities.Empleado", b =>
                {
                    b.HasOne("Nomina.Entities.Empleo", "Empleo")
                        .WithMany("Empleados")
                        .HasForeignKey("empleoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleo");
                });

            modelBuilder.Entity("Nomina.Entities.Prestamo", b =>
                {
                    b.HasOne("Nomina.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Nomina.Entities.Empleado", b =>
                {
                    b.Navigation("BonificacionesDeGastos");
                });

            modelBuilder.Entity("Nomina.Entities.Empleo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Nomina.Entities.Prestamo", b =>
                {
                    b.Navigation("Abonos");
                });
#pragma warning restore 612, 618
        }
    }
}
