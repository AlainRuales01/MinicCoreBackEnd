using ARMiniCore.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
string conexion = builder.Configuration.GetConnectionString("DataBaseConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(conexion)
);


var app = builder.Build();
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod();
});
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
