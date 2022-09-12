using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ProjetoPadraoNetCore.Domain.Utilities
{
    public class Config
    {
        public static string ConnectionString { get { return JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.Configurations[?(@.Key == 'APP.CONNECTION_STRING')].Value")?.ToString(); } }
        public static string TokenCryptography { get { return JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.Configurations[?(@.Key == 'CUSTOMER.TOKENCRYPTOGRAPHY')].Value")?.ToString(); } }
        public static string ApiKey { get { return JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.Configurations[?(@.Key == 'APP.APIKEY')].Value")?.ToString(); } }
        public static string EndPointImages { get { return JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.Configurations[?(@.Key == 'APP.ENDPOINT_IMAGES')].Value")?.ToString(); } }
        // CACHE CONFIGURATIONS
        public static string CacheInstanceName { get { return JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.CacheProfile[?(@.Key == 'CACHE.INSTANCE_NAME')].Value")?.ToString(); } }
        public static int CacheExpireTime { get { return Convert.ToInt32(JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.CacheProfile[?(@.Key == 'RESPONSECACHE.TIME')].Value")?.ToString()); } }
        public static string CacheRedisConnection { get { return JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.CacheProfile[?(@.Key == 'CACHE.REDIS.SERVER')].Value")?.ToString(); } }
        public static int CacheRedisDatabase { get { return Convert.ToInt32(JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.CacheProfile[?(@.Key == 'CACHE.REDIS.DATABASE')].Value")?.ToString()); } }
        public static int CacheRedisTimeout { get { return Convert.ToInt32(JObject.Parse(File.ReadAllText("./config.json")).SelectToken("$.CacheProfile[?(@.Key == 'RESPONSECACHE.TIMEOUT')].Value")?.ToString()); } }

        
    }
}
