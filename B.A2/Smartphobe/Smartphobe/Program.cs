// See https://aka.ms/new-console-template for more information
using Smartphobe;

Console.WriteLine("Smartphones");
List<SmartPhone> smartphones = new List<SmartPhone>()
{
    new SmartPhone("Samsung", "Galaxy S24", 2024) {Rating = 9.1 },
    new SmartPhone("Apple", "iPhone 15", 2023){Rating =  9.3 },
    new SmartPhone("Xiaomi", "Redmi Note 13", 2024){Rating= 8.4 },
    new SmartPhone("Google", "Pixel 8", 2023) {Rating = 9.0 },
    new SmartPhone("Samsung", "Galaxy A55", 2024) {Rating= 8.6 },
    new SmartPhone("OnePlus", "OnePlus 12", 2024) {Rating = 8.9 },
    new SmartPhone("Apple", "iPhone 14", 2022) {Rating = 8.8},
    new SmartPhone("Xiaomi", "Xiaomi 14", 2024) {Rating = 9.2}
};

smartphones[0].SetPrice(329000);
smartphones[1].SetPrice(349000);
smartphones[2].SetPrice(119000);
smartphones[3].SetPrice(279000);
smartphones[4].SetPrice(169000);
smartphones[5].SetPrice(299000);
smartphones[6].SetPrice(289000);
smartphones[7].SetPrice(319000);

Console.WriteLine("---------------------------------------------------------");

smartphones.Where(x => x.GetReleaseYear() == 2024).Select(x => x.Model).ToList().ForEach(x => Console.WriteLine(x));
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine(smartphones.OrderByDescending(x=>x.Rating).Select(x=>x.Model).First());
Console.WriteLine("---------------------------------------------------------");

int CountBrand(string brand)
{
    return smartphones.Where(x=>x.Brand == brand).Count();
}
Console.WriteLine(CountBrand("Samsung"));
Console.WriteLine("---------------------------------------------------------");


List<Hotel> hotels = new List<Hotel>()
{
    new Hotel("Grand Palace", "Budapest", 5) {Rating = 9.4 },
    new Hotel("City Hotel", "Budapest", 3) {Rating =8.2 },
    new Hotel("Blue Sea Resort", "Split", 4) {Rating = 9.1 },
    new Hotel("Royal Beach", "Barcelona", 5) {Rating = 9.3 },
    new Hotel("Mountain View", "Salzburg", 4){Rating = 8.8 },
    new Hotel("Central Stay", "Prague", 3) {Rating = 8.5 },
    new Hotel("Luxury Garden", "Vienna", 5) {Rating = 9.2 },
    new Hotel("Sunset Hotel", "Split", 4) {Rating = 8.9 },
};
hotels[0].SetPricePerNight(68000);
hotels[0].SetPricePerNight(32000);
hotels[0].SetPricePerNight(54000);
hotels[0].SetPricePerNight(82000);
hotels[0].SetPricePerNight(46000);
hotels[0].SetPricePerNight(28000);
hotels[0].SetPricePerNight(75000);
hotels[0].SetPricePerNight(49000);

Console.WriteLine(hotels.OrderBy(x=>x.SummaPrice(1)).Select(x=>x.Name).First());
Console.WriteLine("---------------------------------------------------------");
List<string>InCity(string city)
{
    return hotels.Where(x=>x.City == city).Select(x=>x.Name).ToList();
    Console.WriteLine("---------------------------------------------------------");

}
InCity("Budapest").ForEach(x => Console.WriteLine(x));
Console.WriteLine("---------------------------------------------------------");

hotels.OrderByDescending(x=>x.Rating).Select(x=>x.Name).Take(3).ToList().ForEach(x=> Console.WriteLine(x));





