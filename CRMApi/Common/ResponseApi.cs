using CRMApi.DataObjectModels;
using CRMApi.Models;
using CRMApi.Security;

namespace CRMApi.Common
{
    public class ResponseApi
    {
        #region MENSAJES DE ERROR POR EXCEPCIONES
        /// <summary>
        /// Metodo que genera el response para cuado se produce una excepcion no controlada 
        /// en el sistema con un status code 500
        /// </summary>
        /// <param name="exeption"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel Exception(Exception exeption, string title = "")
        {
            try
            {
                return new ResponseModel
                {
                    Message = exeption.Message,
                    Title = string.IsNullOrEmpty(title) ? "¡Ha ocurrido un error!" : title,
                    StatusCode = 500
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion MENSAJES DE ERROR POR EXCEPCIONES


        #region MENSAJES DE RESPUESTA PARA RESPUESTAS EXITOSAS
        /// <summary>
        /// Metodo que genera el response para respuestas exitosas con status 200
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel SuccessRequest(dynamic? responseData = null)
        {
            try
            {
                return new ResponseModel
                {
                    Message = "Ok",
                    Title = "¡Ok!",
                    StatusCode = 200,
                    ObjectResponse = responseData
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion MENSAJES DE RESPUESTA PARA RESPUESTAS EXITOSAS


        #region MENSAJES DE RESUPUESTA DE AUTENTICACION

        /// <summary>
        /// Metodo que genera el response para usaario incorrecto / no encontrado
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel UserNotFound()
        {
            try
            {
                return new ResponseModel
                {
                    Message = "No se ha encontrado el usuario por el correo/telefono ingresado.",
                    Title = "¡Credenciales incorrectas!",
                    StatusCode = 400
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Metodo que genera el response para la contraseña incorrecta
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel IncorrectPassword()
        {
            try
            {
                return new ResponseModel
                {
                    Message = "La contraseña ingresada no es correcta. \nVerifica y vuelve a intentar.",
                    Title = "¡Credenciales incorrectas!",
                    StatusCode = 400
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo que genera el response para cuando el usaurio se encuentra inactivo
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel DisabledUser()
        {
            try
            {
                return new ResponseModel
                {
                    Message = "El usuario se encuentra temporalmente desactivado.",
                    Title = "¡Usuario bloqueado!",
                    StatusCode = 403
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo que genera el response de la autenticacion exitosa del usaurio
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Datos del usaurio con el token</returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel AuthOk(User user)
        {
            try
            {
                string token = TokenGenerator.GenerateTokenJwt(user);
                user.Role.Users = new List<User>();
                return new ResponseModel
                {
                    Message = "Ok",
                    Title = "¡Ok!",
                    StatusCode = 200,
                    ObjectResponse = user,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion MENSAJES DE RESUPUESTA DE AUTENTICACION


        #region MENSAJES DE RESPUESTA PARA REGISTROS NO ENCONTRADOS

        /// <summary>
        /// Metodo que genera el response para cuando no se encuentran registros 
        /// por busqueda por medio de parametros
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel WithoutResults(string title = "", string message = "")
        {
            try
            {
                return new ResponseModel
                {
                    Message = !string.IsNullOrEmpty(message) ? message : "No se han encontrado resultados para la busqueda realizada.",
                    Title = !string.IsNullOrEmpty(title) ? title : "¡Sin resultados!",
                    StatusCode = 404
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion MENSAJES DE RESPUESTA PARA REGISTROS NO ENCONTRADO POR BUSQUEDAS


        #region PING TEST
        /// <summary>
        /// Metodo para prueba de conectividad
        /// </summary>
        /// <returns></returns>
        public ResponseModel Ping()
        {
            try
            {
                return new ResponseModel
                {
                    Message = "Conexion exitosa",
                    Title = "¡Conexion exitosa!",
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion PING TEST
    }
}
