using System.Reflection;
using MealPlanner.API;
using MealPlanner.API.Data;
using MealPlanner.API.Data.Repositories;
using MealPlanner.API.Features.OpenAI;
using MealPlanner.API.Features.Recipes;
using MealPlanner.API.Features.Recipes.Services;
using MealPlanner.API.Interfaces;
using MealPlanner.Scraper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Logging.ClearProviders().AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MealDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MealPlanner")));

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddScoped<IShoppingListItemRepository, ShoppingListItemRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeParserService, RecipeParserService>();
builder.Services.AddScoped<IOpenAIService, OpenAIService>();
builder.Services.AddScoped<IWebScraper,  WebScraper>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddHttpClient<RecipeService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});

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

app.UseCors(myAllowSpecificOrigins);

app.Run();
