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
                string searchTerm = search.Key; // Could be either category or name
                int searchCount = search.Value;

                // Determine the number of recommendations to give for this search term (weight-based)
                int numberOfRecommendationsForTerm = (int)Math.Ceiling((double)searchCount / totalSearches * maxRecommendations);

                // Fetch events matching the search term (either category or name)
                var eventsForTerm = eventRepository.GetAllEvents()
                    .Where(e => e.Category.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                             || e.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)  // Case-insensitive name match
                    .Take(numberOfRecommendationsForTerm);


                // Add the events to the recommendations list
                recommendations.AddRange(eventsForTerm);

                // Stop if we've reached the maximum number of recommendations
                if (recommendations.Count >= maxRecommendations)
                    break;
            }

            // Ensure we only return the maximum number of recommendations
            return recommendations.Take(maxRecommendations).ToList();
        }
    }
}
