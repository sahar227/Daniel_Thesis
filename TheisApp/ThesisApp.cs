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
using TheisApp.Questions.QuestionCreator;
using TrailRepository;

namespace TheisApp
{
    public partial class ThesisApp : Form
    {
        private readonly List<User> m_group4Users = new List<User>();
        public ThesisApp()
        {
            InitializeComponent();
            m_group4Users = UserRepository.GetUnfinishedGroup4Users();
            Group4Users.Items.AddRange(m_group4Users.Select(v => v.FullName).ToArray());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            UserGroup group = CheckGroup();
            if ((!string.IsNullOrWhiteSpace(name)) && (group != UserGroup.Unknown))
            {
                CurrentUser.currentUser = new User(name, group);
                var questionFormManager = new QuestionFormManager.QuestionFormManager(group);
                this.Hide();
                questionFormManager.Start();
            }
            else
                MessageBox.Show("Error creating user");
        }

        private UserGroup CheckGroup()
        {
            if (radioButton1.Checked)
                return UserGroup.One;
            if (radioButton2.Checked)
                return UserGroup.Two;
            if (radioButton3.Checked)
                return UserGroup.Three;
            if (radioButton4.Checked)
                return UserGroup.Four;

            return UserGroup.Unknown;
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            var selectedName = Group4Users.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedName))
            {
                CurrentUser.currentUser = m_group4Users.Find(v => v.FullName == selectedName);
                var questionFormManager = new QuestionFormManager.QuestionFormManager(UserGroup.FourContinued);
                this.Hide();
                questionFormManager.Start();
            }
        }
    }
}
