using Azakaw.Complaints.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azakaw.Complaints.API.DataProviders
{
    public interface IComplaintDataProvider
    {
        List<Complaint> GetComplaintsByUser(string userId);
        Complaint GetComplaintByComplaintId(string complaintId);
        string AddComplaint(Complaint complaint);
    }
    public class ComplaintDataAdapter : IComplaintDataProvider
    {
       private  List<Complaint> _complaints = new List<Complaint>()
        {
            new Complaint()
            {
                UserId = "1",
                Id = "1",
                Message = "This is Complaint 1",
                CreatedDate = DateTime.UtcNow,
                Status = "Resolved"
            },
            new Complaint()
            {
                UserId = "1",
                Id = "2",
                Message = "This is Complaint 2",
                CreatedDate = DateTime.UtcNow,
                Status = "Resolved"
            },
            new Complaint()
            {
                UserId = "2",
                Id = "3",
                Message = "This is Complaint 3",
                CreatedDate = DateTime.UtcNow,
                Status = "Resolved"
            },
            new Complaint()
            {
                UserId = "2",
                Id = "4",
                Message = "This is Complaint 4",
                CreatedDate = DateTime.UtcNow,
                Status = "Resolved"
            }
        };

        public string AddComplaint(Complaint complaint)
        {
            return complaint.Id;
        }

        public Complaint GetComplaintByComplaintId(string complaintId)
        {
            try
            {
                var complaint = _complaints.SingleOrDefault(x => x.Id == complaintId);
                return complaint;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Complaint> GetComplaintsByUser(string userId)
        {
            try
            {
                var complaints = _complaints.Where(x => x.UserId == userId).ToList();
                return complaints;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
