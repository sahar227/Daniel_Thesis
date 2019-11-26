using Common;
using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TrailRepository;

namespace TheisApp
{
    // TODO: Make sound play when word is shown
    // TODO: Add timer to questions
    public partial class StageOne : Form
    {
        private const int TimeOutTime = 30;
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
            QuestionTime.Stop();
            AudioPlayer.StopAudio();
            QuestionRepository.SaveQuestionOnes(m_questionManager.Questions);
            CurrentUser.currentUser.EndTimeStageOne = DateTime.Now;
            this.Close();
        }

        private void SetNewQuestionOrFinish()
        {
            var question = m_questionManager.GetNextQuestion();
            if (question != null)
            {
                ResetTimer();
                QuestionLabel.Text = question.AskedQuestion;
                pictureBox.ImageLocation = question.ImagePath;
                AudioPlayer.PlayAudio(question.SoundPath);
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
            m_questionManager.AnswerQuestionAndCheckIfCorrect(answer);
            SetNewQuestionOrFinish();
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private int secondsSinceQuestionStarted = TimeOutTime;

        // Ticks every second
        private void QuestionTime_Tick(object sender, EventArgs e)
        {
            secondsSinceQuestionStarted--;
            TimerLabel.Text = secondsSinceQuestionStarted.ToString();
            if (secondsSinceQuestionStarted <= 0)
            {
                QuestionTime.Stop();
                // Ask Daniel what this should say
                MessageBox.Show("Question timeout", "timeout");
                SetNewQuestionOrFinish();
                QuestionTime.Start();

            }
        }

        private void ResetTimer()
        {
            secondsSinceQuestionStarted = TimeOutTime;
            TimerLabel.Text = secondsSinceQuestionStarted.ToString();

        }
    }
}
