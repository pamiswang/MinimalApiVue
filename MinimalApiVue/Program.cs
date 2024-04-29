namespace MinimalApiVue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // 加入具有預設原則的 CORS 和中介軟體
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowCredentials();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            // 啟用預設 CORS 原則
            app.UseCors();

            // 使用路由表
            app.UseApiRoute();

            app.Run();
        }
    }
}
