using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Service.Transfer.Domain.Events;
using BankingRabbitMQ.Service.Transfer.Domain.EventsHandlers;

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.InjectStylesheet("/swagger-ui/swagger-dark.css");
            });
        }


        /// <summary>
        /// Adiciona as configurações para que todos os microserviços se inscrevam (subscribe) para qualquer evento que eles precisam
        /// </summary>
        /// <param name="app">application builder app original do pipeline da aplicação</param>
        public static void ConfigureEventBus(this IApplicationBuilder app)
        {
            // qualquer micro serviço que precise se inscrever em determinados eventos, precisamos definir a configuração para o eventbus.
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            
            eventBus.Subcribe<TransferCreatedEvent, TransferEventHandler>();
        }

    }
}
