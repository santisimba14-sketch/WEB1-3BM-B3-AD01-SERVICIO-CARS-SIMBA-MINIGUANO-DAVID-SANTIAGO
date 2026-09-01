using CARS.DATA;
using CARS.Services;
using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Entity Framework
builder.Services.AddDbContext<CARSDBCONTEXT>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarsConnection")));

// Registro de CoreWCF y Servicios
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

// Registrar la clase y la interfaz
builder.Services.AddTransient<VehiculoService>();
builder.Services.AddTransient<IVehiculoService, VehiculoService>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

app.UseRouting();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<VehiculoService>(serviceOptions => { })
        // Endpoint HTTP (para puerto 5151)
        .AddServiceEndpoint<VehiculoService, IVehiculoService>(
            new BasicHttpBinding(),
            "/VehiculoService.svc"
        )
        // Endpoint HTTPS (para puerto 7098)
        .AddServiceEndpoint<VehiculoService, IVehiculoService>(
            new BasicHttpBinding(BasicHttpSecurityMode.Transport),
            "/VehiculoService.svc"
        );
});

// Habilitar WSDL tanto para HTTP como para HTTPS
var metadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
metadataBehavior.HttpGetEnabled = true;
metadataBehavior.HttpsGetEnabled = true;

app.Run();