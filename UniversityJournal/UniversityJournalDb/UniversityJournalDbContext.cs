using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UniversityJournalDb.Models;
using UniversityJournalDb.Views;
#nullable disable

namespace UniversityJournalDb
{
    public partial class UniversityJournalDbContext : DbContext
    {
        internal static string connectionString = null; //"Host=192.168.0.108;Database=university_journal_db;Username=postgres"

        public UniversityJournalDbContext()
        {
        }

        public UniversityJournalDbContext(DbContextOptions<UniversityJournalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllGradesView> AllGradesViews { get; set; }
        public virtual DbSet<AllGradesWithinMonth> AllGradesWithinMonths { get; set; }
        public virtual DbSet<AllTasksView> AllTasksViews { get; set; }
        public virtual DbSet<StudentModel> Students { get; set; }
        public virtual DbSet<SubjectModel> Subjects { get; set; }
        public virtual DbSet<TaskModel> Tasks { get; set; }
        public virtual DbSet<TaskStudentModel> TaskStudents { get; set; }
        public virtual DbSet<TeacherModel> Teachers { get; set; }
        public virtual DbSet<GroupModel> Groups { get; set; }

        public static void SetConnectionString(string connectionString)
        {
            if(UniversityJournalDbContext.connectionString is null)
                UniversityJournalDbContext.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<AllGradesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("all_grades_view");

                entity.Property(e => e.CreationYear).HasColumnName("creation_year");

                entity.Property(e => e.FinishDate)
                    .HasColumnType("date")
                    .HasColumnName("finish_date");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .HasColumnName("group_name");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .HasColumnName("student_name");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .HasColumnName("subject_name");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .HasColumnName("task_name");
            });

            modelBuilder.Entity<AllGradesWithinMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("all_grades_within_month");

                entity.Property(e => e.CreationYear).HasColumnName("creation_year");

                entity.Property(e => e.FinishDate)
                    .HasColumnType("date")
                    .HasColumnName("finish_date");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .HasColumnName("group_name");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .HasColumnName("student_name");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .HasColumnName("subject_name");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .HasColumnName("task_name");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(255)
                    .HasColumnName("teacher_name");
            });

            modelBuilder.Entity<AllTasksView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("all_tasks_view");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .HasColumnName("subject_name");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .HasColumnName("task_name");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(255)
                    .HasColumnName("teacher_name");
            });

            modelBuilder.Entity<StudentModel>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентифицирующий ключ");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday")
                    .HasComment("Дата рождения студента");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Имя студента");

                entity.Property(e => e.GroupId)
                    .HasColumnName("unigroup_id")
                    .HasComment("Идентифицирующий ключ группы");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_unigroup");
            });

            modelBuilder.Entity<SubjectModel>(entity =>
            {
                entity.ToTable("subject");

                entity.HasComment("Данные предмета");

                entity.HasIndex(e => new { e.Name, e.TeacherId }, "unique_subject")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентифицирующий ключ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Название предмета");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacher_id")
                    .HasComment("Идентифицирующий ключ преподавателя");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subject_teacher");
            });

            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.ToTable("task");

                entity.HasComment("Данные задания");

                entity.HasIndex(e => new { e.Name, e.SubjectId }, "unique_task")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентифицирующий ключ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Название задания");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .HasComment("Идентифицирующий ключ предмета, которому оно принадлежит");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_task_subject");
            });

            modelBuilder.Entity<TaskStudentModel>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.StudentId })
                    .HasName("task_student_pkey");

                entity.ToTable("task_student");

                entity.HasComment("Таблица, реализующая связь многие ко многим, таблицы заданий студентов. Также содержит информацию об оценке студента.");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasComment("Идентифицирующий ключ задания");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasComment("Идентифицирующий ключ студента");

                entity.Property(e => e.FinishDate)
                    .HasColumnType("date")
                    .HasColumnName("finish_date")
                    .HasComment("Дата выполнения задания");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasDefaultValueSql("1")
                    .HasComment("Оценка");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TaskStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_task_student_student");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskStudents)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_task_student_task");
            });

            modelBuilder.Entity<TeacherModel>(entity =>
            {
                entity.ToTable("teacher");

                entity.HasComment("Данные преподавателя университета");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентифицирующий ключ");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday")
                    .HasComment("Дата рождения");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Имя преподавателя");
            });

            modelBuilder.Entity<GroupModel>(entity =>
            {
                entity.ToTable("unigroup");

                entity.HasIndex(e => new { e.Name, e.CreationYear }, "unique_unigroup")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Идентифицирующий ключ");

                entity.Property(e => e.CreationYear)
                    .HasColumnName("creation_year")
                    .HasDefaultValueSql("2000");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Название группы");
            });

            modelBuilder.HasSequence("student_id_seq");

            modelBuilder.HasSequence("subject_id_seq");

            modelBuilder.HasSequence("task_id_seq");

            modelBuilder.HasSequence("teacher_id_seq");

            modelBuilder.HasSequence("unigroup_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
