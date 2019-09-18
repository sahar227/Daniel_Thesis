using Common.Mixins;
using DBModel.QuestionModels;
using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailRepository;

namespace TheisApp.Questions.QuestionCreator
{
    public class QuestionOneListCreator : IQuestionListCreator<QuestionOne>
    {
        private readonly IQuestionCreator<QuestionOne, TrailOne> m_questionCreator;
        private const int m_trailRepeat = 4;
        private readonly List<TrailOne> m_trails = new List<TrailOne>();

        public QuestionOneListCreator(IQuestionCreator<QuestionOne, TrailOne> questionCreator, ITrailRepository trailRepository)
        {
            m_trails = trailRepository.LoadTrailOnesFromDatabase();
            m_questionCreator = questionCreator;
        }

        public List<QuestionOne> CreateQuestions()
        {
            var questions = new List<QuestionOne>();
            foreach (var trail in m_trails)
            {
                for (int i = 0; i < m_trailRepeat; i++)
                {
                    questions.Add(m_questionCreator.CreateYesQuestion(trail));
                    questions.Add(m_questionCreator.CreateNoQuestion(trail));
                }
            }
            questions.Shuffle();
            return questions;
        }

        // TODO: Move to TrailManager project and save known letters to DB
        private static void InitializeKnownLetters(List<TrailOne> trails)
        {
            //QuestionOne.AllKnownLetters = trails.SelectMany(v => v.Title).Distinct().ToList();
        }


    }
}
