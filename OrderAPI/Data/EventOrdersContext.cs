using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.Data
{
    public class EventOrdersContext : DbContext
    {
        public EventOrdersContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventOrder> EventOrders { get; set; }
        public DbSet<EventOrderItem> EventOrderItems { get; set; }
    }
}
