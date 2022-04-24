using SoftShop;

var builder = Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(ConfigureWebHost);

var app = builder.Build();

app.Run();

static void ConfigureWebHost(IWebHostBuilder builder)
{
    builder.UseStartup<Startup>();
}
