namespace WebMVCnew.webModels.EventOrderModels
{
    public class EventOrderItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }


        public int Units { get; set; }

        public string PictureUrl { get; set; }
    }
}
