﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Migrations
{
    [DbContext(typeof(PrescriptionDbContext))]
    partial class PrescriptionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Analyse", b =>
                {
                    b.Property<long>("AnalyseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<long?>("PrescriptionId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Selles");

                    b.Property<int>("Tube_gris");

                    b.Property<int>("Tube_rouge");

                    b.Property<int>("Tube_violet");

                    b.Property<string>("Tubes")
                        .IsRequired();

                    b.Property<int>("Urine_matin");

                    b.HasKey("AnalyseID");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Analyse");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Log", b =>
                {
                    b.Property<long>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Billing_state");

                    b.Property<string>("By")
                        .IsRequired();

                    b.Property<string>("Invoice_state");

                    b.Property<DateTime>("On");

                    b.Property<long?>("PrescriptionId");

                    b.Property<string>("State");

                    b.HasKey("LogID");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Mobile_phone");

                    b.Property<string>("PersonType")
                        .IsRequired();

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

                    b.Property<decimal>("Amount_paid");

                    b.Property<string>("Billing_state")
                        .IsRequired();

                    b.Property<string>("Dossier_glims");

                    b.Property<string>("Invoice_id");

                    b.Property<string>("Invoice_state")
                        .IsRequired();

                    b.Property<string>("Kit_shipping_no");

                    b.Property<long?>("PatientPersonId");

                    b.Property<string>("Payment_method")
                        .IsRequired();

                    b.Property<long?>("PrescriberPersonId");

                    b.Property<decimal>("Price_analyses");

                    b.Property<decimal>("Price_shipping");

                    b.Property<string>("Sample_shipping_no");

                    b.Property<string>("Shipped_by");

                    b.Property<string>("Shipped_on");

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("PrescriptionId");

                    b.HasIndex("PatientPersonId");

                    b.HasIndex("PrescriberPersonId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Patient", b =>
                {
                    b.HasBaseType("WebAPIPerspection.Models.Person");

                    b.Property<string>("Birth_date")
                        .IsRequired();

                    b.Property<int>("Height");

                    b.Property<string>("Home_phone");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnName("Sex");

                    b.Property<int>("Weight");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Analyse", b =>
                {
                    b.HasOne("WebAPIPerspection.Models.Prescription", "Prescription")
                        .WithMany("Analyses")
                        .HasForeignKey("PrescriptionId");
                });

            modelBuilder.Entity("WebAPIPerspection.Models.Log", b =>
                {
                    b.HasOne("WebAPIPerspection.Models.Prescription", "Prescription")
                        .WithMany("Logs")
                        .HasForeignKey("PrescriptionId");
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
