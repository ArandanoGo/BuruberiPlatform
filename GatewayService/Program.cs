using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

// Carga la configuración del proxy
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// 👇 Agrega soporte para controladores
builder.Services.AddControllers();

var app = builder.Build();

// 👇 Mapea controladores (como /health)
app.MapControllers();

// 👇 Mapea el reverse proxy
app.MapReverseProxy();

app.Run();