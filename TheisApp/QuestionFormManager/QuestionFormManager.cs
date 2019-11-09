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
    public class QuestionFormManager
    {
        private readonly List<Form> m_forms = new List<Form>();
        private int m_currentFormIndex = 0;

        public QuestionFormManager(UserGroup group)
        {
            m_forms = GroupFormCreatorFactory.CrateFormList(group);
        }

        public void Start()
        {
            OpenForm(m_forms[m_currentFormIndex]);
        }

        private void OpenForm(Form f)
        {
            //this.Hide();
            f.Closed += (s, args) => PlayNextForm();
            f.Show();
        }

        private void PlayNextForm()
        {
            m_currentFormIndex++;
            if(m_currentFormIndex < m_forms.Count)
                OpenForm(m_forms[m_currentFormIndex]);
        }
    }
}
