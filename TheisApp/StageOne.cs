using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TheisApp
{
    // TODO: Make sound play when word is shown
    // TODO: Add timer to questions
    public partial class StageOne : Form
    {
        private readonly QuestionManager<QuestionOne> m_questionManager;

        public StageOne(QuestionManager<QuestionOne> questionManager)
        {
            InitializeComponent();
            m_questionManager = questionManager;
            CurrentUser.currentUser.StartTimeStageOne = DateTime.Now;
        }

        private void StageOne_Load(object sender, EventArgs e)
        {
            SetNewQuestionOrFinish();
        }


        private void FinishStage()
        {
            CurrentUser.AddQuestionOnes(m_questionManager.Questions);
            CurrentUser.currentUser.EndTimeStageOne = DateTime.Now;
            this.Close();
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
                FinishStage();
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
