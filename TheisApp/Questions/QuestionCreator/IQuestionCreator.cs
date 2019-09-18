using DBModel.QuestionModels;
using DBModel.Trail;

namespace TheisApp.Questions.QuestionCreator
{
    public interface IQuestionCreator<QuestionType, TrailType> where QuestionType : Question where TrailType : TrailBase
    {
        QuestionType CreateNoQuestion(TrailType trail);
        QuestionType CreateYesQuestion(TrailType trail);
    }
}