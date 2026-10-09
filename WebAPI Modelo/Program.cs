using WebAPI_Modelo.Services;
using WebAPI_Modelo.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICineServicio, CineServicio>();
builder.Services.AddScoped<ICineRepository, CineRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
