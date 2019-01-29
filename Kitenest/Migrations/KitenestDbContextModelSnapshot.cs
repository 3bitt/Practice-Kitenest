﻿// <auto-generated />
using System;
using Kitenest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kitenest.Migrations
{
    [DbContext(typeof(KitenestDbContext))]
    partial class KitenestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kitenest.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Kitenest.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("Kitenest.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Kitenest.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City_id");

                    b.Property<int>("Continent_id");

                    b.Property<string>("Country");

                    b.Property<int>("Mobile");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<int?>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("City_id");

                    b.HasIndex("Continent_id");

                    b.HasIndex("SchoolId");

                    b.ToTable("School");
                });

            modelBuilder.Entity("Kitenest.Models.SchoolTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("closeHour");

                    b.Property<DateTime>("openHour");

                    b.Property<DateTime>("workingFrom");

                    b.Property<DateTime>("workingTo");

                    b.HasKey("Id");

                    b.ToTable("SchoolTime");
                });

            modelBuilder.Entity("Kitenest.Models.School", b =>
                {
                    b.HasOne("Kitenest.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("City_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kitenest.Models.Continent", "Continent")
                        .WithMany()
                        .HasForeignKey("Continent_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kitenest.Models.School")
                        .WithMany("getSchools")
                        .HasForeignKey("SchoolId");
                });
#pragma warning restore 612, 618
        }
    }
}
