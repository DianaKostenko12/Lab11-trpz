﻿// <auto-generated />
using System;
using Lab11.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab11.Migrations
{
    [DbContext(typeof(AirportDbContext))]
    partial class AirportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab11.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            FlightId = 1,
                            Destination = "New York",
                            FlightNumber = "AA123"
                        },
                        new
                        {
                            FlightId = 2,
                            Destination = "London",
                            FlightNumber = "BA456"
                        },
                        new
                        {
                            FlightId = 3,
                            Destination = "Tokyo",
                            FlightNumber = "CA789"
                        });
                });

            modelBuilder.Entity("Lab11.Models.FlightRoute", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("RouteDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteId");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightRoutes");

                    b.HasData(
                        new
                        {
                            RouteId = 1,
                            FlightId = 1,
                            RouteDetails = "NYC to JFK"
                        },
                        new
                        {
                            RouteId = 2,
                            FlightId = 2,
                            RouteDetails = "LHR to Heathrow"
                        },
                        new
                        {
                            RouteId = 3,
                            FlightId = 3,
                            RouteDetails = "HND to Narita"
                        });
                });

            modelBuilder.Entity("Lab11.Models.FlightSchedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightSchedules");

                    b.HasData(
                        new
                        {
                            ScheduleId = 1,
                            DepartureDate = new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            FlightId = 1
                        },
                        new
                        {
                            ScheduleId = 2,
                            DepartureDate = new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            FlightId = 2
                        },
                        new
                        {
                            ScheduleId = 3,
                            DepartureDate = new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            FlightId = 3
                        });
                });

            modelBuilder.Entity("Lab11.Models.FlightRoute", b =>
                {
                    b.HasOne("Lab11.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Lab11.Models.FlightSchedule", b =>
                {
                    b.HasOne("Lab11.Models.Flight", "Flight")
                        .WithMany("FlightSchedules")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Lab11.Models.Flight", b =>
                {
                    b.Navigation("FlightSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
