// See https://aka.ms/new-console-template for more information


using ConsoleAppProject;
using System.Text.Json;

var request = new HttpRequestMessage(HttpMethod.Get,
       "https://localhost:7225/api/project/1");
request.Headers.Add("Accept", "application/json");

var client = new HttpClient();

var response = await client.SendAsync(request);

if (response.IsSuccessStatusCode)
{
    using var responseStream = await response.Content.ReadAsStreamAsync();
    var res = await JsonSerializer.DeserializeAsync
        <Project>(responseStream);
    Console.WriteLine($"Projet : id={res.Id}, nom={res.Name}, description={res.Description}");
}
else
{
    Console.WriteLine("Response failed : " + response.StatusCode);
}