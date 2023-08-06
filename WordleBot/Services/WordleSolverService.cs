using System.Net.Http.Json;
using System.Text.Json;
using WordleBot.Components;
using WordleBot.Models;

namespace WordleBot.Services
{
    public class WordleSolverService : IWordleSolverService
    {
        private readonly HttpClient _client;
        const string API_PATH = "https://interviewing.venteur.co/api/wordle";

        public WordleSolverService(HttpClient client)
        {
            _client = client;
        }

        public async Task<WordleResponse?> GetWordleResultAsync(List<WordleRequest> request)
        {
            try
            {

                var response = await _client.PostAsJsonAsync(API_PATH, request);

                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new Exception($"Unexpected response: No Content Returned.");
                    }

                    return await response.Content.ReadFromJsonAsync<WordleResponse>();
                    //return await JsonSerializer.Deserialize<WordleResponse>(content);
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
            }
            catch (Exception ex)
            {
                //Log the Error
                Console.WriteLine(ex.Message);
                throw;
            }

            //wordleResponse = JsonSerializer.Deserialize<WordleResponse>(content);
            //wordleResponse = await response.Content.ReadFromJsonAsync<WordleResponse>();

            //For Debugging In Dev
            //string jsonString = JsonSerializer.Serialize(request);
            //Console.WriteLine(jsonString);


            // convert response data to Article object
            //wordleResponse = await response.Content.ReadFromJsonAsync<WordleResponse>();
        }
    }
}
