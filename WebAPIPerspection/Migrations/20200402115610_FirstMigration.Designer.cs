﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Migrations
{
    [DbContext(typeof(PrescriptionDbContext))]
    [Migration("20200402115610_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPIPerspection.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("Birth_date")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<int>("Height");

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Mobile_phone");

                    b.Property<string>("PersonType")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnName("Sex");

                    b.Property<int>("Weight");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("PersonId");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("PersonType").HasValue("Person");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Prescription", b =>
                {
                    b.Property<long>("PrescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Analyse");

                    b.Property<string>("BillingState")
                        .IsRequired();

                    b.Property<long?>("PatientPersonId");

                    b.Property<long?>("PrescriberPersonId");

                    b.Property<decimal>("Price_analyses");

                    b.Property<decimal>("Price_shipping");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Tube");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("PatientPersonId");

                    b.HasIndex("PrescriberPersonId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Patient", b =>
                {
                    b.HasBaseType("WebAPIPerspection.Models.Person");

                    b.Property<string>("Home_phone");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Prescriber", b =>
                {
                    b.HasBaseType("WebAPIPerspection.Models.Person");

                    b.Property<string>("Office_phone");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Prescriber");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Prescription", b =>
                {
                    b.HasOne("WebAPIPerspection.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientPersonId");

                    b.HasOne("WebAPIPerspection.Models.Prescriber", "Prescriber")
                        .WithMany()
                        .HasForeignKey("PrescriberPersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
