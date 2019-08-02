using DBModel.Trail;
using DBModel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisProject
{
    public partial class TrailManagerForm : Form
    {
        Dictionary<string, TrailOne> TrailOnes = new Dictionary<string, TrailOne>();
        Dictionary<string, TrailTwo> TrailTwos = new Dictionary<string, TrailTwo>();

        TrailOne newTrailOne = new TrailOne();
        public TrailManagerForm()
        {
            // TODO: Parse words json file into words list 

            // TODO: temp fill of words list - Remove this when no longer needed
            TrailOnes.Add("item", new TrailOne() { Title = "item" });
            TrailTwos.Add("item", new TrailTwo() { Title = "item2" });

            InitializeComponent();

            // populate WordList in UI
            foreach (var word in TrailOnes.OrderBy(v => v.Key))
                trailOneList.Items.Add(word.Key);

            trailOneList.SelectedIndexChanged += (s, e) => 
            {
                var word = trailOneList.SelectedItem.ToString();
                pictureBox.ImageLocation = TrailOnes[word].ImagePath;
            };
        }


        private void ImageSelect_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    newTrailOne.ImagePath = fbd.FileName;
                }
                else
                    MessageBox.Show("Invalid file!", "Message");
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                MessageBox.Show("Insert word!", "Message");
                return;
            }
            if (string.IsNullOrWhiteSpace(translationBox.Text))
            {
                MessageBox.Show("Insert translation!", "Message");
                return;
            }

            if (phaseOneRadio.Checked)
            {
                if (newTrailOne.ImagePath == null)
                {
                    MessageBox.Show("Select an image!", "Message");
                    return;
                }
                newTrailOne.InitTrail(titleBox.Text, translationBox.Text);
                AddTrail(newTrailOne, TrailOnes, trailOneList);
            }
            else if (phaseTwoRadio.Checked)
            {
                var newTrailTwo = new TrailTwo();
                newTrailTwo.InitTrail(titleBox.Text, translationBox.Text);
                AddTrail(newTrailTwo, TrailTwos, trailTwoList);
            }
            MessageBox.Show("Trail was added successfully!", "Message");
            newTrailOne = new TrailOne();
            titleBox.Text = "";
            translationBox.Text = "";

        }

        private void AddTrail<T>(T trail, Dictionary<string, T> trailDic, ListBox trailList) where T : TrailBase
        {
            try
            {
                trailDic.Add(trail.Title, trail);

                // add new word and select it
                trailList.SelectedIndex = trailList.Items.Add(trail.Title);

                // TODO: Also add to sqlite3 db
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Word already exists!", "Message");

            }
        }


        private void phaseOneRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (phaseOneRadio.Checked)
                ImageSelect.Enabled = true;
        }

        private void phaseTwoRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (phaseTwoRadio.Checked)
                ImageSelect.Enabled = false;
        }
    }
}
