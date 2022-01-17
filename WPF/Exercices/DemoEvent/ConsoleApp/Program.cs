// See https://aka.ms/new-console-template for more information

using ConsoleApp;

var counter = new Counter();
// On s'abonne ensuite à l'évènement
//counter.CounterEvent += (sender, e) => // définition de la méthode appelée lors du déclenhcmeent de l'event
//{
//    Console.WriteLine("Count ++");
//}
counter.CounterEvent += CountDisplay;
var e = new EventArgs();

void CountDisplay(object sender, EventArgs e)
{
    Console.WriteLine("Count ++");
}

Console.WriteLine("Hello, World!");
