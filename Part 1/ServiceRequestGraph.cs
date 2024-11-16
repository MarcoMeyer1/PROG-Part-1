using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_1
{
    public class ServiceRequestGraph
    {
        private Dictionary<int, List<int>> adjacencyList;

        public ServiceRequestGraph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Add a service request to the graph
        public void AddRequest(int id)
        {
            if (!adjacencyList.ContainsKey(id))
            {
                adjacencyList[id] = new List<int>();
            }
        }

        // Add a relationship between two requests
        public void AddRelationship(int fromId, int toId)
        {
            if (adjacencyList.ContainsKey(fromId))
            {
                adjacencyList[fromId].Add(toId);
            }
        }

        // Get related requests for a given ID
        public List<int> GetRelatedRequests(int id)
        {
            return adjacencyList.ContainsKey(id) ? adjacencyList[id] : new List<int>();
        }
    }
}
