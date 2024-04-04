using Microsoft.EntityFrameworkCore;
using DomainLayer.Interface;
using DataSourceLayer.Data;
using DataSourceLayer.Gateway;
using DomainLayer.Control;
using DomainLayer.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register data source layer abstractions to decouple.


// Team 4
builder.Services.AddScoped<PhotoControl>();
builder.Services.AddScoped<SafetyChecklistControl>();
builder.Services.AddScoped<CommunicationControl>();

// Register the IPhotoTDG and ISafetyChecklistTDG interfaces with their respective implementations
builder.Services.AddScoped<IPhotoTDG, PhotoTDG>();
builder.Services.AddScoped<ISafetyChecklistTDG, SafetyChecklistTDG>();

// Register the CommunicationControl
builder.Services.AddScoped<ICommunicationTDG, CommunicationTDG>();
builder.Services.AddScoped<IChatTDG, ChatTDG>();
builder.Services.AddScoped<IMessageFactory, TextMessageFactory>();

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
