using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Trail
{
    public abstract class TrailBase : DBModel
    {
        public string Title { get; set; }
        public string Translation { get; set; }
        public string SoundPath { get; set; }

    }
}
