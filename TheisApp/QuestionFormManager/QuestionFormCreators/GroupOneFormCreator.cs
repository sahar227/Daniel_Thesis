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
    public class GroupOneFormCreator : IGroupFormCreator
    {
        private TrailRepository.TrailRepository m_trailRepository;

        public GroupOneFormCreator()
        {
            m_trailRepository = new TrailRepository.TrailRepository();
        }

        public List<Form> Create()
        {
            return new List<Form>()
            {
                CreatePhase1(),
                CreatePhase2()
            };
        }

        private Form CreatePhase1()
        {
            // TODO: Maybe use dependency injection (lookup ninject)
            var trailOnes = m_trailRepository.LoadTrailOnesFromDatabase();
            var questionCreator = new QuestionOneCreator(trailOnes.SelectMany(v => v.Title).Distinct().ToList());
            var questionOneListCreator = new QuestionOneListCreator(questionCreator, trailOnes);
            var questionOneManager = new QuestionManager<QuestionOne>(questionOneListCreator);
            return new StageOne(questionOneManager);
        }

        private Form CreatePhase2()
        {
            // TODO: Maybe use dependency injection (lookup ninject)
            var trailTwos = m_trailRepository.LoadTrailTwosFromDatabase();
            var questionCreator = new QuestionTwoCreator(trailTwos.Select(v => v.Translation).Distinct().ToList());
            var questionTwoListCreator = new QuestionTwoListCreator(questionCreator, trailTwos);
            var questionTwoManager = new QuestionManager<QuestionTwo>(questionTwoListCreator);
            return new StageTwo(questionTwoManager);
        }
    }
}
