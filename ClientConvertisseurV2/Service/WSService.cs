using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ClientConvertisseurV2.Models;


namespace ClientConvertisseurV2.Service
{
    /// <summary>
    /// Classe WSService - Service d'appels à l'application WS WSSservice
    /// <para> 
    /// Maxence Royer
    /// </para>
    /// </summary>
    class WSService
    {
        // Attribut _http_client
        static HttpClient _http_client;

        // Attribut _ws pour implémentation du DP Singleton
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

        /// <summary>
        /// Constructeur vide
        /// </summary>
        private WSService()
        {

        }

        /// <summary>
        /// Méthode permettant de récupérer la liste de Devise à partir des WS
        /// </summary>
        /// <param name="path">String : url de la ressource demandée</param>
        /// <returns>devises : liste de Devise</returns>
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
