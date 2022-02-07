// See https://aka.ms/new-console-template for more information


using ConsoleApp;

var t1 = new PrinterThread();
await t1.Start();

var t2 = new PrinterThread();
await t2.Start();

//var t3 = new PrinterThread();
//var t4 = new PrinterThread();
//var threads = new List<PrinterThread>() { t3, t4 };

Parallel.For(0, 10, async i =>
 {
     var t = new PrinterThread();
     await t.Start();
    //await threads[i].Start();
 });

Console.ReadLine();