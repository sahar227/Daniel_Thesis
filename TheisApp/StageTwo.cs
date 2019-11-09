using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheisApp
{
    public partial class StageTwo : Form
    {
        private readonly User m_user = CurrentUser.currentUser;
        private readonly QuestionManager<QuestionTwo> m_questionManager;

        public StageTwo(QuestionManager<QuestionTwo> questionManager)
        {
            InitializeComponent();
            m_questionManager = questionManager;
        }

        private void StageTwo_Load(object sender, EventArgs e)
        {
            SetNewQuestionOrFinish();
        }

        private void SetNewQuestionOrFinish()
        {
            var question = m_questionManager.GetNextQuestion();
            if (question != null)
            {
                QuestionLabel.Text = question.AskedQuestion;
            }
            else
            {
                m_user.StageTwoQuestions.AddRange(m_questionManager.Questions);
                m_user.EndTimeStageOne = DateTime.Now;
                SaveUser();
                FinishStage();
            }
        }

        private void SaveUser()
        {
            // TODO move this to user repository class
            /*using (var context = new SampleDBContext())
            {
                context.Users.Add(m_user);
                context.SaveChanges();
            }*/
        }

        private void GiveAnswer(bool answer)
        {
            m_questionManager.AnswerQuestion(answer);
            SetNewQuestionOrFinish();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            GiveAnswer(true);
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            GiveAnswer(false);
        }

        private void FinishStage()
        {
            this.Close();
        }
    }
}
