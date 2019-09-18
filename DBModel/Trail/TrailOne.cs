using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Trail
{
    public class TrailOne : TrailBase
    {
        public string ImagePath { get; set; }
        public string SoundPath { get; set; }

        public static implicit operator TrailTwo(TrailOne trailOne) => new TrailTwo()
        {
            Title = trailOne.Title,
            Translation = trailOne.Translation
        };

    }
}
