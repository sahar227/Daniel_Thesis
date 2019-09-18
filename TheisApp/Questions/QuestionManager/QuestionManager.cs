using Common.Mixins;
using DBModel.QuestionModels;
using DBModel.Trail;
using System.Collections.Generic;
using System.Linq;
using TheisApp.Questions;
using TheisApp.Questions.QuestionCreator;

namespace TheisApp
{
    public class QuestionManager<QuestionType> where QuestionType : Question
    {
        public List<QuestionType> Questions { get; private set; }

        private int index = 0;

        private QuestionType m_currentQuestion;
        public QuestionManager(IQuestionListCreator<QuestionType> questionListCreator)
        {
            Questions = questionListCreator.CreateQuestions();
        }

        public QuestionType GetNextQuestion()
        {
            if (index < Questions.Count)
            {
                m_currentQuestion = Questions[index++];
                return m_currentQuestion;
            }
            else
                return null;
        }

        public void AnswerQuestion(bool answer)
        {
            m_currentQuestion.UserAnswer = answer;
        }



    }
}
