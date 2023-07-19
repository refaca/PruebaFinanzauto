using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLogic.Entidades;
using Newtonsoft.Json;

namespace BussinesLogic.ConexionesApi
{
    public class EstudianteService
    {
        private static HttpClient httpClient = new HttpClient();
        private readonly IConfiguration Configuration;        
        public EstudianteService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Metodo asincrono que obtiene por id una persona consumiendo la web api para consultar
        public async Task<AutorizacionApiToken> Autorizacion()
        {
            try
            {
                var UrlApi = Convert.ToString(Configuration["UrlApiAutenticacion"]);
                AutorizacionApiToken token = new AutorizacionApiToken();
                AutorizacionApi item = new AutorizacionApi();
                item.email = Convert.ToString(Configuration["EmailAutenticacion"]);
                item.password = Convert.ToString(Configuration["PasswordAutenticacion"]);

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(UrlApi, content);
                    string ApiResponse = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<AutorizacionApiToken>(ApiResponse);
                    return token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Object> AddEstudiante(Estudiantes estudiante)
        {
            try
            {
                var token = Autorizacion();
                var UrlApi = Convert.ToString(Configuration["UrlApiEstudiante"]);
                using (var httpClientHandler = new HttpClientHandler())
                {
                    httpClient = new HttpClient(httpClientHandler);

                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Result.Token);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(estudiante), Encoding.UTF8, "application/json");
                    var result = httpClient.PostAsync(UrlApi, content);
                    string apiResponse = await result.Result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AutorizacionApiToken>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
