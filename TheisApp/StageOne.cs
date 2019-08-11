using Common.Mixins;
using DBModel;
using DBModel.Question;
using DBModel.Trail;
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
    public partial class StageOne : Form
    {
        private List<QuestionOne> m_questions;
        private User m_user = CurrentUser.currentUser;

        private int questionIndex = 0;

        public StageOne()
        {
            InitializeComponent();
        }

        private void StageOne_Load(object sender, EventArgs e)
        {
            
            m_questions = CreateQuestions();
            WordLabel.Text = m_questions[questionIndex].TrailDetails.Title;
            LetterLabel.Text = m_questions[questionIndex].LetterInQuestion.ToString();
            pictureBox.ImageLocation = m_questions[questionIndex].TrailDetails.ImagePath;
        }

        private List<QuestionOne> CreateQuestions()
        {
            List<TrailOne> trails = LoadTrails();
            InitializeKnownLetters(trails);

            var questions = new List<QuestionOne>();
            foreach (var trail in trails)
            {
                for (int i = 0; i < 4; i++)
                {
                    questions.Add(new QuestionOne(trail, true));
                    questions.Add(new QuestionOne(trail, false));
                }
            }
            questions.Shuffle();
            return questions;
        }

        private static void InitializeKnownLetters(List<TrailOne> trails)
        {
            QuestionOne.AllKnownLetters = trails.SelectMany(v => v.Title).Distinct().ToList();
        }

        private List<TrailOne> LoadTrails()
        {
            return TrailRepository.TrailRepository.Instance.m_trailOnes;
        }


        private void SetNewQuestion()
        {
            questionIndex++;
            if (questionIndex < m_questions.Count)
            {
                WordLabel.Text = m_questions[questionIndex].TrailDetails.Title;
                LetterLabel.Text = m_questions[questionIndex].LetterInQuestion.ToString();
                pictureBox.ImageLocation = m_questions[questionIndex].TrailDetails.ImagePath;
            }
            else
            {
                m_user.StageOneQuestions.AddRange(m_questions);
                using (var context = new SampleDBContext())
                {
                    context.Users.Add(m_user);
                    context.SaveChanges();
                }
                    // TODO: start stage two
                    this.Hide();
            }
        }

        private void GiveAnswer(bool answer)
        {
            m_questions[questionIndex].UserAnswer = answer;
            SetNewQuestion();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            GiveAnswer(true);
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            GiveAnswer(false);
        }
    }
}
