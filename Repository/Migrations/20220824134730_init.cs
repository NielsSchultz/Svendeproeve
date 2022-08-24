using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionSyd.Repositories.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    FileTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.FileTypeID);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryStatus",
                columns: table => new
                {
                    JournalEntryStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryStatus", x => x.JournalEntryStatusID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlaceType",
                columns: table => new
                {
                    TreatmentPlaceTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentPlaceTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlaceType", x => x.TreatmentPlaceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlace",
                columns: table => new
                {
                    TreatmentPlaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentPlaceTypeID = table.Column<int>(type: "int", nullable: false),
                    TreatmentPlaceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlace", x => x.TreatmentPlaceID);
                    table.ForeignKey(
                        name: "FK_TreatmentPlace_TreatmentPlaceType",
                        column: x => x.TreatmentPlaceTypeID,
                        principalTable: "TreatmentPlaceType",
                        principalColumn: "TreatmentPlaceTypeID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserType",
                        column: x => x.UserTypeID,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentPlaceID = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_TreatmentPlace",
                        column: x => x.TreatmentPlaceID,
                        principalTable: "TreatmentPlace",
                        principalColumn: "TreatmentPlaceID");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Department",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType",
                        column: x => x.EmployeeTypeID,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeID");
                    table.ForeignKey(
                        name: "FK_Employee_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_Department",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    TreatmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TreatmentDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_Treatment_Department",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    JournalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.JournalID);
                    table.ForeignKey(
                        name: "FK_Journal_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    MonitorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.MonitorID);
                    table.ForeignKey(
                        name: "FK_Monitor_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    BedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.BedID);
                    table.ForeignKey(
                        name: "FK_Bed_Room",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TreatmentPlaceID = table.Column<int>(type: "int", nullable: false),
                    TreatmentID = table.Column<int>(type: "int", nullable: false),
                    TreatmentStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    TreatmentEnd = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_Booking_Treatment",
                        column: x => x.TreatmentID,
                        principalTable: "Treatment",
                        principalColumn: "TreatmentID");
                    table.ForeignKey(
                        name: "FK_Booking_TreatmentPlace",
                        column: x => x.TreatmentPlaceID,
                        principalTable: "TreatmentPlace",
                        principalColumn: "TreatmentPlaceID");
                });

            migrationBuilder.CreateTable(
                name: "JournalEntry",
                columns: table => new
                {
                    JournalEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalID = table.Column<int>(type: "int", nullable: false),
                    JournalEntryStatusID = table.Column<int>(type: "int", nullable: false),
                    TreatmentPlaceID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntry", x => x.JournalEntryID);
                    table.ForeignKey(
                        name: "FK_JournalEntry_Employee",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_JournalEntry_Journal",
                        column: x => x.JournalID,
                        principalTable: "Journal",
                        principalColumn: "JournalID");
                    table.ForeignKey(
                        name: "FK_JournalEntry_JournalEntryStatus",
                        column: x => x.JournalEntryStatusID,
                        principalTable: "JournalEntryStatus",
                        principalColumn: "JournalEntryStatusID");
                });

            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    AlarmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.AlarmID);
                    table.ForeignKey(
                        name: "FK_Alarm_Bed",
                        column: x => x.BedID,
                        principalTable: "Bed",
                        principalColumn: "BedID");
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryFile",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    FileTypeID = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryFile", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_JournalEntryFile_Employee",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_JournalEntryFile_FileType",
                        column: x => x.FileTypeID,
                        principalTable: "FileType",
                        principalColumn: "FileTypeID");
                    table.ForeignKey(
                        name: "FK_JournalEntryFile_JournalEntry",
                        column: x => x.JournalEntryID,
                        principalTable: "JournalEntry",
                        principalColumn: "JournalEntryID");
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryNote",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    NoteContent = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryNote", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_JournalEntryNote_Employee",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_JournalEntryNote_JournalEntry",
                        column: x => x.JournalEntryID,
                        principalTable: "JournalEntry",
                        principalColumn: "JournalEntryID");
                });

            migrationBuilder.InsertData(
                table: "EmployeeType",
                columns: new[] { "EmployeeTypeID", "EmployeeTypeName" },
                values: new object[,]
                {
                    { 1, "Hospitals Læge" },
                    { 2, "Praktiserende Læge" },
                    { 3, "Sygeplejerske" },
                    { 4, "Sundhedshjælper" }
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "FileTypeID", "FileTypeName" },
                values: new object[,]
                {
                    { 1, "png" },
                    { 2, "pdf" }
                });

            migrationBuilder.InsertData(
                table: "JournalEntryStatus",
                columns: new[] { "JournalEntryStatusID", "StatusName" },
                values: new object[,]
                {
                    { 1, "Igang" },
                    { 2, "Afsluttet" }
                });

            migrationBuilder.InsertData(
                table: "TreatmentPlaceType",
                columns: new[] { "TreatmentPlaceTypeID", "TreatmentPlaceTypeName" },
                values: new object[,]
                {
                    { 1, "Sygehus" },
                    { 2, "Sundhedshus" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeID", "UserTypeName" },
                values: new object[,]
                {
                    { 1, "Sundhedsmedarbejder" },
                    { 2, "Patient" }
                });

            migrationBuilder.InsertData(
                table: "TreatmentPlace",
                columns: new[] { "TreatmentPlaceID", "Address", "City", "TreatmentPlaceName", "TreatmentPlaceTypeID", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Kresten Philipsens Vej 15", "Aabenraa", "Sygehus Sønderjylland", 1, 6200 },
                    { 2, "Ulsnæs 13", "Gråsten", "Sundhedshus Gråsten", 2, 6300 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Address", "CityName", "CPR", "Email", "FirstName", "LastName", "MiddleName", "Phone", "UserTypeID", "Username", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Vesterbrogade 1", "Aabenraa", "050871-1595", "marmag71@regionsyd.dk", "Martin", "Magnussen", null, "19191919", 1, "Marmag", 6200 },
                    { 2, "Vesterbrogade 2", "Aabenraa", "010394-4718", "sigsig94@regionsyd.dk", "Sigrid", "Sigurtsen", null, "17171717", 1, "Sigsig", 6200 },
                    { 3, "Vesterbrogade 3", "Aabenraa", "090991-5628", "emmell91@regionsyd.dk", "Emma", "Ellert", null, "14141414", 1, "Emmell", 6200 },
                    { 4, "Vesterbrogade 4", "Aabenraa", "090477-2345", "trotho77@regionsyd.dk", "Troels", "Thomsem", null, "24242424", 1, "Trotho", 6200 },
                    { 5, "Vesterbrogade 5", "Aabenraa", "280587-2566", "winwol87@regionsyd.dk", "Winnie", "Wolfsen", null, "28282828", 1, "Winwol", 6200 },
                    { 6, "Vesterbrogade 6", "Aabenraa", "300666-2175", "robree66@regionsyd.dk", "Robert", "Reesen", null, "31313131", 1, "Robree", 6200 },
                    { 7, "Vesterbrogade 7", "Aabenraa", "110296-1232", "nadnis96@regionsyd.dk", "Nadja", "Nissen", null, "35353535", 1, "Nadnis", 6200 },
                    { 8, "Vesterbrogade 8", "Aabenraa", "230164-3457", "iamthebest6969@ofir.dk", "Poul", "Pedersen", null, "44444444", 2, "PoulPedersen3", 6200 },
                    { 9, "Vesterbrogade 9", "Aabenraa", "250502-3568", "loooouiiise@hotmail.dk", "Louise", "Lundsen", null, "40404040", 2, "Louiselundsen1", 6200 },
                    { 10, "Vesterbrogade 10", "Aabenraa", "190199-2385", "xXxsupermanxXx@yahoo.dk", "Kim", "Kold", null, "57575757", 2, "Kimkold", 6200 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "DepartmentName", "TreatmentPlaceID" },
                values: new object[,]
                {
                    { 1, "Røntgen Afdeling", 1 },
                    { 2, "Søvnambulatoriet", 1 },
                    { 3, "Høreklinniken", 1 },
                    { 4, "Blodprøve", 2 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "UserID" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "DepartmentID", "EmployeeCode", "EmployeeTypeID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, "marmag71", 1, 1 },
                    { 2, 2, "sigsig94", 1, 2 },
                    { 3, 3, "emmell91", 1, 3 },
                    { 4, 4, "trotho77", 2, 4 },
                    { 5, 1, "winwol87", 3, 5 },
                    { 6, 3, "robree66", 3, 6 },
                    { 7, 4, "nadnis96", 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "Journal",
                columns: new[] { "JournalID", "PatientID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "DepartmentID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 4 },
                    { 17, 4 }
                });

            migrationBuilder.InsertData(
                table: "Treatment",
                columns: new[] { "TreatmentID", "DepartmentID", "TreatmentDuration", "TreatmentName" },
                values: new object[,]
                {
                    { 1, 4, 15, "Blodprøve" },
                    { 2, 3, 45, "Høreprøve" },
                    { 3, 4, 15, "Blodprøve" },
                    { 4, 1, 60, "CT-scanning" },
                    { 5, 2, 60, "Polysomnografi" }
                });

            migrationBuilder.InsertData(
                table: "Bed",
                columns: new[] { "BedID", "IsOccupied", "RoomID" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, false, 1 },
                    { 3, false, 1 },
                    { 4, false, 2 },
                    { 5, false, 2 },
                    { 6, false, 2 },
                    { 7, false, 3 },
                    { 8, false, 3 },
                    { 9, false, 3 },
                    { 10, false, 4 },
                    { 11, false, 4 },
                    { 12, false, 5 },
                    { 13, false, 5 },
                    { 14, false, 6 },
                    { 15, false, 6 },
                    { 16, false, 7 },
                    { 17, false, 7 },
                    { 18, false, 7 },
                    { 19, false, 7 },
                    { 20, false, 8 },
                    { 21, false, 9 },
                    { 22, false, 10 },
                    { 23, false, 11 },
                    { 24, false, 11 },
                    { 25, false, 12 },
                    { 26, false, 12 },
                    { 27, false, 13 },
                    { 28, false, 13 },
                    { 29, false, 14 },
                    { 30, false, 14 },
                    { 31, false, 14 },
                    { 32, false, 15 },
                    { 33, false, 16 },
                    { 34, true, 11 }
                });

            migrationBuilder.InsertData(
                table: "JournalEntry",
                columns: new[] { "JournalEntryID", "DateAdded", "DepartmentID", "Description", "Diagnosis", "EmployeeID", "JournalEntryStatusID", "JournalID", "LastEdited", "TreatmentPlaceID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), 2, "Patient klager over søvnbesvær", null, 2, 1, 1, new DateTime(2022, 8, 24, 13, 47, 30, 478, DateTimeKind.Utc).AddTicks(4947), 2 },
                    { 2, new DateTime(2017, 2, 27, 8, 15, 0, 0, DateTimeKind.Unspecified), 4, "Patient vil gerne vide om de har mangel på D vitamin", null, 4, 1, 1, new DateTime(2022, 8, 24, 13, 47, 30, 478, DateTimeKind.Utc).AddTicks(4955), 2 },
                    { 3, new DateTime(2022, 2, 27, 8, 15, 0, 0, DateTimeKind.Unspecified), 3, "Patient har svært ved at høre", null, 3, 2, 2, new DateTime(2022, 8, 24, 13, 47, 30, 478, DateTimeKind.Utc).AddTicks(4961), 1 }
                });

            migrationBuilder.InsertData(
                table: "JournalEntryNote",
                columns: new[] { "NoteID", "EmployeeID", "IsApproved", "JournalEntryID", "NoteContent" },
                values: new object[,]
                {
                    { 1, 2, false, 1, "har givet rådgivning om brug af mobiltelefoner før sengetid" },
                    { 2, 2, false, 1, "patient mener de lider af søvnapnø, har givet CPAP-maskine med hjem til at måle det" },
                    { 3, 2, false, 1, "CPAP-maskine viser ikke tegn på søvnapnø" },
                    { 4, 4, false, 2, "Henvist patient til at få taget en blodprøve" },
                    { 5, 4, false, 2, "Måling viser mangel på vitamin D, gevet rådgivning om tilskud" },
                    { 6, 3, false, 3, "Udført undersøgelse af hørsel, anbefaler høreapparat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarm_BedID",
                table: "Alarm",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_Bed_RoomID",
                table: "Bed",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PatientID",
                table: "Booking",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TreatmentID",
                table: "Booking",
                column: "TreatmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TreatmentPlaceID",
                table: "Booking",
                column: "TreatmentPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_TreatmentPlaceID",
                table: "Department",
                column: "TreatmentPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeID",
                table: "Employee",
                column: "EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserID",
                table: "Employee",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_PatientID",
                table: "Journal",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_EmployeeID",
                table: "JournalEntry",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_JournalEntryStatusID",
                table: "JournalEntry",
                column: "JournalEntryStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_JournalID",
                table: "JournalEntry",
                column: "JournalID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryFile_EmployeeID",
                table: "JournalEntryFile",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryFile_FileTypeID",
                table: "JournalEntryFile",
                column: "FileTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryFile_JournalEntryID",
                table: "JournalEntryFile",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryNote_EmployeeID",
                table: "JournalEntryNote",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryNote_JournalEntryID",
                table: "JournalEntryNote",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_PatientID",
                table: "Monitor",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserID",
                table: "Patient",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_DepartmentID",
                table: "Room",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_DepartmentID",
                table: "Treatment",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlace_TreatmentPlaceTypeID",
                table: "TreatmentPlace",
                column: "TreatmentPlaceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "UK_CPR",
                table: "User",
                column: "CPR",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarm");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "JournalEntryFile");

            migrationBuilder.DropTable(
                name: "JournalEntryNote");

            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "JournalEntry");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "JournalEntryStatus");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "TreatmentPlace");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TreatmentPlaceType");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
