using System.Windows;

namespace Part_1
{
    public partial class MainWindow : Window
    {
        private ServiceRequestBST requestTree;
        private ServiceRequestGraph requestGraph;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDummyData();
        }

        private void InitializeDummyData()
        {
            requestTree = new ServiceRequestBST();
            requestGraph = new ServiceRequestGraph();

            // Add dummy service requests
            requestTree.Insert(new ServiceRequest(1, "Water Leak", "Downtown", "Utilities", "Pending"));
            requestTree.Insert(new ServiceRequest(2, "Pothole Repair", "Uptown", "Roads", "In Progress"));
            requestTree.Insert(new ServiceRequest(3, "Power Outage", "Suburb", "Electricity", "Completed"));
            requestTree.Insert(new ServiceRequest(4, "Trash Collection", "City Center", "Sanitation", "Pending"));
            requestTree.Insert(new ServiceRequest(5, "Flood Cleanup", "Old Town", "Water Supply", "Completed"));
            requestTree.Insert(new ServiceRequest(6, "Street Cleaning", "Greenfield", "Sanitation", "In Progress"));
            requestTree.Insert(new ServiceRequest(7, "Broken Traffic Light", "Main Street", "Roads", "Pending"));
            requestTree.Insert(new ServiceRequest(8, "Tree Removal", "Hilltop", "Parks", "Completed"));
            requestTree.Insert(new ServiceRequest(9, "Leaking Pipe", "Downtown", "Utilities", "Pending"));
            requestTree.Insert(new ServiceRequest(10, "Graffiti Cleanup", "City Center", "Sanitation", "In Progress"));
            requestTree.Insert(new ServiceRequest(11, "Park Bench Repair", "Greenfield", "Parks", "Completed"));
            requestTree.Insert(new ServiceRequest(12, "Water Contamination", "Uptown", "Water Supply", "Pending"));
            requestTree.Insert(new ServiceRequest(13, "Road Repaving", "Old Town", "Roads", "In Progress"));
            requestTree.Insert(new ServiceRequest(14, "Streetlight Repair", "Hilltop", "Electricity", "Completed"));
            requestTree.Insert(new ServiceRequest(15, "Recycling Collection", "Suburb", "Sanitation", "In Progress"));

            // Add relationships between requests
            requestGraph.AddRequest(1);
            requestGraph.AddRequest(2);
            requestGraph.AddRequest(3);
            requestGraph.AddRequest(4);
            requestGraph.AddRequest(5);
            requestGraph.AddRequest(6);
            requestGraph.AddRequest(7);
            requestGraph.AddRequest(8);
            requestGraph.AddRequest(9);
            requestGraph.AddRequest(10);
            requestGraph.AddRequest(11);
            requestGraph.AddRequest(12);
            requestGraph.AddRequest(13);
            requestGraph.AddRequest(14);
            requestGraph.AddRequest(15);

            // Add relationships (dependencies)
            requestGraph.AddRelationship(1, 3);  // Request 1 depends on Request 3
            requestGraph.AddRelationship(2, 4);  // Request 2 depends on Request 4
            requestGraph.AddRelationship(5, 6);  // Request 5 depends on Request 6
            requestGraph.AddRelationship(7, 2);  // Request 7 depends on Request 2
            requestGraph.AddRelationship(8, 11); // Request 8 depends on Request 11
            requestGraph.AddRelationship(9, 1);  // Request 9 depends on Request 1
            requestGraph.AddRelationship(10, 4); // Request 10 depends on Request 4
            requestGraph.AddRelationship(12, 5); // Request 12 depends on Request 5
            requestGraph.AddRelationship(13, 2); // Request 13 depends on Request 2
            requestGraph.AddRelationship(13, 7); // Request 13 depends on Request 7 (multiple dependents)
            requestGraph.AddRelationship(14, 3); // Request 14 depends on Request 3
            requestGraph.AddRelationship(14, 10); // Request 14 depends on Request 10 (multiple dependents)
            requestGraph.AddRelationship(15, 4); // Request 15 depends on Request 4
            requestGraph.AddRelationship(15, 6); // Request 15 depends on Request 6 (multiple dependents)
        }


        private void btnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssues reportIssues = new ReportIssues();
            reportIssues.Show();
            this.Close();
        }

        private void btnLocalEvents_Click(object sender, RoutedEventArgs e)
        {
            LocalEvents localEvents = new LocalEvents();
            localEvents.Show();
            this.Close();
        }

        private void btnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            // Pass both tree and graph to the ServiceRequestStatus window
            ServiceRequestStatus statusPage = new ServiceRequestStatus(requestTree, requestGraph);
            statusPage.Show();
            this.Close();
        }
    }
}
