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
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(274, 109);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(35, 13);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "label1";
            // 
            // YesBtn
            // 
            this.YesBtn.Location = new System.Drawing.Point(190, 263);
            this.YesBtn.Name = "YesBtn";
            this.YesBtn.Size = new System.Drawing.Size(75, 23);
            this.YesBtn.TabIndex = 1;
            this.YesBtn.Text = "כן";
            this.YesBtn.UseVisualStyleBackColor = true;
            this.YesBtn.Click += new System.EventHandler(this.YesBtn_Click);
            // 
            // NoBtn
            // 
            this.NoBtn.Location = new System.Drawing.Point(320, 263);
            this.NoBtn.Name = "NoBtn";
            this.NoBtn.Size = new System.Drawing.Size(75, 23);
            this.NoBtn.TabIndex = 2;
            this.NoBtn.Text = "לא";
            this.NoBtn.UseVisualStyleBackColor = true;
            this.NoBtn.Click += new System.EventHandler(this.NoBtn_Click);
            // 
            // StageTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.ControlBox = false;
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
    }
}