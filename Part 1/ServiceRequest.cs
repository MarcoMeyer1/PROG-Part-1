namespace Part_1
{
    public class ServiceRequest
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Location { get; set; }
        public string Category { get; set; }
        public string Status { get; set; } // "Pending", "In Progress", "Completed"

        public ServiceRequest(int id, string name, string location, string category, string status)
        {
            ID = id;
            Name = name;
            Location = location;
            Category = category;
            Status = status;
        }

        public override string ToString()
        {
            
            return $"{ID}: {Name} ({Category}) at {Location} - {Status}";
        }
    }
}
