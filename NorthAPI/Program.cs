using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MySqlConnection through PlanetScale
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration["ConnectionStrings:Default"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// todo: figure our how to get this working
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();