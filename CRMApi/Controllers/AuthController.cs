using CRMApi.Common;
using CRMApi.DAOs;
using CRMApi.DataObjectModels;
using CRMApi.Helpers.Logger;
using CRMApi.Models;
using CRMApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ILoggerManager _loggerManager;
        private readonly UserDAO userDAO = new();
        private static readonly ResponseApi responseApi = new();

        public AuthController(ILogger<AuthController> logger, ILoggerManager loggerManager)
        {
            _logger = logger;
            _loggerManager = loggerManager;
        }


        [HttpGet]
        public IActionResult Ping()
        {
            try
            {
                return Ok(responseApi.Ping());
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("AuthController[Ping()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }

        /// <summary>
        /// Endpoint que realiza el proceso de validacion de las credenciales del usuario
        /// ademas se valida el estaus del usuario (si se encuentra desactivado o activo)
        /// </summary>
        /// <param name="requestAuthModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Authenticate([FromBody] RequestAuthModel requestAuthModel)
        {
            try
            {
                var userFound = userDAO.GetUserByEmailOrPhone(requestAuthModel.EmailOrPhone ?? "");
                if (userFound == null || userFound.Id == 0)  
                    return BadRequest(responseApi.UserNotFound());
                else
                {
                    if (!userFound.Active) return BadRequest(responseApi.DisabledUser());
                    string passwordHash = Encrypter.EncryptText(requestAuthModel.Password ?? "0");
                    if (userFound.Password != passwordHash) return BadRequest(responseApi.IncorrectPassword());
                    return Ok(responseApi.AuthOk(userFound));
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("AuthController[Authenticate()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }
    }
}