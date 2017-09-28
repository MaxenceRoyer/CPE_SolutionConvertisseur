using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ClientConvertisseurV1.Models;


namespace ClientConvertisseurV1.Service
{
    class WSService
    {
        static HttpClient _http_client;
        private static WSService _ws = null;

        /// <summary>
        /// Implémentation du pattern singleton
        /// </summary>
        /// <returns>WSService</returns>
        public static WSService GetInstance()
        {
            if (_ws == null)
            {
                _http_client = new HttpClient(); 
                _http_client.BaseAddress = new Uri("http://localhost:1671/api/");
                _http_client.DefaultRequestHeaders.Accept.Clear();
                _http_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _ws = new WSService();
            }
            return _ws;
        }

        // Constructeur par défault privé 
        private WSService()
        {

        }

        /**static void Main()
        {
            RunAsync().Wait();
        }*/

        public async Task<List<Devise>> getAllDevisesAsync(string path)
        {
            List<Devise> devises = new List<Devise>();
            HttpResponseMessage response = await _http_client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                devises = await response.Content.ReadAsAsync<List<Devise>>();
            }
            return devises;
        }
    }
}
