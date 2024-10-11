﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Part_1
{
    public class Event
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }

    public class EventRepository
    {
        private Stack<Event> eventStack;
        private Queue<Event> eventQueue;
        private Dictionary<string, Event> eventDictionary;
        private HashSet<string> eventCategories;

        public EventRepository()
        {
            eventStack = new Stack<Event>();
            eventQueue = new Queue<Event>();
            eventDictionary = new Dictionary<string, Event>();
            eventCategories = new HashSet<string>();

            SeedEvents();
        }

        private void SeedEvents()
        {
            var events = new List<Event>()
{
    new Event { Name = "Music Festival", Category = "Music", Date = new DateTime(2024, 10, 20) },
    new Event { Name = "Jazz Night", Category = "Music", Date = new DateTime(2024, 10, 25) },
    new Event { Name = "Art Exhibition", Category = "Art", Date = new DateTime(2024, 11, 10) },
    new Event { Name = "Health Awareness Campaign", Category = "Health", Date = new DateTime(2024, 10, 25) },
    new Event { Name = "Community Clean-Up", Category = "Community", Date = new DateTime(2024, 10, 22) },
    new Event { Name = "Tech Conference", Category = "Technology", Date = new DateTime(2024, 12, 5) },
    new Event { Name = "Sports Meet", Category = "Sports", Date = new DateTime(2024, 11, 3) },
    new Event { Name = "Book Fair", Category = "Education", Date = new DateTime(2024, 11, 12) },
    new Event { Name = "Local Farmer's Market", Category = "Community", Date = new DateTime(2024, 10, 30) },
    new Event { Name = "Classical Music Concert", Category = "Music", Date = new DateTime(2024, 11, 15) },
    new Event { Name = "Indie Music Night", Category = "Music", Date = new DateTime(2024, 11, 18) },
    new Event { Name = "Sculpture Workshop", Category = "Art", Date = new DateTime(2024, 12, 2) },
    new Event { Name = "Yoga for Health", Category = "Health", Date = new DateTime(2024, 12, 8) },
    new Event { Name = "Neighborhood Safety Meeting", Category = "Community", Date = new DateTime(2024, 11, 22) },
    new Event { Name = "Blockchain Symposium", Category = "Technology", Date = new DateTime(2024, 12, 10) },
    new Event { Name = "Football Tournament", Category = "Sports", Date = new DateTime(2024, 12, 5) },
    new Event { Name = "Science Fair", Category = "Education", Date = new DateTime(2024, 12, 1) },
    new Event { Name = "Charity Bake Sale", Category = "Community", Date = new DateTime(2024, 11, 28) },
    new Event { Name = "Orchestra Performance", Category = "Music", Date = new DateTime(2024, 12, 20) },
    new Event { Name = "Modern Art Showcase", Category = "Art", Date = new DateTime(2024, 12, 15) }
};


            foreach (var evnt in events)
            {
                eventStack.Push(evnt);
                eventQueue.Enqueue(evnt);
                eventDictionary.Add(evnt.Name, evnt);
                eventCategories.Add(evnt.Category);
            }
        }

        public List<Event> GetAllEvents()
        {
            return new List<Event>(eventQueue); // Return all events in queue order
        }

        // Updated SearchEvents method to handle both text and date search
        public List<Event> SearchEvents(string query)
        {
            List<Event> results = new List<Event>();

            // Attempt to parse the query as a date
            DateTime parsedDate;
            bool isDate = DateTime.TryParseExact(query, new[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" },
                                                 CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

            foreach (var evnt in eventDictionary.Values)
            {
                // If the query is a date, search by date
                if (isDate && evnt.Date.Date == parsedDate.Date)
                {
                    results.Add(evnt);
                }
                // Otherwise, search by event name or category
                else if (!isDate && (evnt.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                     evnt.Category.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    results.Add(evnt);
                }
            }

            return results;
        }
    }
}