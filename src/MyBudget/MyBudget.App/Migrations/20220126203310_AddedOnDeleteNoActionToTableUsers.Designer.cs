﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBudget.App.Database;

namespace MyBudget.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220126203310_AddedOnDeleteNoActionToTableUsers")]
    partial class AddedOnDeleteNoActionToTableUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBudget.App.Domain.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BudgetType")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BudgetTemplateId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("MyBudget.App.Domain.BudgetTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BudgetTemplates");
                });

            modelBuilder.Entity("MyBudget.App.Domain.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("OperationCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OperationTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("OperationCategoryId");

                    b.HasIndex("OperationTemplateId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("MyBudget.App.Domain.OperationCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OperationCategories");
                });

            modelBuilder.Entity("MyBudget.App.Domain.OperationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BudgetTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DefaultValue")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("OperationCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetTemplateId");

                    b.HasIndex("OperationCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("OperationTemplates");
                });

            modelBuilder.Entity("MyBudget.App.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyBudget.App.Domain.Budget", b =>
                {
                    b.HasOne("MyBudget.App.Domain.BudgetTemplate", "BudgetTemplate")
                        .WithMany("Budgets")
                        .HasForeignKey("BudgetTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetTemplate");
                });

            modelBuilder.Entity("MyBudget.App.Domain.BudgetTemplate", b =>
                {
                    b.HasOne("MyBudget.App.Domain.User", "User")
                        .WithMany("BudgetTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBudget.App.Domain.Operation", b =>
                {
                    b.HasOne("MyBudget.App.Domain.Budget", null)
                        .WithMany("Operations")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBudget.App.Domain.OperationCategory", "OperationCategory")
                        .WithMany()
                        .HasForeignKey("OperationCategoryId");

                    b.HasOne("MyBudget.App.Domain.OperationTemplate", "OperationTemplate")
                        .WithMany("Operations")
                        .HasForeignKey("OperationTemplateId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("OperationCategory");

                    b.Navigation("OperationTemplate");
                });

            modelBuilder.Entity("MyBudget.App.Domain.OperationCategory", b =>
                {
                    b.HasOne("MyBudget.App.Domain.User", "User")
                        .WithMany("OperationCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBudget.App.Domain.OperationTemplate", b =>
                {
                    b.HasOne("MyBudget.App.Domain.BudgetTemplate", "BudgetTemplate")
                        .WithMany("OperationTemplates")
                        .HasForeignKey("BudgetTemplateId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MyBudget.App.Domain.OperationCategory", "OperationCategory")
                        .WithMany("Operations")
                        .HasForeignKey("OperationCategoryId");

                    b.HasOne("MyBudget.App.Domain.User", "User")
                        .WithMany("OperationTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BudgetTemplate");

                    b.Navigation("OperationCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBudget.App.Domain.Budget", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("MyBudget.App.Domain.BudgetTemplate", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("OperationTemplates");
                });

            modelBuilder.Entity("MyBudget.App.Domain.OperationCategory", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("MyBudget.App.Domain.OperationTemplate", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("MyBudget.App.Domain.User", b =>
                {
                    b.Navigation("BudgetTemplates");

                    b.Navigation("OperationCategories");

                    b.Navigation("OperationTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
