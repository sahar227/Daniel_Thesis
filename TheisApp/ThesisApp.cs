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

namespace TheisApp
{
    public partial class ThesisApp : Form
    {
        public ThesisApp()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // TODO: Make sure to handle creation of proper experience per group
        // TODO: Maybe make form loading dictionary per group to easily manipulate which group sees what stages
        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            UserGroup group = CheckGroup();
            if ((!string.IsNullOrWhiteSpace(name)) && (group != UserGroup.Unknown))
            {
                CurrentUser.currentUser = new User(name, group);
                // TODO: Create actual questionManager as parameter (Lookup ninject for dependency injection)
                var trailRepository = new TrailRepository.TrailRepository();
                var trailOnes = trailRepository.LoadTrailOnesFromDatabase();
                var questionCreator = new QuestionOneCreator(trailOnes.SelectMany(v => v.Title).Distinct().ToList());
                var questionOneListCreator = new QuestionOneListCreator(questionCreator, trailOnes);
                var questionOneManager = new QuestionManager<QuestionOne>(questionOneListCreator);
                OpenForm(new StageOne(questionOneManager));
            }
            else
                MessageBox.Show("Error creating user");
        }

        private void OpenForm(Form f)
        {
            this.Hide();
            f.Closed += (s, args) => this.Close();
            f.Show();
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
    }
}
