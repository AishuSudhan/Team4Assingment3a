namespace EventCatalogAPI.domain
{
    public class EventCatalog
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //public string Location { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int PopularEventId { get; set; }
        public int EventCatagoryId { get; set; }


        public virtual EventCatagory EventCatagoryid { get; set; }
        public virtual PopularEvent PopularEventid { get; set; }

       // public virtual EventCatagory EventCatagorylocation { get; set; }
        //public virtual PopularEvent PopularEventlocation { get; set; }
        
        
    }
}
