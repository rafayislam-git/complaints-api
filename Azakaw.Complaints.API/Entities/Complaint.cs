using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azakaw.Complaints.API.Entities
{
    public class Complaint
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
