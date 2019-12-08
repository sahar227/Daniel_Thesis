namespace TheisApp
{
    partial class StageTwo
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
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.YesBtn = new System.Windows.Forms.Button();
            this.NoBtn = new System.Windows.Forms.Button();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.ReplaySoundBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(257, 107);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(35, 13);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "label1";
            // 
            // YesBtn
            // 
            this.YesBtn.Location = new System.Drawing.Point(189, 239);
            this.YesBtn.Name = "YesBtn";
            this.YesBtn.Size = new System.Drawing.Size(75, 23);
            this.YesBtn.TabIndex = 1;
            this.YesBtn.Text = "כן";
            this.YesBtn.UseVisualStyleBackColor = true;
            this.YesBtn.Click += new System.EventHandler(this.YesBtn_Click);
            // 
            // NoBtn
            // 
            this.NoBtn.Location = new System.Drawing.Point(319, 239);
            this.NoBtn.Name = "NoBtn";
            this.NoBtn.Size = new System.Drawing.Size(75, 23);
            this.NoBtn.TabIndex = 2;
            this.NoBtn.Text = "לא";
            this.NoBtn.UseVisualStyleBackColor = true;
            this.NoBtn.Click += new System.EventHandler(this.NoBtn_Click);
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.BackColor = System.Drawing.Color.Lime;
            this.feedbackLabel.Location = new System.Drawing.Point(257, 287);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(35, 13);
            this.feedbackLabel.TabIndex = 3;
            this.feedbackLabel.Text = "label1";
            this.feedbackLabel.Visible = false;
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Location = new System.Drawing.Point(250, 321);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(75, 23);
            this.ContinueBtn.TabIndex = 4;
            this.ContinueBtn.Text = "המשך";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Visible = false;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // ReplaySoundBtn
            // 
            this.ReplaySoundBtn.Location = new System.Drawing.Point(250, 166);
            this.ReplaySoundBtn.Name = "ReplaySoundBtn";
            this.ReplaySoundBtn.Size = new System.Drawing.Size(75, 23);
            this.ReplaySoundBtn.TabIndex = 5;
            this.ReplaySoundBtn.Text = "הקשב שוב";
            this.ReplaySoundBtn.UseVisualStyleBackColor = true;
            this.ReplaySoundBtn.Click += new System.EventHandler(this.ReplaySoundBtn_Click);
            // 
            // StageTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.ControlBox = false;
            this.Controls.Add(this.ReplaySoundBtn);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.NoBtn);
            this.Controls.Add(this.YesBtn);
            this.Controls.Add(this.QuestionLabel);
            this.Name = "StageTwo";
            this.Text = "StageTwo";
            this.Load += new System.EventHandler(this.StageTwo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button YesBtn;
        private System.Windows.Forms.Button NoBtn;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Button ReplaySoundBtn;
    }
}