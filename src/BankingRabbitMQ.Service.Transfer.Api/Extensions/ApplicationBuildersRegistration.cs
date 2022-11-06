namespace BankingRabbitMQ.Service.Transfer.Api.Extensions
{
    public static class ApplicationBuildersRegistration
    {
        /// <summary>
        /// Adiciona as configurações do swagger ao pipeline da aplicação.
        /// </summary>
        /// <param name="app">application builder app original do pipeline da aplicação</param>
        public static void UseSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.InjectStylesheet("/swagger-ui/swagger-dark.css");
            });
        }

    }
}
