using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azakaw.Complaints.API.Models;
using Azakaw.Complaints.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Azakaw.Complaints.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private ILogger<ComplaintsController> _logger;
        private IComplaintService _complaintService;
        public ComplaintsController(ILogger<ComplaintsController> logger, IComplaintService complaintService)
        {
            _logger = logger;
            _complaintService = complaintService;
        }
        // GET: api/<ComplaintsController>
        [HttpGet("usercomplaints/{userId}")]
        public IActionResult GetUserComplaints(string userId)
        {
            try
            {
                var response = _complaintService.GetComplaintsByUser(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        // GET api/<ComplaintsController>/5
        [HttpGet("{complaintId}")]
        public IActionResult Get(string complaintId)
        {
            try
            {
                var response = _complaintService.GetComplaintByComplaintId(complaintId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        // POST api/<ComplaintsController>
        [HttpPost]
        public IActionResult Post([FromBody]  ComplaintsModel complaintsModel)
        {
            try
            {
                var response = _complaintService.AddComplaint(complaintsModel);
                return Ok(new { compaintId = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
