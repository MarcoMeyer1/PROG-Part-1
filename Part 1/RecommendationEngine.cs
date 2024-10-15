using Part_1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Part_1
{
    public class RecommendationEngine
    {
        private EventRepository eventRepository;
        private Dictionary<string, int> userSearchPatterns;  // Tracks user search patterns

        public RecommendationEngine(EventRepository repository, Dictionary<string, int> searchPatterns)
        {
            eventRepository = repository;
            userSearchPatterns = searchPatterns;
        }

        // Get weighted recommendations based on the user's search history
        public List<Event> GetRecommendations(int maxRecommendations = 5)  
        {
            // Check if user has searched enough times to provide recommendations
            if (userSearchPatterns.Count == 0)
                return new List<Event>();

            // Calculate total number of searches to determine weight
            int totalSearches = userSearchPatterns.Values.Sum();

            // List to store recommendations
            List<Event> recommendations = new List<Event>();

            // Iterate over the user's search patterns and calculate weight-based recommendations
            foreach (var search in userSearchPatterns.OrderByDescending(c => c.Value))
            {
                string category = search.Key;
                int searchCount = search.Value;

                // Determine the number of recommendations to give for this category (weight-based)
                int numberOfRecommendationsForCategory = (int)Math.Ceiling((double)searchCount / totalSearches * maxRecommendations);

                // Fetch events from this category
                var eventsForCategory = eventRepository.GetAllEvents()
                    .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .Take(numberOfRecommendationsForCategory);

                // Add the events to the recommendations list
                recommendations.AddRange(eventsForCategory);

                // Stop if we've reached the maximum number of recommendations
                if (recommendations.Count >= maxRecommendations)
                    break;
            }

            // Ensure we only return the maximum number of recommendations
            return recommendations.Take(maxRecommendations).ToList();
        }
    }
}
