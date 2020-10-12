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
    public class ItemRestService 
    {
        protected HttpClient client;

        public ItemRestService()
        {
            client = new HttpClient(GetInsecureHandler());
        }

        public HttpClientHandler GetInsecureHandler()
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

        public async Task<List<MenuItem>> AddData(MenuItem obj)
        {
            bool doesItemExist = await GetDataById(obj.ItemName) != null;

            if(!doesItemExist)
            {
                Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/MenuItems/Create?ItemName={obj.ItemName}&Category={obj.Category}&Description={obj.Description}&Cost={obj.Cost}"));
                string json = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);               

            }
            return await RefreshData();
        }

        public async Task<List<MenuItem>> DeleteData(string id)
        {
            Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/MenuItems/Delete/{id}"));
            HttpResponseMessage response = await client.DeleteAsync(uri);

            return await RefreshData();
        }

        public async Task<MenuItem> GetDataById(string id)
        {
            MenuItem item = null;
            Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/MenuItems/GetByName/{id}"));

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<MenuItem>(content);
            }

            return item;
        }

        public async Task<List<MenuItem>> RefreshData()
        {
            List<MenuItem> menuItems = null;
            Uri uri = new Uri(string.Format("https://10.0.2.2:5001/MenuItems/ViewAll"));

         //   client.BaseAddress = new Uri("http://localhost:49836");
           // client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content =  await response.Content.ReadAsStringAsync();
                menuItems = JsonConvert.DeserializeObject<List<MenuItem>>(content);
            }

            return menuItems;

        }

        public async Task<MenuItem> UpdateData(MenuItem obj)
        {
            if (GetDataById(obj.ItemName) != null)
            {
                Uri uri = new Uri(string.Format("/MenuItems/Update"));
                string json = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PutAsync(uri, content);
            }

            return await GetDataById(obj.ItemName);
        }
    }
}
