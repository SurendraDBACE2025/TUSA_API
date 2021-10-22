﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TUSA.Data;

namespace TUSA.API.Migrations
{
    [DbContext(typeof(TUSAContext))]
    [Migration("20211007025431_Loginlog")]
    partial class Loginlog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TUSA.Domain.Entities.Settings.Role", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Role_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Role_Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TUSA.Domain.Entities.UserLoginFail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserLoginFail");
                });

            modelBuilder.Entity("TUSA.Domain.Entities.UserLoginLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LoginAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("User_Name");

                    b.ToTable("UserLoginLog");
                });

            modelBuilder.Entity("TUSA.Domain.Entities.UserMaster.user_master", b =>
                {
                    b.Property<string>("User_Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Activation_code")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Contact_Number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email_Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("First_Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Is_Activated")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Is_Active")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Is_Deleted")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("Last_Login_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Last_Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Last_Reset_Attempt_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Password_Changed_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reset_Password_Date")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("User_Type_Id")
                        .HasColumnType("int");

                    b.Property<int?>("User_Type_Id1")
                        .HasColumnType("int");

                    b.HasKey("User_Name");

                    b.HasIndex("User_Type_Id1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TUSA.Domain.Entities.UserMaster.UserType", b =>
                {
                    b.Property<int>("User_Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("User_Type_Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("User_Type_Id");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("TUSA.Domain.Entities.UserLoginLog", b =>
                {
                    b.HasOne("TUSA.Domain.Entities.UserMaster.user_master", "user_master")
                        .WithMany()
                        .HasForeignKey("User_Name")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("user_master");
                });

            modelBuilder.Entity("TUSA.Domain.Entities.UserMaster.user_master", b =>
                {
                    b.HasOne("TUSA.Domain.Entities.UserMaster.UserType", "User_Type")
                        .WithMany()
                        .HasForeignKey("User_Type_Id1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User_Type");
                });
#pragma warning restore 612, 618
        }
    }
}
