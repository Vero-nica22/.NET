var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var weatherForecast = new List<WeatherForecast>();

// GET: Obtener todos los recursos
app.MapGet("/weatherforecast/{index}", (int index) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound();//Respuesta HTTP 404 NOT Found
    }

    return Results.Ok(weatherForecast[index]);//Respuesta HTTP 200 OK

});

//POST: Crear un nuevo recurso
app.MapPost("/weatherforecast", (WeatherForecast weather) =>
{
    weatherForecast.Add(weather);
    return Results.Created($"/weatherforecast/{weatherForecast.Count - 1}", weather);
});

//PUT
app.MapPut("/weatherforecast/{index}", (int index, WeatherForecast nuevoweather) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound();
    }
    weatherForecast[index] = nuevoweather;
    return Results.NoContent();
});

//Delete

app.MapDelete("/weatherforecast/{index}", (int index) =>
{
    if (index < 0 || index >= weatherForecast.Count)
    {
        return Results.NotFound();
    }
    weatherForecast.RemoveAt(index);
    return Results.NoContent();
});



app.MapGet("/weatherforecast", () => weatherForecast)
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
