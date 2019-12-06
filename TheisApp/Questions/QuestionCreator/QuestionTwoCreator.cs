using DBModel.QuestionModels;
using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheisApp.Questions.QuestionCreator
{
    public class QuestionTwoCreator : IQuestionCreator<QuestionTwo, TrailTwo>
    {
        private readonly Random m_rng = new Random();

        private readonly List<string> m_allKnownTranslations = new List<string>();

        public QuestionTwoCreator(List<string> allKnownTranslations)
        {
            m_allKnownTranslations = allKnownTranslations;
        }

        public QuestionTwo CreateNoQuestion(TrailTwo trail)
        {
            return CreateQuestion(trail, expectedAnswer: false);
        }

        public QuestionTwo CreateYesQuestion(TrailTwo trail)
        {
            return CreateQuestion(trail, expectedAnswer: true);
        }

        private QuestionTwo CreateQuestion(TrailTwo trail, bool expectedAnswer)
        {
            var questionSubject = SetTranslationInQuestion(trail.Translation, expectedAnswer);
            var questionAsked = $"{questionSubject},{trail.Title}";
            return new QuestionTwo(CurrentUser.currentUser.Id, questionAsked, trail.SoundPath, expectedAnswer);
        }

        private string SetTranslationInQuestion(string actualTranslation, bool expectedAnswer)
        {
            if (expectedAnswer)
                return actualTranslation;
            return m_allKnownTranslations.Except(new List<string>() { actualTranslation })
                .ToList()
                [m_rng.Next(m_allKnownTranslations.Count - 1)];
        }
    }
}
