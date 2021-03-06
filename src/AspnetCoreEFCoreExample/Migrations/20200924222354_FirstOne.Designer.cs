﻿// <auto-generated />
using AspnetCoreEFCoreExample;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AspnetCoreEFCoreExample.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20200924222354_FirstOne")]
    partial class FirstOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetCoreEFCoreExample.Models.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Element");
                });

            modelBuilder.Entity("AspnetCoreEFCoreExample.Models.ElementMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ElementId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.HasIndex("UserId");

                    b.ToTable("ElementMember");
                });

            modelBuilder.Entity("AspnetCoreEFCoreExample.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AspnetCoreEFCoreExample.Models.Element", b =>
                {
                    b.HasOne("AspnetCoreEFCoreExample.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AspnetCoreEFCoreExample.Models.ElementMember", b =>
                {
                    b.HasOne("AspnetCoreEFCoreExample.Models.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspnetCoreEFCoreExample.Models.User", "User")
                        .WithMany("ElementMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
