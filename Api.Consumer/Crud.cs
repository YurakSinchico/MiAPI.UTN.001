using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Consummer
{
    public static class Crud<T>
    {
        public static string Endpoint { get; set; }
        public static T Create(T data)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, Endpoint);
                    var contentBody = new StringContent(
                        System.Text.Json.JsonSerializer.Serialize(data),
                        Encoding.UTF8, "application/json"
                    );
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                        );

                   
                    var response = httpClient.Send(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var result = System.Text.Json.JsonSerializer.Deserialize<T>(json);

                        return result;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
                
        }

        public static T ReadById(string id)
        {
            return default;
        }

        public static List<T> ReadAll()
        {
            return new List<T>();
        }
        public static bool Update(string id, T data)
        {
            return false;
        }

        public static bool Delete(string id)
        {
            return true;
        }

    }
}