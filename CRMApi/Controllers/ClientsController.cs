using CRMApi.Common;
using CRMApi.DAOs;
using CRMApi.Helpers.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ILoggerManager _loggerManager;
        private readonly ClientDAO clientDAO = new();
        private static readonly ResponseApi responseApi = new();

        public ClientsController(ILogger<ClientsController> logger, ILoggerManager loggerManager)
        {
            _logger = logger;
            _loggerManager = 
                loggerManager;
        }

        #region GET REQUEST

        /// <summary>
        /// Metodo para obtener todo el listado de clientes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var client = clientDAO.GetAll();
                if (client == null) return NotFound(responseApi.WithoutResults());

                return Ok(responseApi.SuccessRequest(client));
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ClientsController[GetById()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }

        /// <summary>
        /// Metodo para obtener un cliente por ID
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetById(int clientId)
        {
            try
            {
                var client = clientDAO.GetClientById(clientId);
                if (client == null) return NotFound(responseApi.WithoutResults());

                return Ok(responseApi.SuccessRequest(client));
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ClientsController[GetById()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }

        /// <summary>
        /// Metodo para obtener un cliente por numero de telefono o correo electronico
        /// </summary>
        /// <param name="emailOrPhone"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByEmailOrPhone(string emailOrPhone)
        {
            try
            {
                var client = clientDAO.GetClientByEmailOrPhone(emailOrPhone);
                if (client == null) return NotFound(responseApi.WithoutResults());

                return Ok(responseApi.SuccessRequest(client));
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ClientsController[GetByEmailOrPhone()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }


        /// <summary>
        /// Metodo para obtener clientes por categoria
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByCategory(int categoryId)
        {
            try
            {
                var clients = clientDAO.GetClientsByCategoryId(categoryId);
                if (clients == null || clients.Count == 0) return NotFound(responseApi.WithoutResults());
                
                return Ok(responseApi.SuccessRequest(clients));
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ClientsController[GetByCategory()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }


        /// <summary>
        /// Metodo para obtener clientes por nombre | apellido
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByNameOrLastName(string text)
        {
            try
            {
                var clients = clientDAO.GetClientsByNameOrLastName(text);
                if (clients == null || clients.Count == 0) return NotFound(responseApi.WithoutResults());

                return Ok(responseApi.SuccessRequest(clients));
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ClientsController[GetByNameOrLastName()]", ex);
                return StatusCode(500, responseApi.Exception(ex));
            }
        }

        #endregion GET REQUEST
    }
}