using CRMApi.DataObjectModels;
using CRMApi.Helpers.Logger;
using CRMApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
       
        private readonly ILogger<UserController> _logger;
        private readonly ILoggerManager _loggerManager;

        public UserController(ILogger<UserController> logger, ILoggerManager loggerManager)
        {
            _logger = logger;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = new List<User>();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("UsersController[GetUsers()]", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}