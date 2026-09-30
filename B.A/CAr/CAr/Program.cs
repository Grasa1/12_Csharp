using CAr;

Model model = new Model();
Console.WriteLine(model.cars.Count);


Console.WriteLine("2016 utáni autók:");
model.AfterYear(2016).ForEach(x => Console.WriteLine(x));
Console.WriteLine("----------------------------------------");

Console.WriteLine("300 Lóerőnél erőseb autók:");
model.StrongerHp(300).ForEach(x => Console.WriteLine(x));
Console.WriteLine("----------------------------------------");

Console.WriteLine("10000000 nél olcsóbb autók:");
model.LeasExpensive(10000000).ForEach(x => Console.WriteLine(x));
Console.WriteLine("----------------------------------------");


Console.WriteLine(model.CountBrand("Volkswagen"));
Console.WriteLine("----------------------------------------");

if (model.IsBrand("Honda"))
{
    Console.WriteLine("Van benne Honda");
}
else
{
    Console.WriteLine("Nincs benne Honda");
}



model.MinHpAndCheaper(150, 300000).ForEach(x => Console.WriteLine(x));