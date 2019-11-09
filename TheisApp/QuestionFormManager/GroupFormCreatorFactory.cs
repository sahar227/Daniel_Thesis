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
        public static List<Form> CrateFormList(UserGroup group)
        {
            switch (group)
            {
                case UserGroup.One: return new GroupOneFormCreator().Create();
                default: throw new NotImplementedException();
            }
        }
    }
}
