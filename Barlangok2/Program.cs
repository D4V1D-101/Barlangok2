List<Barlang> bar = new();
using StreamReader sr = new("../../../folder/asd.txt");
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
     
    bar.Add(new Barlang(sr.ReadLine().Trim())); 
}
var f4 = bar.Count();
Console.WriteLine($"4. feladat: a barlangok száma: {f4}");


var f5 = bar
    .Where(l => l.Telepules.Contains("Miskolc", StringComparison.OrdinalIgnoreCase))
    .Average(l => l.Melyseg);
Console.WriteLine($"5. feladat: az átlagos mélység: {f5:0.00}");

Console.Write("6. feladat: Kérem a védettségi szintet: ");
string vedettseg = Console.ReadLine()?.Trim();

var leghosszabb = bar
    .Where(b => b.Vedettseg.Equals(vedettseg, StringComparison.OrdinalIgnoreCase)) 
    .OrderByDescending(b => b.Hossz)
    .FirstOrDefault();

if (leghosszabb != null)
{
    Console.WriteLine($"\n\tAzon: {leghosszabb.Azon}");
    Console.WriteLine($"\tNév: {leghosszabb.Nev}");
    Console.WriteLine($"\tHossz: {leghosszabb.Hossz} m");
    Console.WriteLine($"\tMélység: {leghosszabb.Melyseg} m");
    Console.WriteLine($"\tTelepülés: {leghosszabb.Telepules}");
}
else
{
    Console.WriteLine("\nNincs ilyen védettségi szinttel barlang az adatok között!");
}


var fokved = bar.Count(l => l.Vedettseg.Equals("fokozottan védett", StringComparison.OrdinalIgnoreCase));
var megkuvedett = bar.Count(l => l.Vedettseg.Equals("megkülönböztetetten védett", StringComparison.OrdinalIgnoreCase));
var vedett = bar.Count(l => l.Vedettseg.Equals("védett", StringComparison.OrdinalIgnoreCase));

Console.WriteLine($"Fokozottan védett barlangok száma: {fokved}");
Console.WriteLine($"Megkülönböztetetten védett barlangok száma: {megkuvedett}");
Console.WriteLine($"Védett barlangok száma: {vedett}");
