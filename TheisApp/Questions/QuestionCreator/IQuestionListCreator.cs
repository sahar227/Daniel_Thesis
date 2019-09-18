using System.Collections.Generic;
using DBModel.QuestionModels;

namespace TheisApp.Questions.QuestionCreator
{
    public interface IQuestionListCreator<QuestionType> where QuestionType : Question
    {
        List<QuestionType> CreateQuestions();
    }
}