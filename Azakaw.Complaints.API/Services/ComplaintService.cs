using Azakaw.Complaints.API.DataProviders;
using Azakaw.Complaints.API.Entities;
using Azakaw.Complaints.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azakaw.Complaints.API.Services
{
    public interface IComplaintService
    {
        List<ComplaintsModel> GetComplaintsByUser(string userId);
        ComplaintsModel GetComplaintByComplaintId(string complaintId);
        string AddComplaint(ComplaintsModel complaintsModel);
    }
    public class ComplaintService : IComplaintService
    {
        private IComplaintDataProvider _complaintDataProvider;
        public ComplaintService(IComplaintDataProvider complaintDataProvider)
        {
            _complaintDataProvider = complaintDataProvider;
        }

        public string AddComplaint(ComplaintsModel complaintsModel)
        {
            try
            {
                Complaint complaint = new Complaint()
                {
                    CreatedDate = DateTime.UtcNow,
                    Id = Guid.NewGuid().ToString(),
                    Message = complaintsModel.Message,
                    Status = "Intiated",
                    UserId = "1"
                };
                return _complaintDataProvider.AddComplaint(complaint);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ComplaintsModel GetComplaintByComplaintId(string complaintId)
        {
            try
            {
                var complaint = _complaintDataProvider.GetComplaintByComplaintId(complaintId);
                if(complaint != null)
                {
                    return new ComplaintsModel()
                    {
                        ComplaintId = complaint.Id,
                        CreatedDate = complaint.CreatedDate,
                        Message = complaint.Message,
                        Status = complaint.Status,
                        UserId = complaint.UserId
                    };
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComplaintsModel> GetComplaintsByUser(string userId)
        {
            try
            {
                List<ComplaintsModel> complaintList = new List<ComplaintsModel>();
                var complaints = _complaintDataProvider.GetComplaintsByUser(userId);
                foreach (var complaint in complaints)
                {
                    complaintList.Add(new ComplaintsModel()
                    {
                        ComplaintId = complaint.Id,
                        CreatedDate = complaint.CreatedDate,
                        Message = complaint.Message,
                        Status = complaint.Status,
                        UserId = complaint.UserId
                    });
                }
                return complaintList;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
