using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atlantic.Api.Services.Interfaces
{
    public interface IRedisService
    {
        /// <summary>
        /// Get all Keys in redis by pattern
        /// </summary>
        /// <param name="pattern">Pattern</param>
        /// <returns>List of keys</returns>
        List<string> GetAllKeysByPattern(string pattern);

        /// <summary>
        /// Retrieve the corresponding key value
        /// </summary>
        /// <param name="key">registry value</param>
        /// <returns>Document containing the value related to the informed key</returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Insert new record Key-Document
        /// </summary>
        /// <param name="key">registry value</param>
        /// <param name="document">Document related to the access key in the redis</param>
        Task SetAsync<T>(string key, T document, bool always = false);

        /// <summary>
        /// Insert new record Key-Document with especific time expiring
        /// </summary>
        /// <param name="key">registry value</param>
        /// <param name="document">Document related to the access key in the redis</param>
        Task SetWithTimeAsync<T>(string key, T document);
    }
}
