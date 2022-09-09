﻿// <auto-generated />
using System;
using Confitec.Technical.Test.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    [DbContext(typeof(TechnicalTestContext))]
    partial class TechnicalTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ID = 1,
                            Key = "SIDE_BAR_TYPE",
                            LastDateUpdated = new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(923),
                            Value = "1"
                        },
                        new
                        {
                            ID = 2,
                            Key = "SESSION_TIME",
                            LastDateUpdated = new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(927),
                            Value = "120"
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

                    b.Property<DateTime?>("LastLoginDate")
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
                            CreateDate = new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(816),
                            FullName = "Administrador",
                            Mail = "tabaldi98@gmail.com",
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
#pragma warning restore 612, 618
        }
    }
}
