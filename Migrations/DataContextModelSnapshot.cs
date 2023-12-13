﻿// <auto-generated />
using System;
using DatovyPortalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatovyPortalApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DatovyPortalApp.Models.DiagnosisCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiagnosisCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.IndicatorCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSet")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IndicatorCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.PeriodCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeriodCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.RegionCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegionCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.SetCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SetCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.StadiumCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StadiumCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiagnosisId")
                        .HasColumnType("int");

                    b.Property<int>("IndicatorId")
                        .HasColumnType("int");

                    b.Property<double?>("LowerLimit")
                        .HasColumnType("float");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int?>("SampleSize")
                        .HasColumnType("int");

                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.Property<int>("StatisticsId")
                        .HasColumnType("int");

                    b.Property<double?>("UpperLimit")
                        .HasColumnType("float");

                    b.Property<double?>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("IndicatorId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SetId");

                    b.HasIndex("StadiumId");

                    b.HasIndex("StatisticsId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.StatisticsCodeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatisticsCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.Statistics", b =>
                {
                    b.HasOne("DatovyPortalApp.Models.DiagnosisCodeList", "DiagnosisCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatovyPortalApp.Models.IndicatorCodeList", "IndicatorCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatovyPortalApp.Models.PeriodCodeList", "PeriodCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatovyPortalApp.Models.RegionCodeList", "RegionCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatovyPortalApp.Models.SetCodeList", "SetCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatovyPortalApp.Models.StadiumCodeList", "StadiumCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatovyPortalApp.Models.StatisticsCodeList", "StatisticsCodeList")
                        .WithMany("Statistics")
                        .HasForeignKey("StatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiagnosisCodeList");

                    b.Navigation("IndicatorCodeList");

                    b.Navigation("PeriodCodeList");

                    b.Navigation("RegionCodeList");

                    b.Navigation("SetCodeList");

                    b.Navigation("StadiumCodeList");

                    b.Navigation("StatisticsCodeList");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.DiagnosisCodeList", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.IndicatorCodeList", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.PeriodCodeList", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.RegionCodeList", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.SetCodeList", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.StadiumCodeList", b =>
                {
                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("DatovyPortalApp.Models.StatisticsCodeList", b =>
                {
                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
