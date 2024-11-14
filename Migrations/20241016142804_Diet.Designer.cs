﻿// <auto-generated />
using System;
using KCK_Project__Console_Pocket_trainer_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KCK_Project__Console_Pocket_trainer_.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241016142804_Diet")]
    partial class Diet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Difficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Muscle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.ExerciseDone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Reps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("ExercisesDone");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.ExerciseToTrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Reps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("TrainingPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("ExercisesToTrainingPlans");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TreningPlanId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreningPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TreningPlans");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainingsPerWeek")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Diet", b =>
                {
                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.User", "User")
                        .WithMany("Diets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.ExerciseDone", b =>
                {
                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.Exercise", "Exercise")
                        .WithMany("ExercisesDone")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.Training", "Training")
                        .WithMany("ExercisesDone")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.User", "User")
                        .WithMany("ExercisesDone")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.ExerciseToTrainingPlan", b =>
                {
                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.Exercise", "Exercise")
                        .WithMany("TrainingPlans")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.TrainingPlan", "TrainingPlan")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("TrainingPlan");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Training", b =>
                {
                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.TrainingPlan", "TreningPlan")
                        .WithMany()
                        .HasForeignKey("TreningPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.User", "User")
                        .WithMany("Trainings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TreningPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.TrainingPlan", b =>
                {
                    b.HasOne("KCK_Project__Console_Pocket_trainer_.Models.User", "User")
                        .WithMany("TrainingPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Exercise", b =>
                {
                    b.Navigation("ExercisesDone");

                    b.Navigation("TrainingPlans");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.Training", b =>
                {
                    b.Navigation("ExercisesDone");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.TrainingPlan", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("KCK_Project__Console_Pocket_trainer_.Models.User", b =>
                {
                    b.Navigation("Diets");

                    b.Navigation("ExercisesDone");

                    b.Navigation("TrainingPlans");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
