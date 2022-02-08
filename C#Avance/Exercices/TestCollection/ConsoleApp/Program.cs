// See https://aka.ms/new-console-template for more information
using System.Collections;

// Liste non typé explicitement
var UneList = new SortedList();
UneList.GetByIndex


var MaList = new SortedList<string,string>() { {"1","un"}, { "2", "deux" } };
var varByKey = MaList["1"]; // récupération via clef
var varByIndex = MaList.ElementAt(0);


Console.ReadLine();