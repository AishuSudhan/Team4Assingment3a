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
                new EventCatalog{Name="Party",Description="Best Music Party",Day="Friday",Time="7PM",Location="seattle",Price=50,PictureUrl="http:/api/Pictures/5",EventCatagoryId=1,PopularEventId=1},
                new EventCatalog{Name="Soccer Day and Night",Description="Come with your Buddies",Day="Saturday",Time="10AM",Location="Tacoma",Price=30,PictureUrl="http:/api/Pictures/7",EventCatagoryId=4,PopularEventId=4},
                new EventCatalog{Name="Sandwich And burger",Description="Choose your food as you wish",Day="Wednesday",Time="11AM",Location="Tacoma",Price=16,PictureUrl="http:/api/Pictures/3",EventCatagoryId=5,PopularEventId=6},
                new EventCatalog{Name="Photography",Description="We will show you the best techniques",Day="tuesday",Time="10AM",Location="Tacoma",Price=50,PictureUrl="http:/api/Pictures/6",EventCatagoryId=2,PopularEventId=2},
                new EventCatalog{Name="Dancing Lights",Description="Walk with you besties",Day="Friday",Time="6PM",Price=15,PictureUrl="http:/api/Pictures/4",EventCatagoryId=3,PopularEventId=3,Location="seattle"},
                new EventCatalog{Name="Book Club",Description="Topics will be displayed on Arrival time",Day="Monday",Time="2PM",Location="Seattle",Price=0,PictureUrl="http:/api/Pictures/1",EventCatagoryId=1,PopularEventId=3},
                new EventCatalog{Name="Cookies and Chocolate",Description="choose your favorite Cookies",Day="All Day",Time="4PM",Location="Renton",Price=15,PictureUrl="http:/api/Pictures/2",EventCatagoryId=5,PopularEventId=5},
                new EventCatalog{Name="Swimming",Description="Pool is open allDay ",Day="All day",Time="3PM",Location="Renton",Price=20,PictureUrl="http:/api/Pictures/8",EventCatagoryId=4,PopularEventId=2},
                new EventCatalog{Name="Workout group",Description="Bring Your Workout friend",Day="Friday",Time="7AM",Location="seattle",Price=30,PictureUrl="http:/api/Pictures/8",EventCatagoryId=2,PopularEventId=4},

            };

        }

        private static IEnumerable<PopularEvent> getpopularevents()
        {
            return new List<PopularEvent>
           {
               new PopularEvent{EventName="Music"},
               new PopularEvent{EventName="Relaxing"},
               new PopularEvent{EventName="Holiday Lights"},
               new PopularEvent{EventName="Soccer"},
               new PopularEvent{EventName="Dessert"},
               new PopularEvent{EventName="Grab and Go"}
           };
        }

        private static IEnumerable<EventCatagory> getcategories()
        {
            return new List<EventCatagory>
                {
                new EventCatagory{Category="Entertainment"},
                new EventCatagory{Category="Hobbies"},
                new EventCatagory{Category="Holiday"},
                new EventCatagory{Category="Sports"},
                new EventCatagory{Category="Food and Drink"}
            };
            
        }
    }
}
