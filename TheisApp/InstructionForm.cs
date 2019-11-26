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
    public partial class InstructionForm : Form
    {
        private readonly List<string> m_instructionStrings;
        private int m_currentIndex = 0;
        public InstructionForm(List<string> instructionStrings)
        {
            InitializeComponent();
            CurrentInstructionLabel.AutoSize = false;
            CurrentInstructionLabel.Size = new Size(CurrentInstructionLabel.Size.Width, CurrentInstructionLabel.Size.Height * 6);
            CurrentInstructionLabel.Anchor = AnchorStyles.Right;
            m_instructionStrings = instructionStrings;
            if(m_instructionStrings.Count > 0)
                CurrentInstructionLabel.Text = m_instructionStrings[m_currentIndex];
            if(m_instructionStrings.Count > 1)
                ContinueBtn.Enabled = true;
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            if (m_currentIndex == m_instructionStrings.Count - 1)
            {
                this.Close();
                return;
            }
            if(m_currentIndex < m_instructionStrings.Count)
            {
                m_currentIndex++;
                CurrentInstructionLabel.Text = m_instructionStrings[m_currentIndex];
                BackBtn.Enabled = true;
            }
            if (m_currentIndex == m_instructionStrings.Count - 1)
                ContinueBtn.Text = "התחל שאלון";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (m_currentIndex > 0)
            {
                m_currentIndex--;
                CurrentInstructionLabel.Text = m_instructionStrings[m_currentIndex];
                ContinueBtn.Enabled = true;
            }
            if (m_currentIndex == 0)
                BackBtn.Enabled = false;
        }
    }
}
