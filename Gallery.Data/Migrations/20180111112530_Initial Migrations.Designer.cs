﻿// <auto-generated />
using Gallery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Gallery.Data.Migrations
{
    [DbContext(typeof(GalleryDbContext))]
    [Migration("20180111112530_Initial Migrations")]
    partial class InitialMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gallery.Data.Models.GalleryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("GalleryImages");
                });

            modelBuilder.Entity("Gallery.Data.Models.ImageTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("GalleryImageId");

                    b.HasKey("Id");

                    b.HasIndex("GalleryImageId");

                    b.ToTable("ImageTags");
                });

            modelBuilder.Entity("Gallery.Data.Models.ImageTag", b =>
                {
                    b.HasOne("Gallery.Data.Models.GalleryImage")
                        .WithMany("Tags")
                        .HasForeignKey("GalleryImageId");
                });
#pragma warning restore 612, 618
        }
    }
}
