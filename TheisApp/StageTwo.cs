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

        private const int NumberOfBlocks = 4;
        private readonly int m_blockSize;
        private int m_correctAnswersForBlock = 0;
        private int m_shownQuestionNumber = 0;
        public StageTwo(QuestionManager<QuestionTwo> questionManager)
        {
            InitializeComponent();
            QuestionLabel.Font = new Font("Arial", 20, FontStyle.Regular);
            m_questionManager = questionManager;
            CurrentUser.currentUser.StartTimeStageTwo = DateTime.Now;
            m_blockSize = m_questionManager.Questions.Count / NumberOfBlocks;
        }

        private void StageTwo_Load(object sender, EventArgs e)
        {
            SetNewQuestionOrFinish();
        }

        private QuestionTwo m_currentQuestion = null;
        private void SetNewQuestionOrFinish()
        {
            m_shownQuestionNumber++;
            if ((m_shownQuestionNumber != 1) && (m_shownQuestionNumber % m_blockSize == 1))
            {
                var correctPercent = ((double)m_correctAnswersForBlock / m_blockSize) * 100;
                MessageBox.Show($"On block {m_shownQuestionNumber / m_blockSize }, answered {correctPercent.ToString("#.##")}% correctly");
                m_correctAnswersForBlock = 0;
            }
            m_currentQuestion = m_questionManager.GetNextQuestion();
            if (m_currentQuestion != null)
            {
                var askedQuestion = m_currentQuestion.AskedQuestion.Split(",".ToArray());
                QuestionLabel.Text = askedQuestion[0];
                AudioPlayer.PlayAudio(m_currentQuestion.SoundPath);
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
                m_correctAnswersForBlock++;
            }
            else
            {
                feedbackLabel.Text = "תשובה לא נכונה";
                feedbackLabel.BackColor = Color.Red;
            }
            feedbackLabel.Visible = true;
            YesBtn.Enabled = false;
            NoBtn.Enabled = false;
            ReplaySoundBtn.Enabled = false;
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
            ReplaySoundBtn.Enabled = true;
        }

        private void ReplaySoundBtn_Click(object sender, EventArgs e)
        {
            AudioPlayer.PlayAudio(m_currentQuestion.SoundPath);
        }
    }
}
