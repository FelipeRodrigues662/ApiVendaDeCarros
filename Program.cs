using ApiSqlAsp.DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiDataContext>();

var app = builder.Build();

app.MapControllers();
app.Run();
