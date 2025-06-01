using Kris.Data;
using Kris.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=kris.db"));
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<ExcelExportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // Don't use HSTS in production on Azure App Service
    // app.UseHsts();
}

// Don't redirect to HTTPS on Azure App Service - HTTPS termination is handled by the load balancer
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
