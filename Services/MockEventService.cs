using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.Services
{
    public class MockEventService
    {
        public static Queue<Event> GetUpcomingEvents()
        {
            var events = new Queue<Event>();

            events.Enqueue(new Event
            {
                Title = "Community Cleanup",
                Category = "Volunteer",
                Date = DateTime.Today.AddDays(1),
                Description = "Join us to clean up the local park."
            });

            events.Enqueue(new Event
            {
                Title = "Water Outage Notice",
                Category = "Public Notice",
                Date = DateTime.Today,
                Description = "Scheduled maintenance will affect water supply in Zone 3."
            });

            events.Enqueue(new Event
            {
                Title = "Town Hall Meeting",
                Category = "Government",
                Date = DateTime.Today.AddDays(3),
                Description = "Discuss upcoming infrastructure projects with city officials."
            });
            events.Enqueue(new Event
            {
                Title = "Neighborhood Tree Planting",
                Category = "Volunteer",
                Date = DateTime.Today.AddDays(2),
                Description = "Help us green the city by planting trees in the West End."
            });
            events.Enqueue(new Event
            {
                Title = "Road Closure Update",
                Category = "Public Notice",
                Date = DateTime.Today.AddDays(2),
                Description = "Main Street closed for resurfacing from 6 AM to 6 PM."
            });
            events.Enqueue(new Event
            {
                Title = "Infrastructure Budget Hearing",
                Category = "Government",
                Date = DateTime.Today.AddDays(3),
                Description = "Review and comment on proposed spending for city upgrades."
            });
            return events;
        }

        public static Dictionary<string, Color> GetCategoryColors()
        {
            return new Dictionary<string, Color>
            {
                { "Volunteer", Color.SeaGreen },
                { "Public Notice", Color.OrangeRed },
                { "Government", Color.SteelBlue }
            };
        }

    }
}
