// See https://aka.ms/new-console-template for more information
using MyIngredient;
using MyIngredient.Models;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");


var ingredientManager = new IngredientManager(new ConsoleReader(), new ConsoleWriter());



var test = new Ingredient() { Name = "Test" };

var jsonTest = JsonConvert.SerializeObject(test);

Console.WriteLine(jsonTest);


var persitance = new MemoryPersistance<Ingredient>();
persitance.Save(new List<Ingredient> { new Ingredient { Name = "Ing1" }, new Ingredient { Name = "Ing2" } });

var myIngredients = persitance.Load(); 

foreach(var ing in myIngredients)
{
    Console.WriteLine(ing.Name);
}

while (true)
{
    Console.WriteLine("1: read, 2: create"); 
    var choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            ingredientManager.ReadAll();
            break;
        case 2:
            ingredientManager.Create();
            break; 
        default:
            Console.WriteLine("Fin du programme");

            Environment.Exit(0);
            break; 
    }

}




Console.ReadLine();
