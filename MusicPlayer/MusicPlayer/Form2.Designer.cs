namespace MusicPlayer
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            closeButton = new PictureBox();
            saveButton = new PictureBox();
            selectPhoto = new PictureBox();
            nameTextBox = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectPhoto).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(4, 13);
            label1.Name = "label1";
            label1.Size = new Size(270, 50);
            label1.TabIndex = 0;
            label1.Text = "Create Playlist";
            // 
            // closeButton
            // 
            closeButton.Image = Resources.closeButton;
            closeButton.Location = new Point(521, 1);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(29, 29);
            closeButton.SizeMode = PictureBoxSizeMode.StretchImage;
            closeButton.TabIndex = 1;
            closeButton.TabStop = false;
            closeButton.Click += closeButton_Click;
            closeButton.MouseEnter += closeButton_MouseEnter;
            closeButton.MouseLeave += closeButton_MouseLeave;
            // 
            // saveButton
            // 
            saveButton.Image = Resources.saveButton;
            saveButton.Location = new Point(166, 342);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(214, 70);
            saveButton.SizeMode = PictureBoxSizeMode.StretchImage;
            saveButton.TabIndex = 2;
            saveButton.TabStop = false;
            saveButton.Click += saveButton_Click;
            saveButton.MouseEnter += saveButton_MouseEnter;
            saveButton.MouseLeave += saveButton_MouseLeave;
            // 
            // selectPhoto
            // 
            selectPhoto.BackColor = Color.FromArgb(40, 40, 40);
            selectPhoto.Image = Resources.musicPhoto;
            selectPhoto.Location = new Point(12, 78);
            selectPhoto.Name = "selectPhoto";
            selectPhoto.Size = new Size(252, 237);
            selectPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            selectPhoto.TabIndex = 3;
            selectPhoto.TabStop = false;
            selectPhoto.Click += selectPhoto_Click;
            selectPhoto.MouseEnter += selectPhoto_MouseEnter;
            selectPhoto.MouseLeave += selectPhoto_MouseLeave;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(62, 62, 62);
            nameTextBox.BorderStyle = BorderStyle.None;
            nameTextBox.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            nameTextBox.ForeColor = Color.White;
            nameTextBox.Location = new Point(3, 108);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(239, 39);
            nameTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(-5, 58);
            label2.Name = "label2";
            label2.Size = new Size(137, 47);
            label2.TabIndex = 5;
            label2.Text = "Name :";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nameTextBox);
            panel1.Location = new Point(283, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 237);
            panel1.TabIndex = 6;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 37, 37);
            ClientSize = new Size(551, 434);
            Controls.Add(panel1);
            Controls.Add(selectPhoto);
            Controls.Add(saveButton);
            Controls.Add(closeButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Play List";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)saveButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectPhoto).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox closeButton;
        private PictureBox saveButton;
        private PictureBox selectPhoto;
        private TextBox nameTextBox;
        private Label label2;
        private Panel panel1;
    }
}