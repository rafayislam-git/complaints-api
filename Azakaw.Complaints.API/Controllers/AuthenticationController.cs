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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private ILogger<AuthenticationController> _logger;
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }
        /// <summary>
        /// This mehtod is authenicate the user  
        /// </summary>
        /// <param name="authenticationModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Post([FromBody] AuthenticationModel authenticationModel)
        {
            try
            {
                var response = _authenticationService.Authenticate(authenticationModel.Username, authenticationModel.Password);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
