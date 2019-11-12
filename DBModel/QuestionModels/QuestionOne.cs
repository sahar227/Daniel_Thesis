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
        public string ImagePath { get; set; }
        public string SoundPath { get; set; }

        public QuestionOne(int userId, string askedQuestion, bool expectedAnswer, string imagePath, string soundPath) : base(userId, askedQuestion, expectedAnswer)
        {
            ImagePath = imagePath;
            SoundPath = soundPath;

        }

    }
}

