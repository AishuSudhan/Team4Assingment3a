using EventCatalogAPI.domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class EventCatalogSeed
    {
        public static void Seed(EventCatalogContext context)
        {
            context.Database.Migrate();
            if(!context.eventCatagories.Any())
            {
                context.eventCatagories.AddRange(getcategories());
                context.SaveChanges();
            }
            if(!context.popularEvents.Any())
            {
                context.popularEvents.AddRange(getpopularevents());
                context.SaveChanges();
            }
            if(!context.eventCatalogs.Any())
            {
                context.eventCatalogs.AddRange(getcatalogs());
                context.SaveChanges();
            }
                
        }

        private static IEnumerable<EventCatalog> getcatalogs()
        {
            return new List<EventCatalog>
            {
                new EventCatalog{Name="Country Music",Description="Best Music Party",Day="Friday",Time="7PM",Price=50,PictureUrl="",EventCatagoryId=1,PopularEventId=2},
                new EventCatalog{Name="Soccer",Description="Come with your Buddies",Day="Saturday",Time="10AM",Price=30,PictureUrl="",EventCatagoryId=4,PopularEventId=3},
                new EventCatalog{Name="Sandwich And burger",Description="Choose your food as you wish",Day="Wednesday",Time="11AM",Price=16,PictureUrl="",EventCatagoryId=2,PopularEventId=4},
                new EventCatalog{Name="Photography",Description="We will show you the best techniques",Day="tuesday",Time="10AM",Price=50,PictureUrl="",EventCatagoryId=5,PopularEventId=3},
                new EventCatalog{Name="Holiday Lights",Description="Walk with you besties",Day="Friday",Time="6PM",Price=15,PictureUrl="",EventCatagoryId=3,PopularEventId=1},
                new EventCatalog{Name="Book Club",Description="Topics will be displayed on Arrival time",Day="Monday",Time="2PM",Price=0,PictureUrl="",EventCatagoryId=1,PopularEventId=3},
                new EventCatalog{Name="Cookies and Chocolate",Description="choose your favorite Cookies",Day="All Day",Time="4PM",Price=15,PictureUrl="",EventCatagoryId=1,PopularEventId=4},
                new EventCatalog{Name="Swimming",Description="Pool is open allDay ",Day="All day",Time="3PM",Price=20,PictureUrl="",EventCatagoryId=1,PopularEventId=5},
                new EventCatalog{Name="Workout group",Description="Bring Your Workout friend",Day="Friday",Time="7AM",Price=30,PictureUrl="",EventCatagoryId=2,PopularEventId=5},

            };

        }

        private static IEnumerable<PopularEvent> getpopularevents()
        {
            return new List<PopularEvent>
           {
               new PopularEvent{Location="seattle"},
               new PopularEvent{Location="Tacoma"},
               new PopularEvent{Location="Tacoma"},
               new PopularEvent{Location="Tacoma"},
               new PopularEvent{Location="Seattle"},
               new PopularEvent{Location="Renton"}
           };
        }

        private static IEnumerable<EventCatagory> getcategories()
        {
            return new List<EventCatagory>
                {
                new EventCatagory{Category="Music"},
                new EventCatagory{Category="Hobbies"},
                new EventCatagory{Category="Holiday"},
                new EventCatagory{Category="Sports"},
                new EventCatagory{Category="Food and Drink"}
            };
            
        }
    }
}
