using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class Game
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }

        public Game(string line)
        {
            string[] temp = line.Split(";");
            Name = temp[0];
            Genre = temp[1];
            Publisher = temp[2];
            Year = int.Parse(temp[3]);
            Price = int.Parse(temp[4]);
            Rating = double.Parse(temp[5].Replace('.', ','));

        }
    }
}
