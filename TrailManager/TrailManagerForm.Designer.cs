namespace ThesisProject
{
    partial class TrailManagerForm
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
            this.trailOneList = new System.Windows.Forms.ListBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.ImageSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rmvTrailOneBtn = new System.Windows.Forms.Button();
            this.rmvTrailTwoBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.trailTwoList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.translationBox = new System.Windows.Forms.TextBox();
            this.phaseOneRadio = new System.Windows.Forms.RadioButton();
            this.phaseTwoRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trailOneList
            // 
            this.trailOneList.FormattingEnabled = true;
            this.trailOneList.ItemHeight = 16;
            this.trailOneList.Location = new System.Drawing.Point(325, 53);
            this.trailOneList.Name = "trailOneList";
            this.trailOneList.Size = new System.Drawing.Size(186, 244);
            this.trailOneList.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(325, 352);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(181, 117);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "השמע";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(309, 578);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(116, 22);
            this.titleBox.TabIndex = 3;
            // 
            // ImageSelect
            // 
            this.ImageSelect.Location = new System.Drawing.Point(22, 558);
            this.ImageSelect.Name = "ImageSelect";
            this.ImageSelect.Size = new System.Drawing.Size(125, 42);
            this.ImageSelect.TabIndex = 4;
            this.ImageSelect.Text = "תמונה";
            this.ImageSelect.UseVisualStyleBackColor = true;
            this.ImageSelect.Click += new System.EventHandler(this.ImageSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 558);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "מילה";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "הוספת טרייל חדש";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.BackColor = System.Drawing.Color.Lime;
            this.ConfirmBtn.Location = new System.Drawing.Point(196, 622);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 34);
            this.ConfirmBtn.TabIndex = 8;
            this.ConfirmBtn.Text = "הוספה";
            this.ConfirmBtn.UseVisualStyleBackColor = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "מילים של שלב 1";
            // 
            // rmvTrailOneBtn
            // 
            this.rmvTrailOneBtn.Location = new System.Drawing.Point(325, 303);
            this.rmvTrailOneBtn.Name = "rmvTrailOneBtn";
            this.rmvTrailOneBtn.Size = new System.Drawing.Size(90, 43);
            this.rmvTrailOneBtn.TabIndex = 10;
            this.rmvTrailOneBtn.Text = "הסר";
            this.rmvTrailOneBtn.UseVisualStyleBackColor = true;
            this.rmvTrailOneBtn.Click += new System.EventHandler(this.rmvTrailOneBtn_Click);
            // 
            // rmvTrailTwoBtn
            // 
            this.rmvTrailTwoBtn.Location = new System.Drawing.Point(33, 303);
            this.rmvTrailTwoBtn.Name = "rmvTrailTwoBtn";
            this.rmvTrailTwoBtn.Size = new System.Drawing.Size(90, 43);
            this.rmvTrailTwoBtn.TabIndex = 14;
            this.rmvTrailTwoBtn.Text = "הסר";
            this.rmvTrailTwoBtn.UseVisualStyleBackColor = true;
            this.rmvTrailTwoBtn.Click += new System.EventHandler(this.rmvTrailTwo);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "מילים של שלב 2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(129, 303);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 43);
            this.button4.TabIndex = 12;
            this.button4.Text = "השמע";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // trailTwoList
            // 
            this.trailTwoList.FormattingEnabled = true;
            this.trailTwoList.ItemHeight = 16;
            this.trailTwoList.Location = new System.Drawing.Point(33, 53);
            this.trailTwoList.Name = "trailTwoList";
            this.trailTwoList.Size = new System.Drawing.Size(186, 244);
            this.trailTwoList.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "תרגום";
            // 
            // translationBox
            // 
            this.translationBox.Location = new System.Drawing.Point(177, 578);
            this.translationBox.Name = "translationBox";
            this.translationBox.Size = new System.Drawing.Size(116, 22);
            this.translationBox.TabIndex = 15;
            // 
            // phaseOneRadio
            // 
            this.phaseOneRadio.AutoSize = true;
            this.phaseOneRadio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.phaseOneRadio.Checked = true;
            this.phaseOneRadio.Location = new System.Drawing.Point(449, 554);
            this.phaseOneRadio.Name = "phaseOneRadio";
            this.phaseOneRadio.Size = new System.Drawing.Size(65, 21);
            this.phaseOneRadio.TabIndex = 17;
            this.phaseOneRadio.TabStop = true;
            this.phaseOneRadio.Text = "שלב 1";
            this.phaseOneRadio.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.phaseOneRadio.UseVisualStyleBackColor = true;
            this.phaseOneRadio.CheckedChanged += new System.EventHandler(this.phaseOneRadio_CheckedChanged);
            // 
            // phaseTwoRadio
            // 
            this.phaseTwoRadio.AutoSize = true;
            this.phaseTwoRadio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.phaseTwoRadio.Location = new System.Drawing.Point(449, 581);
            this.phaseTwoRadio.Name = "phaseTwoRadio";
            this.phaseTwoRadio.Size = new System.Drawing.Size(65, 21);
            this.phaseTwoRadio.TabIndex = 18;
            this.phaseTwoRadio.Text = "שלב 2";
            this.phaseTwoRadio.UseVisualStyleBackColor = true;
            this.phaseTwoRadio.CheckedChanged += new System.EventHandler(this.phaseTwoRadio_CheckedChanged);
            // 
            // TrailManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 678);
            this.Controls.Add(this.phaseTwoRadio);
            this.Controls.Add(this.phaseOneRadio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.translationBox);
            this.Controls.Add(this.rmvTrailTwoBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.trailTwoList);
            this.Controls.Add(this.rmvTrailOneBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImageSelect);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.trailOneList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TrailManagerForm";
            this.Text = "WordManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox trailOneList;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button ImageSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button rmvTrailOneBtn;
        private System.Windows.Forms.Button rmvTrailTwoBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox trailTwoList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox translationBox;
        private System.Windows.Forms.RadioButton phaseOneRadio;
        private System.Windows.Forms.RadioButton phaseTwoRadio;
    }
}