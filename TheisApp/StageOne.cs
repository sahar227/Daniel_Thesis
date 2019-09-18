using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TheisApp
{
    // TODO: make sound play when word is shown
    // TODO: Add timer to questions
    public partial class StageOne : Form
    {
        private readonly User m_user = CurrentUser.currentUser;
        private readonly QuestionManager<QuestionOne> m_questionManager;
        public StageOne(QuestionManager<QuestionOne> questionManager)
        {
            InitializeComponent();
            m_questionManager = questionManager;
        }

        private void StageOne_Load(object sender, EventArgs e)
        {
            SetNewQuestionOrFinish();
        }


        private void FinishStageOne()
        {
            // TODO: start stage two
            this.Hide();
        }

        private void SaveUser()
        {
            // TODO move this to user repository class
            using (var context = new SampleDBContext())
            {
                context.Users.Add(m_user);
                context.SaveChanges();
            }
        }

        private void SetNewQuestionOrFinish()
        {
            var question = m_questionManager.GetNextQuestion();
            if (question != null)
            {
                QuestionLabel.Text = question.AskedQuestion;
                pictureBox.ImageLocation = question.Image;
            }
            else
            {
                m_user.StageOneQuestions.AddRange(m_questionManager.Questions);
                m_user.EndTimeStageOne = DateTime.Now;
                SaveUser();
                FinishStageOne();
            }
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            GiveAnswer(true);
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            GiveAnswer(false);
        }

        private void GiveAnswer(bool answer)
        {
            m_questionManager.AnswerQuestion(answer);
            SetNewQuestionOrFinish();
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
