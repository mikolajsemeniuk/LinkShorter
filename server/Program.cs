using Microsoft.EntityFrameworkCore;
using Data;
using Service.Interfaces;
using Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("server"));
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var myAngularPolicy = "myAngularPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myAngularPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

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

app.UseCors(myAngularPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
