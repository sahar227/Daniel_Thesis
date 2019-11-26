namespace TheisApp
{
    partial class InstructionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackBtn = new System.Windows.Forms.Button();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.CurrentInstructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Enabled = false;
            this.BackBtn.Location = new System.Drawing.Point(465, 326);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(120, 23);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "חזור";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Enabled = false;
            this.ContinueBtn.Location = new System.Drawing.Point(232, 326);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(126, 23);
            this.ContinueBtn.TabIndex = 1;
            this.ContinueBtn.Text = "המשך";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // CurrentInstructionLabel
            // 
            this.CurrentInstructionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CurrentInstructionLabel.AutoSize = true;
            this.CurrentInstructionLabel.Location = new System.Drawing.Point(109, 172);
            this.CurrentInstructionLabel.Name = "CurrentInstructionLabel";
            this.CurrentInstructionLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CurrentInstructionLabel.Size = new System.Drawing.Size(479, 13);
            this.CurrentInstructionLabel.TabIndex = 2;
            this.CurrentInstructionLabel.Text = "גגגגגגגגגגגגגגגגג---------------לא הוכנסו הוראות------------------------------לא " +
    "הוכנסו הוראות---------------";
            this.CurrentInstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.CurrentInstructionLabel);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.BackBtn);
            this.Name = "InstructionForm";
            this.Text = "InstructionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Label CurrentInstructionLabel;
    }
}