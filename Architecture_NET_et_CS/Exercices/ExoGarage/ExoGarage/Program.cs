// See https://aka.ms/new-console-template for more information

/// <summary>
/// Programme principale
///     Lance le menu
/// </summary>

//try


//catch // catch des erreurs non traitées en interne


void Print<T>(List<T> list)
{
    foreach(var element in list)
    {
        Console.WriteLine(element);
    }
    Console.WriteLine($"Taille : {list.Count()}");

}

// Tests sur le comportement d'une liste
var tt = new List<int>();
Console.WriteLine(tt);
tt.Add(1);
tt.Add(2);
tt.Add(3);
Print<int>(tt);
tt.RemoveAt(1);
Print<int>(tt);
