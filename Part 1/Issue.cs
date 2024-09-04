using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_1
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }

    public class IssueRepository
    {
        public static List<Issue> Issues = new List<Issue>();
    }

}
