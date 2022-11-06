using System.Reflection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace BankingRabbitMQ.Service.Transfer.Api.Extensions
{
    public static class ServicesRegistration
    {
        /// <summary>
        /// Adiciona o serviço para swagger OpenAPI no container de serviços
        /// </summary>
        /// <param name="services">container services</param>
        /// <returns>container services com o swagger OpenAPI no container</returns>
        public static void AddSwaggerOpenAPI(this IServiceCollection services)
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Transfer Microservice",
                    Version = "v1",
                    Description = "Demonstração dos recursos disponíveis no microserviço de Transfer.",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Francisco",
                        Email = "broncasrafa@gmail.com",
                        Url = new Uri("https://github.com/broncasrafa")
                    }
                });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Informe seu token bearer para acessar os recursos da API da seguinte forma: Bearer {your token here}",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }


        /// <summary>
        /// Adiciona as configurações de controller e JSON no container de serviços
        /// </summary>
        /// <param name="services">container services</param>
        /// <returns>container services com as configurações de controller e JSON no container</returns>
        public static void AddControllerAndJsonConfigurations(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            //.AddJsonOptions(x =>
            //{
            //    x.JsonSerializerOptions.IgnoreNullValues = true;
            //    //x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.None;
            //});
        }



    }
}
