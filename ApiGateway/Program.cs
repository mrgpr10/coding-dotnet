using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot();

// Configure CORS
builder.Services.AddCors(options => options.AddPolicy("policy", builder =>
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

// Load Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS policy
app.UseCors("policy");

// Use routing
app.UseRouting();


// Remove UseAuthorization if authorization is not needed
 app.UseAuthorization();  

// Configure endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Use Ocelot middleware
await app.UseOcelot();

// Map controllers
app.MapControllers();

app.Run();
