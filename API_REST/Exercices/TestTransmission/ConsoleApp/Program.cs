using API;
using Dtos;
using Newtonsoft.Json;
//using System.Text.Json; // pour la sérialisation

// Création d'un objet requête
var request = new HttpRequestMessage(HttpMethod.Get, // définition de la méthode dans la requête
       "https://localhost:7274/api/Test/1"); // ici l'uri du endpoint
request.Headers.Add("Accept", "application/json");

// Création du client
var client = new HttpClient();

var response = await client.SendAsync(request);

if (response.IsSuccessStatusCode)
{
    //using var responseStream = await response.Content.ReadAsStreamAsync();
    var responseStream = await response.Content.ReadAsStringAsync();
    //var res = await JsonSerializer.
    //var res2 = await JsonSerializer.DeserializeAsync<TestDto>(responseStream);
    ////var jsonString = await response.Content.ReadAsStringAsync();
    //var exercices = JsonConvert.DeserializeObject<List<ExerciceDto>>(jsonString);
    var res2 = JsonConvert.DeserializeObject<TestDto>(responseStream);

    Console.WriteLine("Requete récupérée");
    //Console.WriteLine($"{res.UserId}, {res.Name}");
    Console.WriteLine($"Id : {res2.UserId}, Name : {res2.UserName}");
}
else
{
    Console.WriteLine("Could not be parseds");
}

Console.ReadLine();