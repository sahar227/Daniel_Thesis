using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheisApp.Questions.QuestionCreator;

namespace TheisApp.QuestionFormManager.QuestionFormCreators
{
    public static class QuestionFormsCreator
    {
        public static Form CreatePhase1()
        {
            // TODO: Maybe use dependency injection (lookup ninject)
            var trailOnes = TrailRepository.TrailRepository.LoadTrailOnesFromDatabase();
            var questionCreator = new QuestionOneCreator(trailOnes.SelectMany(v => v.Title).Distinct().ToList());
            var questionOneListCreator = new QuestionOneListCreator(questionCreator, trailOnes);
            var questionOneManager = new QuestionManager<QuestionOne>(questionOneListCreator);
            return new StageOne(questionOneManager);
        }

        public static Form CreatePhase1WithFalseImages()
        {
            // TODO: Maybe use dependency injection (lookup ninject)
            var trailOnes = TrailRepository.TrailRepository.LoadTrailOnesFromDatabase();
            var questionCreator = new QuestionOneCreatorFalseImage(trailOnes.SelectMany(v => v.Title).Distinct().ToList(),
                                                                    trailOnes.Select(v => v.ImagePath).Distinct().ToList());
            var questionOneListCreator = new QuestionOneListCreator(questionCreator, trailOnes);
            var questionOneManager = new QuestionManager<QuestionOne>(questionOneListCreator);
            return new StageOne(questionOneManager);
        }

        public static Form CreatePhase2()
        {
            // TODO: Maybe use dependency injection (lookup ninject)
            var trailTwos = TrailRepository.TrailRepository.LoadTrailTwosFromDatabase();
            var questionCreator = new QuestionTwoCreator(trailTwos.Select(v => v.Translation).Distinct().ToList());
            var questionTwoListCreator = new QuestionTwoListCreator(questionCreator, trailTwos);
            var questionTwoManager = new QuestionManager<QuestionTwo>(questionTwoListCreator);
            return new StageTwo(questionTwoManager);
        }
    }
}
