// See https://aka.ms/new-console-template for more information
using Games;

Console.WriteLine("Hello, World!");
Model model = new Model();


foreach (KeyValuePair<string, int> item in model.PublisherCount())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}

Console.WriteLine("----------------------------------------------------");

foreach (KeyValuePair<string, int> item in model.GenreCount())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}

Console.WriteLine("----------------------------------------------------");

foreach (KeyValuePair<string, double> item in model.PublisherAvgPrice())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}

Console.WriteLine("----------------------------------------------------");

foreach (KeyValuePair<string, double> item in model.GenreAvgRating())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}

Console.WriteLine("----------------------------------------------------");

foreach (KeyValuePair<string, double> item in model.MaxRating())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}

Console.WriteLine("----------------------------------------------------");

foreach (KeyValuePair<string, string> item in model.MostExpensiveGame())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}

Console.WriteLine("----------------------------------------------------");

model.PublisherMin4().ForEach( x => Console.WriteLine(x));

Console.WriteLine("----------------------------------------------------");

foreach (KeyValuePair<string, double> item in model.PublisherAvOrder())
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}
