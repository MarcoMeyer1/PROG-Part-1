using System.Collections.Generic;
using System.Windows;

namespace Part_1
{
    public partial class RelatedRequestsWindow : Window
    {
        public RelatedRequestsWindow(ServiceRequest selectedRequest, List<ServiceRequest> relatedRequests)
        {
            InitializeComponent();

            // Set the selected request display
            txtSelectedRequest.Text = $"Selected Request: ID {selectedRequest.ID}, {selectedRequest.Name} ({selectedRequest.Category})";

            // Bind related requests to the ListView
            if (relatedRequests.Count > 0)
            {
                lstRelatedRequests.ItemsSource = relatedRequests;
            }
            else
            {
                lstRelatedRequests.Items.Add(new ServiceRequest(0, "No related requests found.", "", "", ""));
            }
        }


        // Close Button Click Handler
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
