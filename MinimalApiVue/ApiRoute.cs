namespace MinimalApiVue
{
    public static class ApiRoute
    {
        /// <summary>
        /// 應用程式路由表
        /// </summary>
        /// <param name="app"> WebApplication 實體物件 </param>
        public static void UseApiRoute(this WebApplication app)
        {
            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            });
        }
    }
}
