using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public enum OrderStatus
    {
        Preparing = 1,
        Shipped = 2,
        Delivered = 3,
    }

    public class EventOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string BuyerId { get; set; }

        public string UserName { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Address { get; set; }
        public string PaymentAuthCode { get; set; }
        public decimal OrderTotal { get; set; }
        public IEnumerable<EventOrderItem> EventOrderItems { get; set; }
        protected EventOrder()
        {
            EventOrderItems = new List<EventOrderItem>();
        }
    }
}
