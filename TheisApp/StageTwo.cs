using Common;
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
using TrailRepository;

namespace TheisApp
{
    public partial class StageTwo : Form
    {
        private readonly QuestionManager<QuestionTwo> m_questionManager;

        public StageTwo(QuestionManager<QuestionTwo> questionManager)
        {
            InitializeComponent();
            m_questionManager = questionManager;
            CurrentUser.currentUser.StartTimeStageTwo = DateTime.Now;
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
                AudioPlayer.PlayAudio(question.SoundPath);
            }
            else
            {
                FinishStage();
            }
        }

        private void GiveAnswer(bool answer)
        {
            var isCorrect = m_questionManager.AnswerQuestionAndCheckIfCorrect(answer);
            GiveFeedbackOnAnswer(isCorrect);
        }

        private void GiveFeedbackOnAnswer(bool isCorrect)
        {
            ContinueBtn.Visible = true;
            if (isCorrect)
            {
                feedbackLabel.Text = "תשובה נכונה";
                feedbackLabel.BackColor = Color.LightGreen;
            }
            else
            {
                feedbackLabel.Text = "תשובה לא נכונה";
                feedbackLabel.BackColor = Color.Red;
            }
            feedbackLabel.Visible = true;
            YesBtn.Enabled = false;
            NoBtn.Enabled = false;
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
            QuestionRepository.SaveQuestionTwos(m_questionManager.Questions);
            CurrentUser.currentUser.EndTimeStageTwo = DateTime.Now;
            AudioPlayer.StopAudio();
            this.Close();
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            SetNewQuestionOrFinish();
            PrepareControlsForNextQuestion();
        }

        private void PrepareControlsForNextQuestion()
        {
            ContinueBtn.Visible = false;
            feedbackLabel.Visible = false;
            YesBtn.Enabled = true;
            NoBtn.Enabled = true;
        }
    }
}
