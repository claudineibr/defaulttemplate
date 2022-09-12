using Microsoft.Extensions.Logging;
using Nascorp.Library.MQ.Rabbit;
using ProjetoPadraoNetCore.Domain.Events;
using System.Threading.Tasks;

namespace ProjetoPadraoNetCore.RabbitMQ
{
    public class MyServiceEventHandler : IIntegrationEventHandler<MyServiceIntegrationEvent>
    {
        private readonly ILogger<MyServiceEventHandler> _logger;

        public MyServiceEventHandler(ILogger<MyServiceEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(MyServiceIntegrationEvent @event)
        {
            //TODO IMPLEMENT
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} ({@IntegrationEvent})", @event.Id, @event);
            await Task.CompletedTask;
        }
    }
}
