using CartAPI.Data;
using Common.Messaging;
using MassTransit;
 

namespace CartAPI.Messaging.Consumers
{
    public class OrderEventCompletedConsumers : IConsumer<OrderCompletedEvent>
    {
        private readonly ICartRepository _repository;
        private readonly ILogger<OrderEventCompletedConsumers> _logger;
        public OrderEventCompletedConsumers(ICartRepository repository, ILogger<OrderEventCompletedConsumers> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            _logger.LogWarning("We are in consume method now...");
            _logger.LogWarning("BuyerId:" + context.Message.BuyerId);
            await _repository.DeleteCartAsync(context.Message.BuyerId);
        }
    }
}
