using Microsoft.OpenApi.Models;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ADPTest.WebAPI.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ADP Labs Pre-Interview Assignment Test",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name="ADP Dev Team",
                        Email="dev@adp.com"
                    }
                }) ;
            });
        }
    }
}