using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.QuestionModels;
using DBModel.Trail;

namespace TheisApp.Questions.QuestionCreator
{
    public class QuestionOneCreatorFalseImage : QuestionOneCreator
    {
        private readonly List<string> m_allKnownImages = new List<string>();
        public QuestionOneCreatorFalseImage(List<char> allKnownLetters, List<string> allKnownImages) : base(allKnownLetters)
        {
            m_allKnownImages = allKnownImages;
        }

        protected override QuestionOne CreateQuestion(TrailOne trail, bool expectedAnswer)
        {
            var question =  base.CreateQuestion(trail, expectedAnswer);
            question.ImagePath = GetFalseImage(question.ImagePath);
            return question;
        }

        private string GetFalseImage(string trueImage)
        {
            if(m_allKnownImages.Count <= 1)
                throw new ApplicationException($"No other image exists");

            string falseImagePath;
            do
            {
                falseImagePath = m_allKnownImages[m_rng.Next(m_allKnownImages.Count)];
            }
            while (falseImagePath == trueImage);

            return falseImagePath;
        }
    }
}
