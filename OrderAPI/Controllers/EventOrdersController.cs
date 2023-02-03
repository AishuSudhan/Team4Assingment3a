using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Models;
using System.Net;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventOrdersController : ControllerBase
    {
        private readonly EventOrdersContext _eventordersContext;

        private readonly IConfiguration _config;

        private readonly ILogger<EventOrdersController> _logger;
        //private IPublishEndpoint _bus;

        public EventOrdersController(EventOrdersContext eventordersContext,
            ILogger<EventOrdersController> logger,
            IConfiguration config
            //, IPublishEndpoint bus
            )
        {
            _config = config;
            _logger = logger;
            _eventordersContext = eventordersContext;
            //_bus = bus;
        }

        [HttpGet("{id}", Name = "[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetOrder(int id)
        {

            var item = await _eventordersContext.EventOrders
                .Include(x => x.EventOrderItems)
                .SingleOrDefaultAsync(ci => ci.OrderId == id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();

        }

        [Route("new")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] EventOrder order)
        {
            order.OrderStatus = OrderStatus.Preparing;
            order.OrderDate = DateTime.UtcNow;

            _logger.LogInformation(" In Create Order");
            _logger.LogInformation(" Order" + order.UserName);


            _eventordersContext.EventOrders.Add(order);
            _eventordersContext.EventOrderItems.AddRange(order.EventOrderItems);
            _logger.LogInformation(" Order added to context");
            _logger.LogInformation(" Saving........");

            try
            {
                await _eventordersContext.SaveChangesAsync();
                //_bus.Publish(new OrderCompletedEvent(order.BuyerId)).Wait();
                return Ok(new { order.OrderId });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("An error occored during Order saving .." + ex.Message);
                return BadRequest();
            }
        }
    }
}
