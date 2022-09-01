using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using RegionSyd.WebApi;
using RegionSyd.WebApi.Services.Interfaces;
using RegionSyd.WebApi.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-9wu0y2-q.us.auth0.com/";
    options.Audience = "https://localhost:7297/api/";
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<RegionSydDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDbConnectionString")));
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<ITreatmentService, TreatmentService>();
builder.Services.AddScoped<ITreatmentPlaceRepository, TreatmentPlaceRepository>();
builder.Services.AddScoped<ITreatmentPlaceService, TreatmentPlaceService>();
builder.Services.AddScoped<ITreatmentPlaceTypeRepository, TreatmentPlaceTypeRepository>();
builder.Services.AddScoped<ITreatmentPlaceTypeService, TreatmentPlaceTypeService>();
builder.Services.AddScoped<IJournalRepository, JournalRepository>();
builder.Services.AddScoped<IJournalService, JournalService>();
builder.Services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();
builder.Services.AddScoped<IJournalEntryService, JournalEntryService>();
builder.Services.AddScoped<IJournalEntryStatusRepository, JournalEntryStatusRepository>();
builder.Services.AddScoped<IJournalEntryStatusService, JournalEntryStatusService>();
builder.Services.AddScoped<IJournalEntryNoteRepository, JournalEntryNoteRepository>();
builder.Services.AddScoped<IJournalEntryNoteService, JournalEntryNoteService>();
builder.Services.AddScoped<IJournalEntryFileRepository, JournalEntryFileRepository>();
builder.Services.AddScoped<IJournalEntryFileService, JournalEntryFileService>();
builder.Services.AddScoped<IBedRepository, BedRepository>();
builder.Services.AddScoped<IBedService, BedService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
