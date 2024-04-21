﻿// <auto-generated />
using System;
using AppPeluqueriaMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppPeluqueriaMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Id_Empleado")
                        .HasColumnType("int");

                    b.Property<string>("TipoServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Cliente");

                    b.HasIndex("Id_Empleado");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.CitaCosmetico", b =>
                {
                    b.Property<int>("CitaId")
                        .HasColumnType("int");

                    b.Property<int>("CosmeticoId")
                        .HasColumnType("int");

                    b.HasKey("CitaId", "CosmeticoId");

                    b.HasIndex("CosmeticoId");

                    b.ToTable("CitaCosmetico");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NumInt")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tratamientos")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DNI")
                        .IsUnique();

                    b.HasIndex("Telefono")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Cosmetico", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Codigo");

                    b.ToTable("Cosmetico");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Sueldo")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("DNI")
                        .IsUnique();

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Cita", b =>
                {
                    b.HasOne("AppPeluqueriaMVC.Models.Cliente", "Cliente")
                        .WithMany("Citas")
                        .HasForeignKey("Id_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppPeluqueriaMVC.Models.Empleado", "Empleado")
                        .WithMany("Citas")
                        .HasForeignKey("Id_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.CitaCosmetico", b =>
                {
                    b.HasOne("AppPeluqueriaMVC.Models.Cita", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppPeluqueriaMVC.Models.Cosmetico", "Cosmetico")
                        .WithMany()
                        .HasForeignKey("CosmeticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Cosmetico");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Cliente", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("AppPeluqueriaMVC.Models.Empleado", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
