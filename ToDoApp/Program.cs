using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ToDoApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<ToDoDbContext>(
    opts => opts.UseSqlite(builder.Configuration.GetConnectionString("ToDoDb")));
builder.Services.AddScoped<BoardService>();
builder.Services.AddScoped<TaskListService>();
builder.Services.AddScoped<TaskCardService>();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();