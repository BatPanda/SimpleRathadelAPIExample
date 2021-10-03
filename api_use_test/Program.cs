using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args) {
        const string url = "http://multiversewiki.com:8080";
        const string url_parameters = "/techniques";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
            

        // List data response.
        HttpResponseMessage response = client.GetAsync(url_parameters).Result;
        if (response.IsSuccessStatusCode) {
            var dataObjects = response.Content;
            TechniqueStructure techniques_data = JsonConvert.DeserializeObject<TechniqueStructure>(dataObjects.ReadAsStringAsync().Result);
            int total_global_points = techniques_data.techniques.Aggregate(0, (_a, _b) => _a + _b.total_points);
            int total_learning_days = (int)Math.Ceiling((float)total_global_points / 2);
            float total_years = total_learning_days / 448;
            Console.WriteLine($"There are currently {techniques_data.technique_quantity} techniques!");
            Console.WriteLine($"To learn every technique you would need to allocate {total_global_points} points.");
            Console.WriteLine($"Assuming your comprehension bonus is 1 and it cannot increase, and that you always sleep at night, it would take {Math.Ceiling((float)total_global_points / 2)} days to learn everything.");
            Console.WriteLine($"In Rathadel that is {total_years} years!");
                
        } else {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
        // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();
    }
}
