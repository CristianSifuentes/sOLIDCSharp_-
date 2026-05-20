using DependencyInversion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DIP step 1:
// Program.cs is the composition root of the API.
// This is the correct place to connect abstractions to concrete infrastructure.
// StudentController will ask for IStudentRepository and ILogbook, not for concrete classes.
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILogbook, Logbook>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
