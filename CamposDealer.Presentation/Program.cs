using CamposDealer.Application;
using CamposDealer.Application.Services.Implementations;
using CamposDealer.Application.Services.Interfaces;
using CamposDealer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CamposDealerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CamposDealerCs")));
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureService(builder.Configuration);
builder.Services.AddHttpClient<IApiService, ApiService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CamposDealer API",
        Version = "v1",
        Description = "API de integração de dados para CamposDealer",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seuemail@exemplo.com"
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CamposDealer API V1");
    c.RoutePrefix = string.Empty; // Abre o Swagger diretamente na raiz
});

ServiceExtensions.MigrationInitializer(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
