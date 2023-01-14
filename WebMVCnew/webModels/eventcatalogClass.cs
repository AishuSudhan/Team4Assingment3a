namespace WebMVCnew.webModels
{
    public class EventcatalogClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int PopularEventId { get; set; }
        public int EventCatagoryId { get; set; }


        public string EventCatagory { get; set; }
        public string PopularEvent { get; set; }
    }
}
