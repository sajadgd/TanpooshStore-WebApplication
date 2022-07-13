﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TanpooshStore.Presistence.Context;

namespace TanpooshStore.Presistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220316093931_Mig7_ChangeAllowNullUserEntity")]
    partial class Mig7_ChangeAllowNullUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TanpooshStore.Domain.Entities.AdminSidebar.AdminMenuEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Menu_Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_AdminMenu");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.AdminSidebar.AdminSubMenuEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Menu_Id")
                        .HasColumnType("int");

                    b.Property<string>("Sub_Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Menu_Id");

                    b.ToTable("Tbl_AdminSubMenu");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.Users.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.Users.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Tbl_Users");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.Users.UserInRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Tbl_UserInRole");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.AdminSidebar.AdminSubMenuEntity", b =>
                {
                    b.HasOne("TanpooshStore.Domain.Entities.AdminSidebar.AdminMenuEntity", "AdminMenu")
                        .WithMany("SubMenu")
                        .HasForeignKey("Menu_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminMenu");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.Users.UserInRoleEntity", b =>
                {
                    b.HasOne("TanpooshStore.Domain.Entities.Users.RoleEntity", "Role")
                        .WithMany("UserInRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TanpooshStore.Domain.Entities.Users.UserEntity", "User")
                        .WithMany("UserInRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.AdminSidebar.AdminMenuEntity", b =>
                {
                    b.Navigation("SubMenu");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.Users.RoleEntity", b =>
                {
                    b.Navigation("UserInRole");
                });

            modelBuilder.Entity("TanpooshStore.Domain.Entities.Users.UserEntity", b =>
                {
                    b.Navigation("UserInRole");
                });
#pragma warning restore 612, 618
        }
    }
}