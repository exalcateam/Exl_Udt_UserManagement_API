using Microsoft.EntityFrameworkCore;
using User_Management.Data;
using User_Management.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
options.AddPolicy("mycors", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

builder.Services.AddControllers().AddJsonOptions(c =>
{
    c.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddDbContext<AppDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository , UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("mycors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
