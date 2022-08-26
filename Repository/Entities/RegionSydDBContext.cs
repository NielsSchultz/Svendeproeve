using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegionSyd.Repositories.Entities
{
    public partial class RegionSydDBContext : DbContext
    {
        public RegionSydDBContext()
        {
        }

        public RegionSydDBContext(DbContextOptions<RegionSydDBContext> options)
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
        public virtual DbSet<JournalEntryStatus> JournalEntryStatuses { get; set; } = null!;
        public virtual DbSet<Monitor> Monitors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Treatment> Treatments { get; set; } = null!;
        public virtual DbSet<TreatmentPlace> TreatmentPlaces { get; set; } = null!;
        public virtual DbSet<TreatmentPlaceType> TreatmentPlaceTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //Local DB
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RegionSydDB;MultipleActiveResultSets=true;");
                //Joan
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RegionSydDB;MultipleActiveResultSets=true;Trusted_Connection=True");
                // Christian
                //optionsBuilder.UseSqlServer("Server=MSI;Database=RegionSydDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
                //Azure DB
                // optionsBuilder.UseSqlServer("Server=dtdevelopment.database.windows.net,1433;Database=RegionSydDB;User ID=dtdev-admin;Password=DY5yMR01BjWt;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarm>(entity =>
            {
                entity.ToTable("Alarm");

                entity.HasIndex(e => e.BedId, "IX_Alarm_BedID");

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

                entity.HasIndex(e => e.RoomId, "IX_Bed_RoomID");

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

                entity.HasIndex(e => e.PatientId, "IX_Booking_PatientID");

                entity.HasIndex(e => e.TreatmentId, "IX_Booking_TreatmentID");

                entity.HasIndex(e => e.TreatmentPlaceId, "IX_Booking_TreatmentPlaceID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.TreatmentEnd).HasColumnType("datetime");

                entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");

                entity.Property(e => e.TreatmentPlaceId).HasColumnName("TreatmentPlaceID");

                entity.Property(e => e.TreatmentStart).HasColumnType("datetime");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Patient");

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

                entity.HasIndex(e => e.TreatmentPlaceId, "IX_Department_TreatmentPlaceID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

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

                entity.HasIndex(e => e.DepartmentId, "IX_Employee_DepartmentID");

                entity.HasIndex(e => e.EmployeeTypeId, "IX_Employee_EmployeeTypeID");

                entity.HasIndex(e => e.UserId, "IX_Employee_UserID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");

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

                entity.Property(e => e.EmployeeTypeName).HasMaxLength(50);
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

                entity.HasIndex(e => e.PatientId, "IX_Journal_PatientID");

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

                //entity.HasIndex(e => e.EmployeeId, "IX_JournalEntry_EmployeeID");

                entity.HasIndex(e => e.JournalEntryStatusId, "IX_JournalEntry_JournalEntryStatusID");

                entity.HasIndex(e => e.JournalId, "IX_JournalEntry_JournalID");

                entity.Property(e => e.JournalEntryId).HasColumnName("JournalEntryID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Diagnosis).HasMaxLength(150);

                //entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.JournalEntryStatusId).HasColumnName("JournalEntryStatusID");

                entity.Property(e => e.JournalId).HasColumnName("JournalID");

                entity.Property(e => e.LastEdited).HasColumnType("datetime");

                entity.Property(e => e.TreatmentPlaceId).HasColumnName("TreatmentPlaceID");

                //entity.HasOne(d => d.Employee)
                //    .WithMany(p => p.JournalEntries)
                //    .HasForeignKey(d => d.EmployeeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_JournalEntry_Employee");

                entity.HasOne(d => d.JournalEntryStatus)
                    .WithMany(p => p.JournalEntries)
                    .HasForeignKey(d => d.JournalEntryStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalEntry_JournalEntryStatus");

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

                entity.HasIndex(e => e.EmployeeId, "IX_JournalEntryFile_EmployeeID");

                entity.HasIndex(e => e.FileTypeId, "IX_JournalEntryFile_FileTypeID");

                entity.HasIndex(e => e.JournalEntryId, "IX_JournalEntryFile_JournalEntryID");

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

                entity.HasIndex(e => e.EmployeeId, "IX_JournalEntryNote_EmployeeID");

                entity.HasIndex(e => e.JournalEntryId, "IX_JournalEntryNote_JournalEntryID");

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

            modelBuilder.Entity<JournalEntryStatus>(entity =>
            {
                entity.ToTable("JournalEntryStatus");

                entity.Property(e => e.JournalEntryStatusId).HasColumnName("JournalEntryStatusID");

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Monitor>(entity =>
            {
                entity.ToTable("Monitor");

                entity.HasIndex(e => e.PatientId, "IX_Monitor_PatientID");

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

                entity.HasIndex(e => e.UserId, "IX_Patient_UserID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

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

                entity.HasIndex(e => e.DepartmentId, "IX_Room_DepartmentID");

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

                entity.HasIndex(e => e.DepartmentId, "IX_Treatment_DepartmentID");

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

                entity.HasIndex(e => e.TreatmentPlaceTypeId, "IX_TreatmentPlace_TreatmentPlaceTypeID");

                entity.Property(e => e.TreatmentPlaceId).HasColumnName("TreatmentPlaceID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.TreatmentPlaceName).HasMaxLength(50);

                entity.Property(e => e.TreatmentPlaceTypeId).HasColumnName("TreatmentPlaceTypeID");

                entity.HasOne(d => d.TreatmentPlaceType)
                    .WithMany(p => p.TreatmentPlaces)
                    .HasForeignKey(d => d.TreatmentPlaceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TreatmentPlace_TreatmentPlaceType");
            });

            modelBuilder.Entity<TreatmentPlaceType>(entity =>
            {
                entity.ToTable("TreatmentPlaceType");

                entity.Property(e => e.TreatmentPlaceTypeId).HasColumnName("TreatmentPlaceTypeID");

                entity.Property(e => e.TreatmentPlaceTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserTypeId, "IX_User_UserTypeID");

                entity.HasIndex(e => e.Cpr, "UK_CPR")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.Cpr)
                    .HasMaxLength(50)
                    .HasColumnName("CPR");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

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

            //SEEDING DATA
            modelBuilder.Entity<TreatmentPlaceType>().HasData(
                new TreatmentPlaceType { TreatmentPlaceTypeId = 1, TreatmentPlaceTypeName = "Sygehus" },
                new TreatmentPlaceType { TreatmentPlaceTypeId = 2, TreatmentPlaceTypeName = "Sundhedshus" }
                );

            modelBuilder.Entity<TreatmentPlace>().HasData(
                new TreatmentPlace { TreatmentPlaceId = 1, TreatmentPlaceTypeId = 1, TreatmentPlaceName = "Sygehus Sønderjylland", Address = "Kresten Philipsens Vej 15", City = "Aabenraa", ZipCode = 6200 },
                new TreatmentPlace { TreatmentPlaceId = 2, TreatmentPlaceTypeId = 2, TreatmentPlaceName = "Sundhedshus Gråsten", Address = "Ulsnæs 13", City = "Gråsten", ZipCode = 6300 }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, TreatmentPlaceId = 1, DepartmentName = "Røntgen Afdeling" },
                new Department { DepartmentId = 2, TreatmentPlaceId = 1, DepartmentName = "Søvnambulatoriet" },
                new Department { DepartmentId = 3, TreatmentPlaceId = 1, DepartmentName = "Høreklinniken" },
                new Department { DepartmentId = 4, TreatmentPlaceId = 2, DepartmentName = "Blodprøve" }
                );

            modelBuilder.Entity<Treatment>().HasData(
                new Treatment { TreatmentId = 1, DepartmentId = 4, TreatmentName = "Blodprøve", TreatmentDuration = 15 },
                new Treatment { TreatmentId = 2, DepartmentId = 3, TreatmentName = "Høreprøve", TreatmentDuration = 45 },
                new Treatment { TreatmentId = 3, DepartmentId = 4, TreatmentName = "Blodprøve", TreatmentDuration = 15 },
                new Treatment { TreatmentId = 4, DepartmentId = 1, TreatmentName = "CT-scanning", TreatmentDuration = 60, },
                new Treatment { TreatmentId = 5, DepartmentId = 2, TreatmentName = "Polysomnografi", TreatmentDuration = 60, }
                );
            modelBuilder.Entity<FileType>().HasData(
                new FileType { FileTypeId = 1, FileTypeName = "png" },
                new FileType { FileTypeId = 2, FileTypeName = "pdf" }
                );

            modelBuilder.Entity<UserType>().HasData(
                new UserType { UserTypeId = 1, UserTypeName = "Sundhedsmedarbejder" },
                new UserType { UserTypeId = 2, UserTypeName = "Patient" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserTypeId = 1, FirstName = "Martin", LastName = "Magnussen", Email = "marmag71@regionsyd.dk", Username = "Marmag", Address = "Vesterbrogade 1", CityName = "Aabenraa", ZipCode = 6200,Cpr = "050871-1595", Phone = "19191919" },
                new User { UserId = 2, UserTypeId = 1, FirstName = "Sigrid", LastName = "Sigurtsen", Email = "sigsig94@regionsyd.dk", Username = "Sigsig", Address = "Vesterbrogade 2", CityName = "Aabenraa", ZipCode = 6200, Cpr = "010394-4718", Phone = "17171717" },
                new User { UserId = 3, UserTypeId = 1, FirstName = "Emma", LastName = "Ellert", Email = "emmell91@regionsyd.dk", Username = "Emmell", Address = "Vesterbrogade 3", CityName = "Aabenraa", ZipCode = 6200, Cpr = "090991-5628", Phone = "14141414" },
                new User { UserId = 4, UserTypeId = 1, FirstName = "Troels", LastName = "Thomsem", Email = "trotho77@regionsyd.dk", Username = "Trotho", Address = "Vesterbrogade 4", CityName = "Aabenraa", ZipCode = 6200, Cpr = "090477-2345", Phone = "24242424" },
                new User { UserId = 5, UserTypeId = 1, FirstName = "Winnie", LastName = "Wolfsen", Email = "winwol87@regionsyd.dk", Username = "Winwol", Address = "Vesterbrogade 5", CityName = "Aabenraa", ZipCode = 6200, Cpr = "280587-2566", Phone = "28282828" },
                new User { UserId = 6, UserTypeId = 1, FirstName = "Robert", LastName = "Reesen", Email = "robree66@regionsyd.dk", Username = "Robree", Address = "Vesterbrogade 6", CityName = "Aabenraa", ZipCode = 6200, Cpr = "300666-2175", Phone = "31313131" },
                new User { UserId = 7, UserTypeId = 1, FirstName = "Nadja", LastName = "Nissen", Email = "nadnis96@regionsyd.dk", Username = "Nadnis", Address = "Vesterbrogade 7", CityName = "Aabenraa", ZipCode = 6200, Cpr = "110296-1232", Phone = "35353535" },
                new User { UserId = 8, UserTypeId = 2, FirstName = "Poul", LastName = "Pedersen", Email = "iamthebest6969@ofir.dk", Username = "PoulPedersen3", Address = "Vesterbrogade 8", CityName = "Aabenraa", ZipCode = 6200, Cpr = "230164-3457", Phone = "44444444" },
                new User { UserId = 9, UserTypeId = 2, FirstName = "Louise", LastName = "Lundsen", Email = "loooouiiise@hotmail.dk", Username = "Louiselundsen1", Address = "Vesterbrogade 9", CityName = "Aabenraa", ZipCode = 6200, Cpr = "250502-3568", Phone = "40404040" },
                new User { UserId = 10, UserTypeId = 2, FirstName = "Kim", LastName = "Kold", Email = "xXxsupermanxXx@yahoo.dk", Username = "Kimkold", Address = "Vesterbrogade 10", CityName = "Aabenraa", ZipCode = 6200, Cpr = "190199-2385", Phone = "57575757" }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, UserId = 9 },
                new Patient { PatientId = 2, UserId = 10}
                );

            modelBuilder.Entity<EmployeeType>().HasData(
                new EmployeeType { EmployeeTypeId = 1, EmployeeTypeName = "Hospitals Læge" },
                new EmployeeType { EmployeeTypeId = 2, EmployeeTypeName = "Praktiserende Læge" },
                new EmployeeType { EmployeeTypeId = 3, EmployeeTypeName = "Sygeplejerske" },
                new EmployeeType { EmployeeTypeId = 4, EmployeeTypeName = "Sundhedshjælper" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, UserId = 1, EmployeeTypeId = 1, DepartmentId = 1, EmployeeCode = "marmag71" },
                new Employee { EmployeeId = 2, UserId = 2, EmployeeTypeId = 1, DepartmentId = 2, EmployeeCode = "sigsig94" },
                new Employee { EmployeeId = 3, UserId = 3, EmployeeTypeId = 1, DepartmentId = 3, EmployeeCode = "emmell91" },
                new Employee { EmployeeId = 4, UserId = 4, EmployeeTypeId = 2, DepartmentId = 4, EmployeeCode = "trotho77" },
                new Employee { EmployeeId = 5, UserId = 5, EmployeeTypeId = 3, DepartmentId = 1, EmployeeCode = "winwol87" },
                new Employee { EmployeeId = 6, UserId = 6, EmployeeTypeId = 3, DepartmentId = 3, EmployeeCode = "robree66" },
                new Employee { EmployeeId = 7, UserId = 7, EmployeeTypeId = 4, DepartmentId = 4, EmployeeCode = "nadnis96" }
                );

            modelBuilder.Entity<Journal>().HasData(
                new Journal { JournalId = 1, PatientId = 1 },
                new Journal { JournalId = 2, PatientId = 2 }
                );

            modelBuilder.Entity<JournalEntryStatus>().HasData(
                new JournalEntryStatus { JournalEntryStatusId = 1, StatusName = "Igang" },
                new JournalEntryStatus { JournalEntryStatusId = 2, StatusName = "Afsluttet" }
                );

            modelBuilder.Entity<JournalEntry>().HasData(
                new JournalEntry { JournalEntryId = 1, JournalId = 1, DepartmentId = 2, /*EmployeeId = 2,*/ TreatmentPlaceId = 2, JournalEntryStatusId = 1, DateAdded = DateTime.Parse("2021-07-24 13:45:00"), Description = "Patient klager over søvnbesvær", LastEdited = DateTime.UtcNow },
                new JournalEntry { JournalEntryId = 2, JournalId = 1, DepartmentId = 4, /*EmployeeId = 4,*/ TreatmentPlaceId = 2, JournalEntryStatusId = 1, DateAdded = DateTime.Parse("2017-02-27 08:15:00"), Description = "Patient vil gerne vide om de har mangel på D vitamin", LastEdited = DateTime.UtcNow },
                new JournalEntry { JournalEntryId = 3, JournalId = 2, DepartmentId = 3, /*EmployeeId = 3,*/ TreatmentPlaceId = 1, JournalEntryStatusId = 2, DateAdded = DateTime.Parse("2022-02-27 08:15:00"), Description = "Patient har svært ved at høre", LastEdited = DateTime.UtcNow }
                );


            modelBuilder.Entity<JournalEntryNote>().HasData(
                new JournalEntryNote { NoteId = 1, JournalEntryId = 1, EmployeeId = 2, NoteContent = "har givet rådgivning om brug af mobiltelefoner før sengetid" },
                new JournalEntryNote { NoteId = 2, JournalEntryId = 1, EmployeeId = 2, NoteContent = "patient mener de lider af søvnapnø, har givet CPAP-maskine med hjem til at måle det" },
                new JournalEntryNote { NoteId = 3, JournalEntryId = 1, EmployeeId = 2, NoteContent = "CPAP-maskine viser ikke tegn på søvnapnø" },
                new JournalEntryNote { NoteId = 4, JournalEntryId = 2, EmployeeId = 4, NoteContent = "Henvist patient til at få taget en blodprøve" },
                new JournalEntryNote { NoteId = 5, JournalEntryId = 2, EmployeeId = 4, NoteContent = "Måling viser mangel på vitamin D, gevet rådgivning om tilskud" },
                new JournalEntryNote { NoteId = 6, JournalEntryId = 3, EmployeeId = 3, NoteContent = "Udført undersøgelse af hørsel, anbefaler høreapparat" }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, DepartmentId = 1 },
                new Room { RoomId = 2, DepartmentId = 1 },
                new Room { RoomId = 3, DepartmentId = 1 },
                new Room { RoomId = 4, DepartmentId = 1 },
                new Room { RoomId = 5, DepartmentId = 1 },
                new Room { RoomId = 6, DepartmentId = 1 },
                new Room { RoomId = 7, DepartmentId = 2 },
                new Room { RoomId = 8, DepartmentId = 2 },
                new Room { RoomId = 9, DepartmentId = 2 },
                new Room { RoomId = 10, DepartmentId = 2 },
                new Room { RoomId = 11, DepartmentId = 2 },
                new Room { RoomId = 12, DepartmentId = 3 },
                new Room { RoomId = 13, DepartmentId = 3 },
                new Room { RoomId = 14, DepartmentId = 3 },
                new Room { RoomId = 15, DepartmentId = 3 },
                new Room { RoomId = 16, DepartmentId = 4 },
                new Room { RoomId = 17, DepartmentId = 4 }
                );

            modelBuilder.Entity<Bed>().HasData(
                new Bed { BedId = 1, RoomId = 1, IsOccupied = false },
                new Bed { BedId = 2, RoomId = 1, IsOccupied = false },
                new Bed { BedId = 3, RoomId = 1, IsOccupied = false },
                new Bed { BedId = 4, RoomId = 2, IsOccupied = false },
                new Bed { BedId = 5, RoomId = 2, IsOccupied = false },
                new Bed { BedId = 6, RoomId = 2, IsOccupied = false },
                new Bed { BedId = 7, RoomId = 3, IsOccupied = false },
                new Bed { BedId = 8, RoomId = 3, IsOccupied = false },
                new Bed { BedId = 9, RoomId = 3, IsOccupied = false },
                new Bed { BedId = 10, RoomId = 4, IsOccupied = false },
                new Bed { BedId = 11, RoomId = 4, IsOccupied = false },
                new Bed { BedId = 12, RoomId = 5, IsOccupied = false },
                new Bed { BedId = 13, RoomId = 5, IsOccupied = false },
                new Bed { BedId = 14, RoomId = 6, IsOccupied = false },
                new Bed { BedId = 15, RoomId = 6, IsOccupied = false },
                new Bed { BedId = 16, RoomId = 7, IsOccupied = false },
                new Bed { BedId = 17, RoomId = 7, IsOccupied = false },
                new Bed { BedId = 18, RoomId = 7, IsOccupied = false },
                new Bed { BedId = 19, RoomId = 7, IsOccupied = false },
                new Bed { BedId = 20, RoomId = 8, IsOccupied = false },
                new Bed { BedId = 21, RoomId = 9, IsOccupied = false },
                new Bed { BedId = 22, RoomId = 10, IsOccupied = false },
                new Bed { BedId = 23, RoomId = 11, IsOccupied = false },
                new Bed { BedId = 24, RoomId = 11, IsOccupied = false },
                new Bed { BedId = 25, RoomId = 12, IsOccupied = false },
                new Bed { BedId = 26, RoomId = 12, IsOccupied = false },
                new Bed { BedId = 27, RoomId = 13, IsOccupied = false },
                new Bed { BedId = 28, RoomId = 13, IsOccupied = false },
                new Bed { BedId = 29, RoomId = 14, IsOccupied = false },
                new Bed { BedId = 30, RoomId = 14, IsOccupied = false },
                new Bed { BedId = 31, RoomId = 14, IsOccupied = false },
                new Bed { BedId = 32, RoomId = 15, IsOccupied = false },
                new Bed { BedId = 33, RoomId = 16, IsOccupied = false },
                new Bed { BedId = 34, RoomId = 11, IsOccupied = true }
                );


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
