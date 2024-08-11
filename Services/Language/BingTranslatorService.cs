using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Language
{
    public class BingTranslatorService
    {
        private readonly string subscriptionKey = "56898885070e49308fa842d81536433f";
        private readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";
        private readonly string region = "eastus"; // Optional, if needed.

        public async Task<string> TranslateText(string text, string from, string to)
        {
            var route = $"/translate?api-version=3.0&from={from}&to={to}";
            var uri = new Uri(endpoint + route);

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.RequestUri = uri;
                    request.Content = new StringContent("[{\"Text\":\"" + text + "\"}]", System.Text.Encoding.UTF8, "application/json");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                    request.Headers.Add("Ocp-Apim-Subscription-Region", region);

                    var response = await client.SendAsync(request);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonDocument = JsonDocument.Parse(responseBody);

                    // JSON dizisinin ilk elemanını almak için
                    var firstElement = jsonDocument.RootElement.EnumerateArray().First();

                    var translatedText = firstElement.GetProperty("translations")
                                                     .EnumerateArray()
                                                     .First()
                                                     .GetProperty("text")
                                                     .GetString();

                    return translatedText;
                }
            }
        }
    }
}
