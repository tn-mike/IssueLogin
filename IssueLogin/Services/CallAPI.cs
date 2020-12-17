using IssueLogin.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IssueLogin.Services
{
    public class CallAPI
    {
        public async Task<string> CreateRequestAsync(string url, string param, string token, string type = "POST")
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();

                if (token != "")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (type.ToUpper() == "GET")
                {
                    request = new HttpRequestMessage(HttpMethod.Get, url);
                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Content = new StringContent(param, Encoding.UTF8, "application/json");
                }

                var response = await client.SendAsync(request);
                var contents = await response.Content.ReadAsStringAsync();

                return contents;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ResponseModel CallSocketAS400API(string hostNameAS400Secket, string resultCreateMessageSend)
        {
            string urlService = hostNameAS400Secket + "/Socket/SendMessage";
            ResponseModel resultModel = new ResponseModel();
            var result = PostStringReturnString(urlService, resultCreateMessageSend);
            try
            {
                return resultModel = JsonConvert.DeserializeObject<ResponseModel>(result.Result.ToString());
            }
            catch (Exception)
            {
                return resultModel;
            }
        }

        public async Task<string> PostStringReturnString(string data)
        {
            string url = "http://uat-login-as400socketmobilecustinternal.nprod.cloud/api/socket/sendmessage";
            HttpClient client = new HttpClient();
            string stringData = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, contentData).Result;

            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<ResponseModel> RequestLoginToken(string token)
        {
            string url = "http://uat-login-authenticationserviceapi.nprod.cloud/api/AuthenMobileCust/LoginToken";

            var response = await CreateRequestAsync(url, "", token);
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            result.responseTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fffffffK");

            return result;
        }

        public async Task<ResponseModel> RequestCustInfo(string token)
        {
            string url = "http://uat-login-authenticationserviceapi.nprod.cloud/api/AuthenMobileCust/GetCustomerInfo";

            var response = await CreateRequestAsync(url, "", token);
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            result.responseTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fffffffK");

            return result;
        }

        public async Task<ResponseModel> RequestCSN(string token)
        {
            string url = "http://uat-login-authenticationserviceapi.nprod.cloud/api/AuthenMobileCust/GetCustomerCSN";

            var response = await CreateRequestAsync(url, "", token);
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            result.responseTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fffffffK");

            return result;
        }

        public async Task<ResponseModel> RequestSocketLoginUser(string data)
        {
            string url = "http://uat-login-as400socketmobilecustinternal.nprod.cloud/api/socket/sendmessage";
            var response = await CreateRequestAsync(url, data, "");
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            result.responseTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fffffffK");

            return result;
        }
    }
}
