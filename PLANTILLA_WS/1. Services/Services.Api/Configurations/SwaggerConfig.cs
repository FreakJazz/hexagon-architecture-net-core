using Microsoft.OpenApi.Models;

namespace Services.Api.Configurations
{
    public static class SwaggerConfig
    {

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "PlantillaCore8v1.0.0",
                    Title = "Plantilla generica de NET CORE 8 con PostgreSQL",
                    Description = "Servicios Repositorio de Transparencia - Swagger Surface",
                    Contact = new OpenApiContact { Name = "Jazmin Rodriguez", Email = "jazzrb2307@gmail.com", Url = new Uri("https://github.com/FreakJazz/") },
                    License = new OpenApiLicense { Name = "GNU GENERAL PUBLIC LICENSE", Url = new Uri("https://fsf.org/") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the JWT like: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Descomment for production
                // if (env.IsProduction()) c.SwaggerEndpoint("/[Name of proyect URL]/swagger/v1/swagger.json", "v1");

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

            });
        }
    }
}
