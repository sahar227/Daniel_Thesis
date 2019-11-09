using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheisApp.QuestionFormManager.QuestionFormCreators;

namespace TheisApp.QuestionFormManager
{
    public static class GroupFormCreatorFactory
    {
        private static TrailRepository.TrailRepository m_trailRepository = new TrailRepository.TrailRepository();
        public static List<Form> CrateFormList(UserGroup group)
        {
            var formCreator = new List<Func<TrailRepository.TrailRepository, Form>>();
            switch (group)
            {
                case UserGroup.One:
                    formCreator.Add(QuestionFormsCreator.CreatePhase1);
                    formCreator.Add(QuestionFormsCreator.CreatePhase2);
                    return Create(formCreator);

                case UserGroup.Two:
                    formCreator.Add(QuestionFormsCreator.CreatePhase2);
                    return Create(formCreator);

                case UserGroup.Three:
                    formCreator.Add(QuestionFormsCreator.CreatePhase1WithFalseImages);
                    formCreator.Add(QuestionFormsCreator.CreatePhase2);
                    return Create(formCreator);

                default: throw new NotImplementedException();
            }
        }

        private static List<Form> Create(List<Func<TrailRepository.TrailRepository, Form>> formCreators)
        {
            var formList = new List<Form>();
            foreach (var formCreator in formCreators)
                formList.Add(formCreator(m_trailRepository));
            return formList;
        }
    }
}
