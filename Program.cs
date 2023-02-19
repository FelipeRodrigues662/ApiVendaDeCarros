using ApiSqlAsp.DataContext;
using ApiSqlAsp.Services;


using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApiDataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
