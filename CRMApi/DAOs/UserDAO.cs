using CRMApi.DBContext;
using CRMApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApi.DAOs
{
    public class UserDAO
    {
        private static readonly CrmContext dbContext = new();

        #region GET USERS

        /// <summary>
        /// Obtener el listado de usaurios por (nombre o apellido)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<User> GetUsersByParams(User user)
        {
            try
            {
                List<User> usersList = new();
                if (!string.IsNullOrEmpty(user.Name))
                {
                    var result = dbContext.Users.Where(u => u.Name.Contains(user.Name.Trim()) || u.LastName.Contains(user.LastName.Trim())).ToList();
                    if (result != null && result.Count > 0) usersList.AddRange(result);
                }
                if (!string.IsNullOrEmpty(user.Email) || !string.IsNullOrEmpty(user.PhoneNumber))
                {
                    var result = dbContext.Users.Where(c => c.Email == user.Email.Trim() || c.PhoneNumber == user.PhoneNumber.Trim()).ToList();
                    if (result != null && result.Count > 0) usersList.AddRange(result);
                }
                return usersList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Obtener usuario por correo o numero de telefono
        /// </summary>
        /// <param name="emailOrPhone"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public User GetUserByEmailOrPhone(string emailOrPhone)
        {
            try
            {
                if (string.IsNullOrEmpty(emailOrPhone)) return new User();
                emailOrPhone = emailOrPhone.Trim();
                var userFound = dbContext.Users.Include("Role").FirstOrDefault(u => u.Email == emailOrPhone || u.PhoneNumber == emailOrPhone);
                return userFound;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Obtener usuario por ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public User GetUserByParams(int userId)
        {
            try
            {
                var user = userId > 0 ? dbContext.Users.FirstOrDefault(c => c.Id == userId) : null;
                return user ?? new User();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Obtener lista de usuarios por estatus
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<User> GetUsersByStatus(bool status)
        {
            try
            {
                List<User> userLsit = dbContext.Users.Where(u => u.Active == status).ToList();
                return userLsit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtener lista de usuarios por rol
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<User> GetUsersByRole(int roleId)
        {
            try
            {
                List<User> userLsit = dbContext.Users.Where(u => u.RoleId == roleId).ToList();
                return userLsit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Obtener lista de usuarios por codigo postal o por nombre de ciudad
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<User> GetUserByParams(User user)
        {
            try
            {
                List<User> usersList = new();
                if (!string.IsNullOrEmpty(user.ZipCode))
                {
                    var result = dbContext.Users.Where(u => u.ZipCode == user.ZipCode).ToList();
                    if (result.Count > 0) usersList.AddRange(result);
                }
                if (!string.IsNullOrEmpty(user.City))
                {
                    var result = dbContext.Users.Where(u => u.City == user.City).ToList();
                    if (result.Count > 0) usersList.AddRange(result);
                }
                return usersList;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetUserByParams {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtener lista de usuarios por rango de fechas
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<User> GetUsersByRole(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var userList = dbContext.Users.Where(u => u.RegisterDate >= fromDate && u.RegisterDate <= toDate).ToList();
                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion GET USERS
    }
}
