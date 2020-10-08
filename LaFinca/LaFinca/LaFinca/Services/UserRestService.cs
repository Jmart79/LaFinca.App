using LaFinca.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LaFinca.Services
{
    class UserRestService
    {
        protected HttpClient client;

        public UserRestService()
        {
            client = new HttpClient(GetInsercureHandler());
        }

        public HttpClientHandler GetInsercureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async Task<List<IUser>> RefreshData()
        {
            List<IUser> users = null;

            Uri uri = new Uri(string.Format("https://10.0.2.2:5001/Users/ViewAll"));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<IUser>>(content);
            }

            return users;
        }

        public async Task<IUser> GetDataById(string username)
        {
            IUser user = null;
            Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/ViewOne/{username}"));

            HttpResponseMessage responseMessage = await client.GetAsync(uri);

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<IUser>(content);
            }

            return user;

        }

        
        


    }
}
