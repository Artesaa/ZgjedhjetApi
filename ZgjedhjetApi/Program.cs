using Microsoft.EntityFrameworkCore;
using ZgjedhjetApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext (ONLY ONCE)
builder.Services.AddDbContext<LifeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LifeDatabase")));

// Add services to the container.
builder.Services.AddControllers();
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