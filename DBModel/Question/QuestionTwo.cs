using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Question
{
    public class QuestionTwo
    {
        public TrailTwo TrailDetails { get; private set; }
        public string TranslationInQuestion { get; private set; }
        public bool ExpectedAnswer { get; private set; }
        public TimeSpan AnswerTime { get; set; }
        public bool UserAnswer { get; set; }

        private Random rng = new Random();

        public static List<string> AllKnownTranslations = new List<string>();

        public QuestionTwo(TrailTwo trailTwo, bool expectedAnswer)
        {
            TrailDetails = trailTwo;
            ExpectedAnswer = expectedAnswer;

            TranslationInQuestion = SetTranslationInQuestion(trailTwo.Translation, ExpectedAnswer);

        }

        private string SetTranslationInQuestion(string actualTranslation, bool expectedAnswer)
        {
            if (expectedAnswer)
                return actualTranslation;
            return AllKnownTranslations.Except(new List<string>() { actualTranslation })
                .ToList()
                [rng.Next(AllKnownTranslations.Count - 1)];
        }

    }
}

