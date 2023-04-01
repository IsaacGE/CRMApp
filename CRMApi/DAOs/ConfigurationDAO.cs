using CRMApi.DBContext;
using CRMApi.Models;

namespace CRMApi.DAOs
{
    public class ConfigurationDAO
    {
        private static readonly CrmContext dbContext = new();

        #region GET CONFIGURATIONS

        /// <summary>
        /// Obtener las configuraciones por los paramtros indicados
        /// Se puede indicar solo un parametro o varios en la misma consulta
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Configuration> GetConfigurationByParams(Configuration config)
        {
            try
            {
                List<Configuration> configList = new();
                if (config.Id > 0)
                {
                    var result = dbContext.Configurations.First(c => c.Id == config.Id);
                    if (result != null) configList.Add(result); 
                }
                if (!string.IsNullOrEmpty(config.Type))
                {
                    var result = dbContext.Configurations.Where(c => c.Type == config.Type.Trim()).ToList();
                    if (result != null && result.Count > 0) configList.AddRange(result); 
                }
                if (!string.IsNullOrEmpty(config.ConfigKey))
                {
                    var result = dbContext.Configurations.Where(c => c.ConfigKey == config.ConfigKey.Trim()).ToList();
                    if (result != null && result.Count > 0) configList.AddRange(result);
                }
                if (config.RegisteringUser > 0)
                {
                    var result = dbContext.Configurations.Where(c => c.RegisteringUser == config.RegisteringUser).ToList();
                    if (result != null && result.Count > 0) configList.AddRange(result);
                }
                return configList;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion GET CONFIGURATIONS
    }
}
