using AlbarracinEvaluacion3P.ModelsJA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbarracinEvaluacion3P.ServicesJA
{
    public class EpisodioServiceJA
    {
        public async Task<EpisodioJA> GetEpisode(int id)
        {
            EpisodioJA dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://rickandmortyapi.com/api/episode/{id}";

            try
            {
                HttpClient client = new HttpClient();
                response = await client.GetAsync(requestUrl);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<EpisodioJA>(json);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
            return dto;
        }
    }
}
