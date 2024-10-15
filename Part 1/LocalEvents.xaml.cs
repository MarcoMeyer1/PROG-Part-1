using Part_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Part_1
{
    public partial class LocalEvents : Window
    {
        private EventRepository eventRepo;
        private RecommendationEngine recommendationEngine;
        private Dictionary<string, int> userSearchPatterns;
        private int totalSearches;  // Track the total number of searches
        private const int minSearchesForRecommendation = 5;  // Minimum searches for recommendation

        public LocalEvents()
        {
            InitializeComponent();
            eventRepo = new EventRepository();
            userSearchPatterns = new Dictionary<string, int>();  // Track user search patterns
            recommendationEngine = new RecommendationEngine(eventRepo, userSearchPatterns);
            totalSearches = 0;  // Initialize total searches to zero
            LoadEvents(); // Load all events on initialization
        }

        private void LoadEvents()
        {
            lstEvents.Items.Clear();
            foreach (var evnt in eventRepo.GetAllEvents())
            {
                lstEvents.Items.Add($"{evnt.Date.ToShortDateString()}: {evnt.Name} - {evnt.Category}");
            }
        }

        // Method triggered by the Search button
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            var searchResults = eventRepo.SearchEvents(searchQuery);  // Perform search based on query

            lstEvents.Items.Clear();

            if (searchResults.Count == 0)
            {
                lstEvents.Items.Add("No results found.");
            }
            else
            {
                foreach (var result in searchResults)
                {
                    lstEvents.Items.Add($"{result.Date.ToShortDateString()}: {result.Name} - {result.Category}");

                    // Track the category or name searched by user
                    string searchTerm = !string.IsNullOrEmpty(result.Category) ? result.Category : result.Name;

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        if (userSearchPatterns.ContainsKey(searchTerm))
                        {
                            userSearchPatterns[searchTerm]++;  // Increment count for existing search term
                        }
                        else
                        {
                            userSearchPatterns[searchTerm] = 1;  // Add new search term to dictionary
                        }
                    }
                }

                // Increment total searches
                totalSearches++;

                // Update the recommendation analysis status
                UpdateAnalysisStatus();
            }
        }


        // Recommendation button to suggest based on search patterns
        private void btnRecommend_Click(object sender, RoutedEventArgs e)
        {
            if (totalSearches < minSearchesForRecommendation)
            {
                MessageBox.Show($"Insufficient data for recommendations. Please search {minSearchesForRecommendation - totalSearches} more times.", "Recommendation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var recommendations = recommendationEngine.GetRecommendations();  

            if (recommendations.Count > 0)
            {
                txtRecommendation.ItemsSource = recommendations;  // Bind the recommendations to the ItemsControl
            }
            else
            {
                txtRecommendation.ItemsSource = null;  // Clear if no recommendations are found
            }
        }


        // Update the analysis status based on the number of searches
        private void UpdateAnalysisStatus()
        {
            int remainingSearches = minSearchesForRecommendation - totalSearches;

            if (remainingSearches <= 0)
            {
                txtAnalysisStatus.Text = "Analysis complete! You can now get recommendations.";
                txtAnalysisStatus.Foreground = new SolidColorBrush(Colors.Green);  // Change text color to green
            }
            else
            {
                txtAnalysisStatus.Text = $"Analyzing preferences, search {remainingSearches} more times to get recommendations.";
                txtAnalysisStatus.Foreground = new SolidColorBrush(Colors.Red);  // Text remains red until analysis is complete
            }
        }
    }
}
