using Microsoft.EntityFrameworkCore;
using QuestionnairesServer.Database;
using QuestionnairesServer.Services;
using QuestionnairesServer.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext <DataContext> (o => o.UseNpgsql(builder.Configuration.GetConnectionString("postgress_db")));

builder.Services.AddScoped<IQuestionnaireService, QuestionnaireService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors(builder =>
{
    builder
        .WithOrigins("http://localhost:4200", "https://localhost:4200")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
        .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
    }
);

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
