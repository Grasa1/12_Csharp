using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartphobe
{
    public record Series(string Title, string Genre, string Studio)
    {
        private int _episodes { get; set; } = 0;
        private double _rating { get; set; }


        public void AddEpisode(int episode)
        {
            _episodes += episode;
        }

        public void SetRating(double rating)
        {
            _rating = rating;
        }

        

        public bool IsLong()
        {
            return _episodes >= 40;
        }


        public int GetEpisodes()
        {
            return _episodes;
        }

        internal double GetRating()
        {
            return (double)_rating;
        }
    }
}
