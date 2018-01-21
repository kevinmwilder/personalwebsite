using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace site
{
    public static class GeoLocation
    {
        public static string LocationFromIp(string ip)
        {
            //if (ip == "::1") return "localhost";
            if (ip == "::1") ip = "8.8.8.8";
            
            var url = $"http://ipinfo.io/{ip}/geo";
            var httpClient = new HttpClient();
            var result = httpClient.GetAsync(url).Result;
            var json = result.Content.ReadAsStringAsync().Result;

            //https://stackoverflow.com/a/21678495
            var data = (JObject)JsonConvert.DeserializeObject(json);
            string country = data["country"].Value<string>();
            string region = data["region"].Value<string>();
            string city = data["city"].Value<string>();
            return $"{ip} located in {city}, {region}, {country}";
        }
    }
}