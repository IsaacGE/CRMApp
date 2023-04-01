using CRMApi.DBContext;
using CRMApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApi.DAOs
{
    public class ClientDAO
    {
        private static readonly CrmContext dbContext = new();

        #region GET CLIENTS
        /// <summary>
        /// Obtrener todos los clientes registrados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Client> GetAll()
        {
            try
            {
                List<Client> clients = new();
                var result = dbContext.Clients.Include("CategoryNavigation").ToList();
                if (result != null && result.Count > 0)
                {
                    result.ForEach(client => { client.CategoryNavigation.Clients.Clear(); });
                    clients = result;
                }
                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetAll()] {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Obtener el listado de clientes por (nombre o apellido)
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Client> GetClientsByNameOrLastName(string client)
        {
            try
            {
                List<Client> clientsList = new();
                if (!string.IsNullOrEmpty(client))
                {
                    var result = dbContext.Clients.Where(u => u.Name.Contains(client.Trim()) || u.Name.Contains(client.Trim())).ToList();
                    if (result != null && result.Count > 0) clientsList.AddRange(result);
                }
                return clientsList;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientsByNameOrLastName()] {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Obtener cliente por correo o numero de telefono
        /// </summary>
        /// <param name="emailOrPhone"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Client? GetClientByEmailOrPhone(string emailOrPhone)
        {
            try
            {
                if (string.IsNullOrEmpty(emailOrPhone)) return null;
                emailOrPhone = emailOrPhone.Trim();
                var result = dbContext.Clients.Include("CategoryNavigation").FirstOrDefault(c => c.Email == emailOrPhone || c.PhoneNumber == emailOrPhone);
                result?.CategoryNavigation.Clients.Clear();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientByEmailOrPhone()] {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Obtener cliente por ID
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Client? GetClientById(int clientId)
        {
            try
            {
                var result = dbContext.Clients.Include("CategoryNavigation").FirstOrDefault(c => c.Id == clientId);
                result?.CategoryNavigation.Clients.Clear();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientById()] {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Obtener lista de clientes por estatus
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Client> GetClientsByStatus(bool status)
        {
            try
            {
                List<Client> result = new();
                var clients = dbContext.Clients.Where(u => u.Active == status).ToList();
                if (clients != null && clients.Count > 0) result.AddRange(clients);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientsByStatus()] {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtener lista de clientes por categoria
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Client> GetClientsByCategoryId(int categotyId)
        {
            try
            {
                List<Client> result = new();
                List<Client> clients = dbContext.Clients.Where(u => u.Category == categotyId).ToList();
                if (clients != null && clients.Count > 0) result.AddRange(clients);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientsByCategoryId()] {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Obtener lista de clientes por codigo postal o por nombre de ciudad
        /// </summary>
        /// <param name="zipCodeOrCity">Texto a buscar (codigo postal o nombre de ciudad)</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Client> GetClientsByCityOrZipCode(string zipCodeOrCity)
        {
            try
            {
                List<Client> result = new();
                if (!string.IsNullOrEmpty(zipCodeOrCity))
                {
                    var clients = dbContext.Clients.Where(c => c.ZipCode == zipCodeOrCity.Trim() || c.City == zipCodeOrCity.Trim()).ToList();
                    if (clients != null && clients.Count > 0) result.AddRange(clients);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientsByCityOrZipCode()] {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtener lista de usuarios por rango de fechas
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Client> GetClientsByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<Client> result = new();
                var clients = dbContext.Clients.Where(c => c.RegisterDate >= fromDate && c.RegisterDate <= toDate).ToList();
                if (clients != null && clients.Count > 0) result.AddRange(clients);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"ClientDAO[GetClientsByDateRange()] {ex.Message}", ex);
            }
        }

        #endregion GET CLIENTS
    }
}
