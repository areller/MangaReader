namespace Reader
{
    partial class ReaderForm
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
            this.nameBox = new System.Windows.Forms.ComboBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.pageBox = new System.Windows.Forms.ComboBox();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.chapterBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.FormattingEnabled = true;
            this.nameBox.Location = new System.Drawing.Point(12, 378);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(351, 21);
            this.nameBox.TabIndex = 0;
            this.nameBox.SelectedIndexChanged += new System.EventHandler(this.nameBox_SelectedIndexChanged);
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(12, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(640, 360);
            this.imageBox.TabIndex = 1;
            this.imageBox.TabStop = false;
            // 
            // pageBox
            // 
            this.pageBox.FormattingEnabled = true;
            this.pageBox.Location = new System.Drawing.Point(446, 378);
            this.pageBox.Name = "pageBox";
            this.pageBox.Size = new System.Drawing.Size(71, 21);
            this.pageBox.TabIndex = 2;
            this.pageBox.SelectedIndexChanged += new System.EventHandler(this.pageBox_SelectedIndexChanged);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(523, 376);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(61, 23);
            this.prevButton.TabIndex = 3;
            this.prevButton.Text = "Prev";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(591, 376);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(61, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // chapterBox
            // 
            this.chapterBox.FormattingEnabled = true;
            this.chapterBox.Location = new System.Drawing.Point(369, 378);
            this.chapterBox.Name = "chapterBox";
            this.chapterBox.Size = new System.Drawing.Size(71, 21);
            this.chapterBox.TabIndex = 5;
            this.chapterBox.SelectedIndexChanged += new System.EventHandler(this.chapterBox_SelectedIndexChanged);
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 411);
            this.Controls.Add(this.chapterBox);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.pageBox);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.nameBox);
            this.Name = "ReaderForm";
            this.Text = "Reader";
            this.Load += new System.EventHandler(this.ReaderForm_Load);
            this.SizeChanged += new System.EventHandler(this.ReaderForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox nameBox;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ComboBox pageBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ComboBox chapterBox;
    }
}

