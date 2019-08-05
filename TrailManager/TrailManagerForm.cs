using DBModel;
using DBModel.Trail;
using DBModel.Utils;
using Microsoft.EntityFrameworkCore;
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

        string selectedImage = null;
        public TrailManagerForm()
        {
            // Parse words from sqlite into words dictionaries 
            using (var dataContext = new SampleDBContext())
            {
                TrailOnes = dataContext.TrailOnes.ToDictionary(k => k.InterfaceString(), v => v);
                TrailTwos = dataContext.TrailTwos.ToDictionary(k => k.InterfaceString(), v => v);
            }


            InitializeComponent();

            // populate WordList in UI
            foreach (var trail in TrailOnes.OrderBy(v => v.Key))
                trailOneList.Items.Add(trail.Key);
            foreach (var trail in TrailTwos.OrderBy(v => v.Key))
                trailTwoList.Items.Add(trail.Key);

            // Update image whenever a trail one is selected
            trailOneList.SelectedIndexChanged += (s, e) => 
            {
                var word = trailOneList.SelectedItem?.ToString();
                if(word != null)
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
                    selectedImage = fbd.FileName;
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
                if (selectedImage == null)
                {
                    MessageBox.Show("Select an image!", "Message");
                    return;
                }
                var newTrailOne = new TrailOne();
                newTrailOne.InitTrail(titleBox.Text, translationBox.Text);
                newTrailOne.ImagePath = selectedImage;
                using (var dataContext = new SampleDBContext())
                {
                    AddTrail(newTrailOne, TrailOnes, trailOneList, dataContext.TrailOnes);
                    dataContext.SaveChanges();
                }
            }
            else if (phaseTwoRadio.Checked)
            {
                var newTrailTwo = new TrailTwo();
                newTrailTwo.InitTrail(titleBox.Text, translationBox.Text);
                using (var dataContext = new SampleDBContext())
                {
                    AddTrail(newTrailTwo, TrailTwos, trailTwoList, dataContext.TrailTwos);
                    dataContext.SaveChanges();
                }
            }
            MessageBox.Show("Trail was added successfully!", "Message");
            selectedImage = null;
            titleBox.Text = "";
            translationBox.Text = "";

        }

        private void AddTrail<T>(T trail, Dictionary<string, T> trailDic, ListBox trailList, DbSet<T> dbSet) where T : TrailBase
        {
            try
            {
                trailDic.Add(trail.InterfaceString(), trail);

                // add new word and select it
                trailList.SelectedIndex = trailList.Items.Add(trail.InterfaceString());

                dbSet.Add(trail);
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

        private void rmvTrailTwo(object sender, EventArgs e)
        {
            var word = trailTwoList.SelectedItem?.ToString();
            if (word == null)
            {
                // log error
                return;
            }
            trailTwoList.Items.Remove(word);
            using (var dataContext = new SampleDBContext())
            {
                dataContext.TrailTwos.Remove(TrailTwos[word]);
                dataContext.SaveChanges();
            }
            TrailTwos.Remove(word);

        }

        private void rmvTrailOneBtn_Click(object sender, EventArgs e)
        {
            var word = trailOneList.SelectedItem?.ToString();
            if(word == null)
            {
                // log error
                return;
            }
            trailOneList.Items.Remove(word);
            using (var dataContext = new SampleDBContext())
            {
                dataContext.TrailOnes.Remove(TrailOnes[word]);
                dataContext.SaveChanges();
            }
            TrailOnes.Remove(word);
            pictureBox.ImageLocation = null;
        }
    }
}
