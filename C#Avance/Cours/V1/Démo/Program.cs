// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Démo;

SortedList<string, string> test = new SortedList<string, string>();
Console.WriteLine(test["1"]);
test.ElementAt(1);

SortedList<int, User> myUser = new SortedList<int, User>()
{
    {1, new User() { Name =  "Paul"  } }
};


SortedList<int, string> myList = new SortedList<int, string>()
{
    { 1 , "elem1" },
    { 2 , "elem2" },
    { 3 , "elem3" }
};

// ça marche ??? -> NON (attention aux exceptions)
//myList.Add(1, "elem1bis");

if (myList.ContainsKey(1))
{
    Console.WriteLine("Contiens deja la clés");
}

myList[1] = "elemNew";

myList.ContainsValue("elem1");

//recuperer 1ere element 
Console.WriteLine(myList[2]);


foreach(KeyValuePair<int, string> kvp in myList)
{
    Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
}


Console.ReadLine();