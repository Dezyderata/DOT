﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeightWatcherApp.Infrastructure.Context;

namespace WeightWatcherApp.Infrastructure.Migrations
{
    [DbContext(typeof(WeightWatcherContext))]
    partial class WeightWatcherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("WeightWatcherApp.Infrastructure.Model.Measurement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Bmi");

                    b.Property<int>("DateOfCreation");

                    b.Property<int>("DateOfUpdate");

                    b.Property<long?>("UserId");

                    b.Property<float>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("WeightWatcherApp.Infrastructure.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DateOfCreation");

                    b.Property<int>("DateOfUpdate");

                    b.Property<string>("FirstName");

                    b.Property<float>("Hight");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("WeightWatcherApp.Infrastructure.Model.Measurement", b =>
                {
                    b.HasOne("WeightWatcherApp.Infrastructure.Model.User", "User")
                        .WithMany("Measurements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
