using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CAr
{
    internal class Model
    {
        public List<Car> cars = new();

        private void Import(string filename)
        {
            cars = File.ReadAllLines(filename).Skip(1)
                .Select(x => new Car(x)).ToList();
        }

        public Model()
        {
            Import("cars.txt");
        }

        public List<string> AfterYear(int year)
        {
            return cars.Where(x => x.Builtyear > year)
                .Select(x => x.Type).ToList();
        }

        public List<string> StrongerHp(int hp)
        {
            return cars.Where(x => x.Hp > hp)
                .Select(x => x.Type).ToList();
        }
        public List<string> LeasExpensive(int price)
        {
            return cars.Where(x => x.Price < price)
                .Select(x => x.Type).ToList();
        }

        public int CountBrand(string brand)
        {
            return cars.Where(x => x.Brand == brand)
                .Count();
        }

        public bool IsBrand(string brand)
        {
            return cars.Any(x => x.Brand == brand);
            
        }

        public bool IsStronger(int hp)
        {
            return cars.Any (x => x.Hp > hp);
        }

        public int MaxPrice()
        {
            return cars.Max(x => x.Price);
        }

        public double AvgBrand(string brand)
        {
            return cars.Where(x => x.Brand == brand)
                .Average(x => x.Hp);
        }

        public double AvgPrice()
        {
            return cars.Average(x => x.Price);
        }

        public List<string> AscPrice()
        {
            return cars.OrderBy(x  => x.Price)
                .Select (x => x.Type).ToList();
        }

        public List<string> DescHp()
        {
            return cars.OrderByDescending(x => x.Hp)
                .Select(x => x.Type).ToList();
        }

        public List<string> BetweenYears(int year1, int year2)
        {
            return cars.Where(x => x.Builtyear > year1 && x.Builtyear < year2)
                .Select(x => x.Type).ToList();
        }

        public List<string> MinHpAndCheaper(int minhp, int maxprice)
        {
            return cars.Where(x => x.Hp >= minhp && x.Price <= maxprice)    
                .Select(x => x.Type).ToList();
        }

        public string Youngest()
        {
            return cars.OrderByDescending(x => x.Builtyear)
                .Select(x => x.Type).First();
        }

        public List<string> Mostexpensivedb(int db)
        {
            return cars.OrderByDescending(x=>x.Price)
                .Select (x=> x.Type).Take(db).ToList();
        }

        public List<string> BrandOrderbyHp(string brand)
        {
            return cars.Where(x=> x.Brand == brand) 
                .OrderByDescending(x=> x.Hp)
                .Select(x=>x.Type).ToList();
        }

        public int AfeYear(int year)
        {
            return cars.Where(x=> x.Builtyear >= year).Count();
        }

        public double AcgMinHp(int minhp)
        {
            return cars.Where(x=>x.Hp >= minhp).Average(x=>x.Price);
        }

        public string LowestPriceMin(int minprice)
        {
            return cars.Where(x=>x.Price > minprice)
                .OrderBy(x=> x.Price)
                .Select(x=> x.Type).First();
        }

        public string Afteryearandstrongest(int year)
        {
            return cars.Where(x=> x.Builtyear > year)
                .OrderByDescending(x=> x.Hp)
                .Select(x=>x.Type).First();
        }

        public List<string> BelowAvgPrice()
        {
            return cars.Where(x => x.Price < cars.Average(x => x.Price))
                .OrderByDescending(x => x.Price)
                .Select(x => x.Type).ToList();
        }

        public List<string> Brands()
        {
            return cars.Select(x=>x.Brand).Distinct().ToList();
        }

        public int Brandscount()
        {
            return cars.Select(x => x.Brand).Distinct().Count();
        }

        public Dictionary<string, int> BrandOfCount()
        {
            return cars.GroupBy(x => x.Brand)
                .ToDictionary(x => x.Key, y => y.Count());
        }



    }
}
