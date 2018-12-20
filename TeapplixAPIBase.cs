using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeapplixAPIAccess
{
    public class TeapplixAPIBase
    {
        private string _APIToken;
        private string _APIUrl;
        protected enum RequestMethod  {  POST, PUT, DELETE }

        /// <param name="APIToken">Token Provided by your Teapplix</param>
        /// <param name="APIUrl">URL format - https://api.teapplix.com/api2/ </param>
        protected TeapplixAPIBase(string APIToken, string APIUrl = "https://api.teapplix.com/api2/")
        {
            _APIToken = APIToken;
            _APIUrl = APIUrl;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// General Upload function to perform POST, PUT and DELETE
        /// </summary>
        /// <param name="httpMethod">POST, PUT, DELETE</param>
        protected (string rxdata, string error) Upload(RequestMethod requestMethod, string apiPath, string json)
        {
            string httpMethod = requestMethod.ToString();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_APIUrl);

                (string rxdata, string error) result = (null, null);

                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.Add("APIToken", _APIToken);

                var _httpMethod = new HttpMethod(httpMethod);
                var request = new HttpRequestMessage(_httpMethod, apiPath);
                request.Content = stringContent;

                var response = httpClient.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        result.rxdata = content.ReadAsStringAsync().Result;
                    }
                }
                else
                {
                    result.error = response.StatusCode.ToString() + " - " + response.ReasonPhrase;
                }

                return result;
            }
        }

        /// <summary>
        /// GET function to download Teapplix data
        /// </summary>
        /// <param name="apiPath">exampe: "OrderNotification"</param>
        /// <param name="queryCollection"></param>
        /// <returns></returns>
        protected (string rxdata, string error) Download(string apiPath, IEnumerable<KeyValuePair<string, string>> queryCollection)
        {
            string queryString = "";
            string pathWithQuery = apiPath;
            if (queryCollection != null)
            {
                var encodedUrl = new FormUrlEncodedContent(queryCollection);
                queryString = encodedUrl.ReadAsStringAsync().Result;
            }

            if (queryString.Length > 0)
                pathWithQuery = apiPath + "?" + queryString;

            using (HttpClient httpClient = new HttpClient())
            {
                (string data, string error) result = (null, null);

                httpClient.BaseAddress = new Uri(_APIUrl);
                httpClient.DefaultRequestHeaders.Add("APIToken", _APIToken);
                var response = httpClient.GetAsync(pathWithQuery).Result;

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        result.data = content.ReadAsStringAsync().Result;
                    }
                }
                else
                {
                    result.error = response.StatusCode.ToString() + " - " + response.ReasonPhrase;
                }

                return result;
            }
        }
    }
}
