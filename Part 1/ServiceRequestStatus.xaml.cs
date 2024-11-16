using System.Collections.Generic;
using System.Windows;

namespace Part_1
{
    public partial class ServiceRequestStatus : Window
    {
        private ServiceRequestBST requestTree;
        private ServiceRequestGraph requestGraph;

        public ServiceRequestStatus(ServiceRequestBST tree, ServiceRequestGraph graph)
        {
            InitializeComponent();
            requestTree = tree;
            requestGraph = graph;
            LoadServiceRequests();
        }

        private void LoadServiceRequests()
        {
            lstServiceRequests.Items.Clear();
            requestTree.InOrderTraversal(request => lstServiceRequests.Items.Add(request));
        }

        private void btnShowRelatedRequests_Click(object sender, RoutedEventArgs e)
        {
            if (lstServiceRequests.SelectedItem is ServiceRequest selectedRequest)
            {
                List<int> relatedRequestIds = requestGraph.GetRelatedRequests(selectedRequest.ID);
                List<ServiceRequest> relatedRequests = new List<ServiceRequest>();

                foreach (var id in relatedRequestIds)
                {
                    var related = requestTree.Find(id);
                    if (related != null)
                        relatedRequests.Add(related);
                }

                RelatedRequestsWindow relatedRequestsWindow = new RelatedRequestsWindow(selectedRequest, relatedRequests);
                relatedRequestsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a service request to view related requests.", "Error");
            }
        }
    }
}
