using Common;
using DBModel;
using DBModel.QuestionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
            LetterLabel.Font = new Font("Arial", 24, FontStyle.Bold);
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

        QuestionOne m_currentQuestion;
        string m_currentWord;
        private void SetNewQuestionOrFinish()
        {
            m_currentQuestion = m_questionManager.GetNextQuestion();
            if (m_currentQuestion != null)
            {
                var questionAsked = m_currentQuestion.AskedQuestion.Split(",".ToCharArray());
                var letter = questionAsked[0];
                m_currentWord = questionAsked[1];
                LetterLabel.Text = letter;
                QuestionLabel.Visible = false;
                pictureBox.Visible = false;
                YesBtn.Visible = false;
                NoBtn.Visible = false;
                TimerLabel.Visible = false;
                LetterLabel.Visible = true;
                ShowLetterTimer.Start();
            }
            else
            {
                FinishStage();
            }
        }

        private void PrepareSecondPartOfQuestion(QuestionOne question, string word)
        {
            ShowLetterTimer.Stop();
            QuestionLabel.Visible = true;
            pictureBox.Visible = true;
            YesBtn.Visible = true;
            NoBtn.Visible = true;
            TimerLabel.Visible = true;
            LetterLabel.Visible = false;
            ResetTimer();
            QuestionLabel.Text = word;
            pictureBox.ImageLocation = question.ImagePath;
            AudioPlayer.PlayAudio(question.SoundPath);
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
            QuestionTime.Stop();
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
            }
        }

        private void ResetTimer()
        {
            secondsSinceQuestionStarted = TimeOutTime;
            TimerLabel.Text = secondsSinceQuestionStarted.ToString();
            QuestionTime.Start();
        }

        private void ShowLetterTimer_Tick(object sender, EventArgs e)
        {
            if(m_currentQuestion != null && !string.IsNullOrWhiteSpace(m_currentWord))
                PrepareSecondPartOfQuestion(m_currentQuestion, m_currentWord);
        }
    }
}
