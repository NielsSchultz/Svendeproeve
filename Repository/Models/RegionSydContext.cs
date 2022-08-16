using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegionSyd.Repository.Models
{
    public partial class RegionSydContext : DbContext
    {
        public RegionSydContext()
        {
        }

        public RegionSydContext(DbContextOptions<RegionSydContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alarm> Alarms { get; set; } = null!;
        public virtual DbSet<Bed> Beds { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;
        public virtual DbSet<FileType> FileTypes { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<JournalEntry> JournalEntries { get; set; } = null!;
        public virtual DbSet<JournalEntryFile> JournalEntryFiles { get; set; } = null!;
        public virtual DbSet<JournalEntryNote> JournalEntryNotes { get; set; } = null!;
        public virtual DbSet<Monitor> Monitors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Treatment> Treatments { get; set; } = null!;
        public virtual DbSet<TreatmentPlace> TreatmentPlaces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=RegionSyd;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarm>(entity =>
            {
                entity.ToTable("Alarm");

                entity.Property(e => e.AlarmId).HasColumnName("AlarmID");

                entity.Property(e => e.BedId).HasColumnName("BedID");

                entity.HasOne(d => d.Bed)
                    .WithMany(p => p.Alarms)
                    .HasForeignKey(d => d.BedId)
                    .HasConstraintName("FK_Alarm_Bed");
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.ToTable("Bed");

                entity.Property(e => e.BedId).HasColumnName("BedID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Beds)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Bed_Room");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.JournalEntryId).HasColumnName("JournalEntryID");

                entity.Property(e => e.TreatmentEnd).HasColumnType("datetime");

                entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");

                entity.Property(e => e.TreatmentPlaceId).HasColumnName("TreatmentPlaceID");

                entity.Property(e => e.TreatmentStart).HasColumnType("datetime");

                entity.HasOne(d => d.JournalEntry)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.JournalEntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_JournalEntry");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Treatment");

                entity.HasOne(d => d.TreatmentPlace)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TreatmentPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_TreatmentPlace");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.TreatmentPlaceId).HasColumnName("TreatmentPlaceID");

                entity.HasOne(d => d.TreatmentPlace)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.TreatmentPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_TreatmentPlace");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmployeeType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_User");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.ToTable("FileType");

                entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");

                entity.Property(e => e.FileTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("Journal");

                entity.Property(e => e.JournalId).HasColumnName("JournalID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Journal_Patient");
            });

            modelBuilder.Entity<JournalEntry>(entity =>
            {
                entity.ToTable("JournalEntry");

                entity.Property(e => e.JournalEntryId).HasColumnName("JournalEntryID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.JournalId).HasColumnName("JournalID");

                entity.Property(e => e.LastEdited).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JournalEntries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntry_Employee");

                entity.HasOne(d => d.Journal)
                    .WithMany(p => p.JournalEntries)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntry_Journal");
            });

            modelBuilder.Entity<JournalEntryFile>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.ToTable("JournalEntryFile");

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FileNote).HasMaxLength(1000);

                entity.Property(e => e.FilePath).HasMaxLength(50);

                entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");

                entity.Property(e => e.JournalEntryId).HasColumnName("JournalEntryID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JournalEntryFiles)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntryFile_Employee");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.JournalEntryFiles)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntryFile_FileType");

                entity.HasOne(d => d.JournalEntry)
                    .WithMany(p => p.JournalEntryFiles)
                    .HasForeignKey(d => d.JournalEntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntryFile_JournalEntry");
            });

            modelBuilder.Entity<JournalEntryNote>(entity =>
            {
                entity.HasKey(e => e.NoteId);

                entity.ToTable("JournalEntryNote");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.JournalEntryId).HasColumnName("JournalEntryID");

                entity.Property(e => e.NoteContent).HasMaxLength(4000);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JournalEntryNotes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntryNote_Employee");

                entity.HasOne(d => d.JournalEntry)
                    .WithMany(p => p.JournalEntryNotes)
                    .HasForeignKey(d => d.JournalEntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntryNote_JournalEntry");
            });

            modelBuilder.Entity<Monitor>(entity =>
            {
                entity.ToTable("Monitor");

                entity.Property(e => e.MonitorId).HasColumnName("MonitorID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Monitors)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Monitor_Patient");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Cpr).HasColumnName("CPR");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_User");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Department");
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatment");

                entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.TreatmentName).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Treatments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Treatment_Department");
            });

            modelBuilder.Entity<TreatmentPlace>(entity =>
            {
                entity.ToTable("TreatmentPlace");

                entity.Property(e => e.TreatmentPlaceId).HasColumnName("TreatmentPlaceID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.TreatmentPlaceName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserTypeName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
