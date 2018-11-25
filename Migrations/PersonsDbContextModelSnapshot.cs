﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persons.Persistence;

namespace Persons.Migrations
{
    [DbContext(typeof(PersonsDbContext))]
    partial class PersonsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persons.Core.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Persons.Core.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Persons.Core.Domain.CompanyBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyBranches");
                });

            modelBuilder.Entity("Persons.Core.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<int>("CityId");

                    b.Property<int>("CompanyBranchId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyBranchId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Persons.Core.Domain.CompanyBranch", b =>
                {
                    b.HasOne("Persons.Core.Domain.Company", "Company")
                        .WithMany("Branches")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Persons.Core.Domain.Person", b =>
                {
                    b.HasOne("Persons.Core.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Persons.Core.Domain.CompanyBranch", "CompanyBranch")
                        .WithMany()
                        .HasForeignKey("CompanyBranchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
