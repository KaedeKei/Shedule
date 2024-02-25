﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shedule.Data;

#nullable disable

namespace Shedule.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240225002146_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("Shedule.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDebtor")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Shedule.Models.DeliveryEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EventDeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventPointId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRelevant")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventManagerId");

                    b.HasIndex("EventPointId");

                    b.ToTable("DeliveryEvents");
                });

            modelBuilder.Entity("Shedule.Models.DeliveryPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeliveryDay")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PointName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ThisCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ThisManagerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ThisCustomerId");

                    b.HasIndex("ThisManagerId");

                    b.ToTable("DeliveryPoints");
                });

            modelBuilder.Entity("Shedule.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ManagerPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ManagerStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Shedule.Models.DeliveryEvent", b =>
                {
                    b.HasOne("Shedule.Models.Manager", "EventManager")
                        .WithMany()
                        .HasForeignKey("EventManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shedule.Models.DeliveryPoint", "EventPoint")
                        .WithMany()
                        .HasForeignKey("EventPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventManager");

                    b.Navigation("EventPoint");
                });

            modelBuilder.Entity("Shedule.Models.DeliveryPoint", b =>
                {
                    b.HasOne("Shedule.Models.Customer", "ThisCustomer")
                        .WithMany()
                        .HasForeignKey("ThisCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shedule.Models.Manager", "ThisManager")
                        .WithMany()
                        .HasForeignKey("ThisManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThisCustomer");

                    b.Navigation("ThisManager");
                });
#pragma warning restore 612, 618
        }
    }
}