using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.QuestionModels
{
    public class QuestionOne : Question
    {
        public string Image { get; set; }
        public string Sound { get; set; }

        public QuestionOne(TrailOne trailDetails, string question, bool expectedAnswer) : base(question, expectedAnswer)
        {
            Image = trailDetails.ImagePath;
            Sound = trailDetails.SoundPath;
        }

    }
}

