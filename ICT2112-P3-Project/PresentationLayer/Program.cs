using Microsoft.EntityFrameworkCore;
using DomainLayer.Interface;
using DataSourceLayer.Data;
using DataSourceLayer.Gateway;
using DomainLayer.Control;
using DataSourceLayer.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register data source layer abstractions to decouple.
builder.Services.AddScoped<IAdministratorTDG, AdministratorTDG>();

// Team 7
builder.Services.AddScoped<IMedicalPlanTDG, MedicalPlanTDG>();

builder.Services.AddScoped<IMedicationTrackerTDG, MedicationTrackerTDG>();

builder.Services.AddScoped<IConsumedDateTimeTDG, ConsumedDateTimeTDG>();

builder.Services.AddScoped<IOCR_API_TDG, OCR_API_TDG>();

builder.Services.AddScoped<IPrescriptionTDG, PrescriptionTDG>();

builder.Services.AddScoped<IOCR_Adapter, OCR_Adapter>();

builder.Services.AddScoped<IDrugRecordTDG, DrugRecordTDG>();

builder.Services.AddScoped<IDrugTDG, DrugTDG>();

builder.Services.AddScoped<IMedicalCounsellingTDG, MedicalCounsellingTDG>();

// Team 4
builder.Services.AddScoped<PhotoControl>();
builder.Services.AddScoped<SafetyChecklistControl>();
builder.Services.AddScoped<CommunicationControl>();

// Register the IPhotoTDG and ISafetyChecklistTDG interfaces with their respective implementations
builder.Services.AddScoped<IPhotoTDG, PhotoTDG>();
builder.Services.AddScoped<ISafetyChecklistTDG, SafetyChecklistTDG>();

// Register the CommunicationControl
builder.Services.AddScoped<ICommunicationTDG, CommunicationTDG>();

builder.Services.AddScoped<IMedicalPlanTDG, MedicalPlanTDG>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
