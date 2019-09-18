﻿using Common.Mixins;
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
    public class QuestionTwoListCreator : IQuestionListCreator<QuestionTwo>
    {
        private readonly IQuestionCreator<QuestionTwo, TrailTwo> m_questionCreator;
        private const int m_trailRepeat = 4;
        private readonly List<TrailTwo> m_trails = new List<TrailTwo>();


        public QuestionTwoListCreator(IQuestionCreator<QuestionTwo, TrailTwo> questionCreator, ITrailRepository trailRepository)
        {
            m_trails = trailRepository.LoadTrailTwosFromDatabase();
            m_questionCreator = questionCreator;
        }
        public List<QuestionTwo> CreateQuestions()
        {
            var questions = new List<QuestionTwo>();
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
    }

}
