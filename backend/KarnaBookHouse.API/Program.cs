using KarnaBookHouse.API.Data;
using Microsoft.EntityFrameworkCore;
using KarnaBookHouse.API.Repositories;
using KarnaBookHouse.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<ApplicationDbContext>(
options =>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",policy =>{
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
 
app.UseSwaggerUI();

app.UseCors("AllowAngular");
 
app.MapControllers();

app.UseHttpsRedirection();




app.Run();

