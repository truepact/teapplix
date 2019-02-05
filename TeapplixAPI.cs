using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using TeapplixAPIAccess.Models;

namespace TeapplixAPIAccess
{
    public class TeapplixAPI : TeapplixAPIBase 
    {
        /// <param name="APIToken">Token Provided by your Teapplix</param>
        /// <param name="APIUrl">URL format - https://api.teapplix.com/api2/ </param>
        public TeapplixAPI(string APIToken, string APIUrl = "https://api.teapplix.com/api2/") : base(APIToken, APIUrl) { }
        
        public (TeapplixOrders Orders, String Error) DownloadOrders(List<KeyValuePair<OrderQueryParameters,string>> query)
        {
            string apiPath = "OrderNotification";
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            foreach (var kvp in query)
            {
                keyValues.Add(new KeyValuePair<string, string>(kvp.Key.ToString(), kvp.Value));
            }

            var response = Download(apiPath, keyValues);

            (TeapplixOrders Orders, String Error) result = (null, null);

            if (response.rxdata != null)
            {
                //for custom json settings, use this code.
                //var jsonSerializerSettings = new JsonSerializerSettings();
                //jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                //jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //result.Orders = JsonConvert.DeserializeObject<TeapplixOrders>(response.content, jsonSerializerSettings);

                result.Orders = JsonConvert.DeserializeObject<TeapplixOrders>(response.rxdata);
            }
            else
            {
                result.Error = response.error;
            }

            return result;
        }

        /// <summary>
        /// PUT request to update QueueId and "custom" field for the order.
        /// </summary>
        public (TeapplixOrderResponse result, string error) UpdateOrders(TeapplixOrders teapplixOrders)
        {
            (TeapplixOrderResponse result, string error) response = (null, null);

            var jsonstring = JsonConvert.SerializeObject(
                value: teapplixOrders,
                settings: new JsonSerializerSettings() {
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

            var reqresponse = Upload(RequestMethod.PUT, "OrderNotification", jsonstring);

            if(reqresponse.rxdata != null)
            {
                response.result = JsonConvert.DeserializeObject<TeapplixOrderResponse>(reqresponse.rxdata);
            }

            return response;
        }

        public (TeapplixProductResponse result, string error) UploadProducts(TeapplixProducts teapplixProducts)
        {
            (TeapplixProductResponse result, string error) response = (null, null);

            var jsonstring = JsonConvert.SerializeObject(
                value: teapplixProducts,
                settings: new JsonSerializerSettings()  {
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

            var reqresponse = Upload(RequestMethod.POST, "Product", jsonstring);

            if (reqresponse.rxdata != null)
            {
                response.result = JsonConvert.DeserializeObject<TeapplixProductResponse>(reqresponse.rxdata);
            }

            if (reqresponse.error != null)
                response.error = reqresponse.error;

            return response;
        }

        public (TeapplixProductResponse result, string error) UpdateProducts(TeapplixProductsForUpdate teapplixProducts)
        {
            (TeapplixProductResponse result, string error) response = (null, null);

            var jsonstring = JsonConvert.SerializeObject(
                value: teapplixProducts,
                settings: new JsonSerializerSettings()  {
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

            var reqresponse = Upload(RequestMethod.PUT, "Product", jsonstring);

            if (reqresponse.rxdata != null)
            {
                response.result = JsonConvert.DeserializeObject<TeapplixProductResponse>(reqresponse.rxdata);
            }

            if (reqresponse.error != null)
                response.error = reqresponse.error;

            return response;
        }

        public (TeapplixProductResponse result, string error) UploadInventory(TeapplixInventoryQuantities teapplixInventory)
        {
            (TeapplixProductResponse result, string error) response = (null, null);

            var jsonstring = JsonConvert.SerializeObject(
                value: teapplixInventory,
                settings: new JsonSerializerSettings() {
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

            var reqresponse = Upload(RequestMethod.POST, "ProductQuantity", jsonstring);
        
            if (reqresponse.rxdata != null)
            {
                response.result = JsonConvert.DeserializeObject<TeapplixProductResponse>(reqresponse.rxdata);
            }

            if (reqresponse.error != null)
                response.error = reqresponse.error;

            return response;
        }

        public (TeapplixProductMappingResponse result, string error) UploadProductMapping(TeapplixProductMappings teapplixProductMappings)
        {
            (TeapplixProductMappingResponse result, string error) response = (null, null);

            var jsonstring = JsonConvert.SerializeObject(
                value: teapplixProductMappings,
                settings: new JsonSerializerSettings() {
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

            var reqresponse = Upload(RequestMethod.POST, "ProductXref", jsonstring);

            if (reqresponse.rxdata != null)
            {
                response.result = JsonConvert.DeserializeObject<TeapplixProductMappingResponse>(reqresponse.rxdata);
            }

            if (reqresponse.error != null)
                response.error = reqresponse.error;

            return response;
        }
    }
}
