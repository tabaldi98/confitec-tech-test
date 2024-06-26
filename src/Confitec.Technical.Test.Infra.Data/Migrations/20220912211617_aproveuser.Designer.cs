﻿// <auto-generated />
using System;
using Confitec.Technical.Test.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    [DbContext(typeof(TechnicalTestContext))]
    [Migration("20220912211617_aproveuser")]
    partial class aproveuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Confitec.Technical.Test.Domain.ParametersModule.Parameter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastDateUpdated")
                        .HasMaxLength(255)
                        .HasColumnType("datetime");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("Parameters", "dbo");

                    b.HasData(
                        new
                        {
                            ID = 2,
                            Key = "SESSION_TIME",
                            LastDateUpdated = new DateTime(2022, 9, 12, 18, 16, 17, 551, DateTimeKind.Local).AddTicks(4747),
                            Value = "120"
                        });
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.RecoveryPasswordModule.RecoveryPassword", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<int>("SystemUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SystemUserID");

                    b.ToTable("RecoveryPassword", "dbo");
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.SystemUserModule.Permissions.Permission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("SystemUserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SystemUserId");

                    b.ToTable("SystemUserPermissions", "dbo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Role = "CanManageSystemUsers",
                            SystemUserId = 1
                        },
                        new
                        {
                            ID = 2,
                            Role = "CanManageObjects",
                            SystemUserId = 1
                        },
                        new
                        {
                            ID = 3,
                            Role = "CanChangeGeneralSettings",
                            SystemUserId = 1
                        });
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.SystemUserModule.SystemUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsAproved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LastUpdatePasswordDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("SystemUsers", "dbo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreateDate = new DateTime(2022, 9, 12, 18, 16, 17, 551, DateTimeKind.Local).AddTicks(4648),
                            FullName = "Administrador do Sistema",
                            IsAproved = true,
                            LastUpdatePasswordDate = new DateTime(2022, 9, 12, 18, 16, 17, 551, DateTimeKind.Local).AddTicks(4655),
                            Mail = "andersonandi_t@hotmail.com",
                            Password = "123",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.UserModule.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<byte>("Scholarity")
                        .HasColumnType("tinyint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.RecoveryPasswordModule.RecoveryPassword", b =>
                {
                    b.HasOne("Confitec.Technical.Test.Domain.SystemUserModule.SystemUser", "SystemUser")
                        .WithMany("RecoveryPasswords")
                        .HasForeignKey("SystemUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.SystemUserModule.Permissions.Permission", b =>
                {
                    b.HasOne("Confitec.Technical.Test.Domain.SystemUserModule.SystemUser", "SystemUser")
                        .WithMany("Permissions")
                        .HasForeignKey("SystemUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("Confitec.Technical.Test.Domain.SystemUserModule.SystemUser", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RecoveryPasswords");
                });
#pragma warning restore 612, 618
        }
    }
}
