﻿using LaFinca.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LaFinca.Services
{
    public class UserRestService
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

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage response = client.SendAsync(request).GetAwaiter().GetResult();

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

        public async Task<List<IUser>> AddData(IUser user)
        {
            bool doesUserExist = await GetDataById(user.username) != null;
            if (!doesUserExist)
            {
                Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/Create?username={user.username}&name={user.name}&password={user.password}&role={user.role}&email={user.email}"));
                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
            }
            return await RefreshData();
        }

        public async Task<List<IUser>> UpdateData(IUser user)
        {
            if (GetDataById(user.username) != null)
            {
                Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/Update?username={user.username}&name={user.name}&password={user.password}&role={user.role}&email={user.email}"));
                string json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                 
                HttpResponseMessage response = null;

                response = await client.PutAsync(uri, content);
            }
            return await RefreshData();
        }

        public async Task<List<IUser>> Delete(string username)
        {
            if (GetDataById(username) != null)
            {
                Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/Delete/{username}"));

                HttpResponseMessage resposne = await client.DeleteAsync(uri);

            }

            return await RefreshData();
        }

        public async Task<List<string>> FavorItem(string username,string itemName)
        {
            List<string> favoriteItems;
            Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/FavorItem?username={username}&itemName={itemName}"));

            HttpResponseMessage response = await client.GetAsync(uri);

            return await GetFavorites(username);
        }

        public async Task<List<string>> UnFavorItem(string username, string itemName)
        {
            Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/UnFavorItem?username={username}&itemName={itemName}"));

            HttpResponseMessage response = await client.GetAsync(uri);

            return await GetFavorites(username);
        }

        public async Task<List<string>> GetFavorites(string username)
        {
            List<string> favorites = new List<string>() ;

            Uri uri = new Uri(string.Format($"https://10.0.2.2:5001/Users/GetFavorites?username={username}"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage response = client.SendAsync(request).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                favorites = JsonConvert.DeserializeObject<List<string>>(content);
            }

            return favorites;
        }

    }
}
