using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Buddiegram.Models;

namespace Buddiegram.Data
{
    public class DatabaseService : IDatabaseService
    {

        HttpClient client;

        public DatabaseService()
        {
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
        }

        public async Task LoginDataAsync(UserLogin userlogin)
        {

            var uri = new Uri(string.Format(Constants.RestUrl, "user/signin"));

            try
            {
                var json = JsonConvert.SerializeObject(userlogin);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                    response = await client.PostAsync(uri, content);
                  //  response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task RegisterDataAsync(string userdetails)
        {

            var uri = new Uri(string.Format(Constants.RestUrl));

            try
            {
                var json = JsonConvert.SerializeObject(userdetails);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
                //  response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

    }
}
