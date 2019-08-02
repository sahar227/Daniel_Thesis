using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Utils
{
    public static class TrailMixins
    {
        public static void InitTrail(this TrailBase trail, string title, string translation)
        {
            trail.Title = title;
            trail.Translation = translation;
        }
    }
}
