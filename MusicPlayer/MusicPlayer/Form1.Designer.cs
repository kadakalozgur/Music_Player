namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            playlists = new Panel();
            playlist4 = new Panel();
            playlistName4 = new Label();
            playlistImage4 = new PictureBox();
            playlist3 = new Panel();
            playlistName3 = new Label();
            playlistImage3 = new PictureBox();
            playlist1 = new Panel();
            playlistName1 = new Label();
            playlistImage1 = new PictureBox();
            label1 = new Label();
            addplaylistbutton = new PictureBox();
            playlistContent = new Panel();
            label3 = new Label();
            label2 = new Label();
            controlpanel = new Panel();
            voiceBarBackground = new Panel();
            currentVoiceBar = new Panel();
            totalTimeLabel = new Label();
            currentTimeLabel = new Label();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            barBackground = new Panel();
            barProgress = new Panel();
            voiceIcon = new PictureBox();
            nextButton = new PictureBox();
            backButton = new PictureBox();
            controlButton = new PictureBox();
            musicNameLabel = new Label();
            musicIcon = new PictureBox();
            playlist2 = new Panel();
            playlistName2 = new Label();
            playlistImage2 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            playlists.SuspendLayout();
            playlist4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage4).BeginInit();
            playlist3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage3).BeginInit();
            playlist1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addplaylistbutton).BeginInit();
            playlistContent.SuspendLayout();
            controlpanel.SuspendLayout();
            voiceBarBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            barBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)voiceIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nextButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)controlButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)musicIcon).BeginInit();
            playlist2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage2).BeginInit();
            SuspendLayout();
            // 
            // playlists
            // 
            playlists.BackColor = Color.FromArgb(18, 18, 18);
            playlists.Controls.Add(playlist4);
            playlists.Controls.Add(playlist3);
            playlists.Controls.Add(playlist1);
            playlists.Controls.Add(label1);
            playlists.Controls.Add(addplaylistbutton);
            playlists.Location = new Point(12, 12);
            playlists.Name = "playlists";
            playlists.Size = new Size(232, 525);
            playlists.TabIndex = 0;
            // 
            // playlist4
            // 
            playlist4.Controls.Add(playlistName4);
            playlist4.Controls.Add(playlistImage4);
            playlist4.Location = new Point(0, 425);
            playlist4.Name = "playlist4";
            playlist4.Size = new Size(232, 100);
            playlist4.TabIndex = 5;
            // 
            // playlistName4
            // 
            playlistName4.AutoSize = true;
            playlistName4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            playlistName4.ForeColor = Color.White;
            playlistName4.Location = new Point(84, 38);
            playlistName4.Name = "playlistName4";
            playlistName4.Size = new Size(0, 20);
            playlistName4.TabIndex = 1;
            // 
            // playlistImage4
            // 
            playlistImage4.Location = new Point(12, 18);
            playlistImage4.Name = "playlistImage4";
            playlistImage4.Size = new Size(66, 62);
            playlistImage4.SizeMode = PictureBoxSizeMode.StretchImage;
            playlistImage4.TabIndex = 0;
            playlistImage4.TabStop = false;
            // 
            // playlist3
            // 
            playlist3.Controls.Add(playlistName3);
            playlist3.Controls.Add(playlistImage3);
            playlist3.Location = new Point(0, 305);
            playlist3.Name = "playlist3";
            playlist3.Size = new Size(232, 100);
            playlist3.TabIndex = 4;
            // 
            // playlistName3
            // 
            playlistName3.AutoSize = true;
            playlistName3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            playlistName3.ForeColor = Color.White;
            playlistName3.Location = new Point(84, 38);
            playlistName3.Name = "playlistName3";
            playlistName3.Size = new Size(0, 20);
            playlistName3.TabIndex = 1;
            // 
            // playlistImage3
            // 
            playlistImage3.Location = new Point(12, 18);
            playlistImage3.Name = "playlistImage3";
            playlistImage3.Size = new Size(66, 62);
            playlistImage3.SizeMode = PictureBoxSizeMode.StretchImage;
            playlistImage3.TabIndex = 0;
            playlistImage3.TabStop = false;
            // 
            // playlist1
            // 
            playlist1.BackColor = Color.FromArgb(18, 18, 18);
            playlist1.Controls.Add(playlistName1);
            playlist1.Controls.Add(playlistImage1);
            playlist1.Location = new Point(0, 71);
            playlist1.Name = "playlist1";
            playlist1.Size = new Size(232, 100);
            playlist1.TabIndex = 2;
            // 
            // playlistName1
            // 
            playlistName1.AutoSize = true;
            playlistName1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            playlistName1.ForeColor = Color.White;
            playlistName1.Location = new Point(84, 38);
            playlistName1.Name = "playlistName1";
            playlistName1.Size = new Size(0, 20);
            playlistName1.TabIndex = 1;
            // 
            // playlistImage1
            // 
            playlistImage1.Location = new Point(12, 18);
            playlistImage1.Name = "playlistImage1";
            playlistImage1.Size = new Size(66, 62);
            playlistImage1.SizeMode = PictureBoxSizeMode.StretchImage;
            playlistImage1.TabIndex = 0;
            playlistImage1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 1;
            label1.Text = "Your Libary";
            // 
            // addplaylistbutton
            // 
            addplaylistbutton.Image = Resources.addbutton;
            addplaylistbutton.Location = new Point(160, 14);
            addplaylistbutton.Name = "addplaylistbutton";
            addplaylistbutton.Size = new Size(40, 39);
            addplaylistbutton.SizeMode = PictureBoxSizeMode.StretchImage;
            addplaylistbutton.TabIndex = 0;
            addplaylistbutton.TabStop = false;
            addplaylistbutton.Click += addplaylistbutton_Click;
            addplaylistbutton.MouseEnter += addplaylistbutton_MouseEnter;
            addplaylistbutton.MouseLeave += addplaylistbutton_MouseLeave;
            // 
            // playlistContent
            // 
            playlistContent.BackColor = Color.FromArgb(18, 18, 18);
            playlistContent.Controls.Add(label3);
            playlistContent.Controls.Add(label2);
            playlistContent.Location = new Point(250, 12);
            playlistContent.Name = "playlistContent";
            playlistContent.Size = new Size(1095, 525);
            playlistContent.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.White;
            label3.Location = new Point(265, 265);
            label3.Name = "label3";
            label3.Size = new Size(569, 65);
            label3.TabIndex = 1;
            label3.Text = "Made By Özgür Kadakal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(386, 173);
            label2.Name = "label2";
            label2.Size = new Size(316, 86);
            label2.TabIndex = 0;
            label2.Text = "Welcome";
            // 
            // controlpanel
            // 
            controlpanel.Controls.Add(voiceBarBackground);
            controlpanel.Controls.Add(totalTimeLabel);
            controlpanel.Controls.Add(currentTimeLabel);
            controlpanel.Controls.Add(axWindowsMediaPlayer1);
            controlpanel.Controls.Add(barBackground);
            controlpanel.Controls.Add(voiceIcon);
            controlpanel.Controls.Add(nextButton);
            controlpanel.Controls.Add(backButton);
            controlpanel.Controls.Add(controlButton);
            controlpanel.Controls.Add(musicNameLabel);
            controlpanel.Controls.Add(musicIcon);
            controlpanel.Location = new Point(12, 543);
            controlpanel.Name = "controlpanel";
            controlpanel.Size = new Size(1333, 108);
            controlpanel.TabIndex = 2;
            // 
            // voiceBarBackground
            // 
            voiceBarBackground.BackColor = Color.FromArgb(77, 77, 77);
            voiceBarBackground.Controls.Add(currentVoiceBar);
            voiceBarBackground.Location = new Point(1175, 49);
            voiceBarBackground.Name = "voiceBarBackground";
            voiceBarBackground.Size = new Size(140, 10);
            voiceBarBackground.TabIndex = 11;
            voiceBarBackground.MouseClick += voiceBarBackground_MouseClick;
            voiceBarBackground.MouseEnter += voiceBarBackground_MouseEnter;
            voiceBarBackground.MouseLeave += voiceBarBackground_MouseLeave;
            // 
            // currentVoiceBar
            // 
            currentVoiceBar.BackColor = Color.FromArgb(30, 217, 97);
            currentVoiceBar.Location = new Point(0, 0);
            currentVoiceBar.Name = "currentVoiceBar";
            currentVoiceBar.Size = new Size(0, 10);
            currentVoiceBar.TabIndex = 12;
            currentVoiceBar.MouseClick += currentVoiceBar_MouseClick;
            currentVoiceBar.MouseEnter += currentVoiceBar_MouseEnter;
            currentVoiceBar.MouseLeave += currentVoiceBar_MouseLeave;
            // 
            // totalTimeLabel
            // 
            totalTimeLabel.AutoSize = true;
            totalTimeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            totalTimeLabel.ForeColor = Color.FromArgb(179, 179, 179);
            totalTimeLabel.Location = new Point(946, 70);
            totalTimeLabel.Name = "totalTimeLabel";
            totalTimeLabel.Size = new Size(0, 17);
            totalTimeLabel.TabIndex = 10;
            // 
            // currentTimeLabel
            // 
            currentTimeLabel.AutoSize = true;
            currentTimeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            currentTimeLabel.ForeColor = Color.FromArgb(179, 179, 179);
            currentTimeLabel.Location = new Point(408, 70);
            currentTimeLabel.Name = "currentTimeLabel";
            currentTimeLabel.Size = new Size(0, 17);
            currentTimeLabel.TabIndex = 9;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(819, 16);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(10, 10);
            axWindowsMediaPlayer1.TabIndex = 2;
            axWindowsMediaPlayer1.Visible = false;
            // 
            // barBackground
            // 
            barBackground.BackColor = Color.FromArgb(77, 77, 77);
            barBackground.Controls.Add(barProgress);
            barBackground.Location = new Point(444, 73);
            barBackground.Name = "barBackground";
            barBackground.Size = new Size(500, 13);
            barBackground.TabIndex = 8;
            barBackground.MouseClick += barBackground_MouseClick;
            barBackground.MouseEnter += barBackground_MouseEnter;
            barBackground.MouseLeave += barBackground_MouseLeave;
            // 
            // barProgress
            // 
            barProgress.BackColor = Color.FromArgb(30, 217, 97);
            barProgress.Location = new Point(0, 0);
            barProgress.Name = "barProgress";
            barProgress.Size = new Size(0, 13);
            barProgress.TabIndex = 9;
            barProgress.MouseClick += barProgress_MouseClick;
            barProgress.MouseEnter += barProgress_MouseEnter;
            barProgress.MouseLeave += barProgress_MouseLeave;
            // 
            // voiceIcon
            // 
            voiceIcon.Image = Resources.voiceIcon;
            voiceIcon.Location = new Point(1137, 38);
            voiceIcon.Name = "voiceIcon";
            voiceIcon.Size = new Size(32, 32);
            voiceIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            voiceIcon.TabIndex = 7;
            voiceIcon.TabStop = false;
            voiceIcon.Click += voiceIcon_Click;
            voiceIcon.MouseEnter += voiceIcon_MouseEnter;
            voiceIcon.MouseLeave += voiceIcon_MouseLeave;
            // 
            // nextButton
            // 
            nextButton.Image = Resources.next;
            nextButton.Location = new Point(740, 16);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(40, 40);
            nextButton.SizeMode = PictureBoxSizeMode.StretchImage;
            nextButton.TabIndex = 6;
            nextButton.TabStop = false;
            nextButton.Click += nextButton_Click;
            // 
            // backButton
            // 
            backButton.Image = Resources.back;
            backButton.Location = new Point(620, 16);
            backButton.Name = "backButton";
            backButton.Size = new Size(40, 40);
            backButton.SizeMode = PictureBoxSizeMode.StretchImage;
            backButton.TabIndex = 5;
            backButton.TabStop = false;
            backButton.Click += backButton_Click;
            // 
            // controlButton
            // 
            controlButton.Image = Resources.playButton;
            controlButton.Location = new Point(679, 15);
            controlButton.Name = "controlButton";
            controlButton.Size = new Size(40, 40);
            controlButton.SizeMode = PictureBoxSizeMode.StretchImage;
            controlButton.TabIndex = 4;
            controlButton.TabStop = false;
            controlButton.Click += controlButton_Click;
            // 
            // musicNameLabel
            // 
            musicNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            musicNameLabel.ForeColor = Color.White;
            musicNameLabel.Location = new Point(95, 38);
            musicNameLabel.Name = "musicNameLabel";
            musicNameLabel.Size = new Size(240, 23);
            musicNameLabel.TabIndex = 3;
            // 
            // musicIcon
            // 
            musicIcon.Image = Resources.musicIcon;
            musicIcon.Location = new Point(12, 16);
            musicIcon.Name = "musicIcon";
            musicIcon.Size = new Size(77, 74);
            musicIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            musicIcon.TabIndex = 2;
            musicIcon.TabStop = false;
            // 
            // playlist2
            // 
            playlist2.BackColor = Color.FromArgb(18, 18, 18);
            playlist2.Controls.Add(playlistName2);
            playlist2.Controls.Add(playlistImage2);
            playlist2.Location = new Point(12, 200);
            playlist2.Name = "playlist2";
            playlist2.Size = new Size(232, 100);
            playlist2.TabIndex = 3;
            // 
            // playlistName2
            // 
            playlistName2.AutoSize = true;
            playlistName2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            playlistName2.ForeColor = Color.White;
            playlistName2.Location = new Point(84, 38);
            playlistName2.Name = "playlistName2";
            playlistName2.Size = new Size(0, 20);
            playlistName2.TabIndex = 1;
            // 
            // playlistImage2
            // 
            playlistImage2.Location = new Point(12, 18);
            playlistImage2.Name = "playlistImage2";
            playlistImage2.Size = new Size(66, 62);
            playlistImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            playlistImage2.TabIndex = 0;
            playlistImage2.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1357, 663);
            Controls.Add(playlist2);
            Controls.Add(controlpanel);
            Controls.Add(playlistContent);
            Controls.Add(playlists);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            playlists.ResumeLayout(false);
            playlists.PerformLayout();
            playlist4.ResumeLayout(false);
            playlist4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage4).EndInit();
            playlist3.ResumeLayout(false);
            playlist3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage3).EndInit();
            playlist1.ResumeLayout(false);
            playlist1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage1).EndInit();
            ((System.ComponentModel.ISupportInitialize)addplaylistbutton).EndInit();
            playlistContent.ResumeLayout(false);
            playlistContent.PerformLayout();
            controlpanel.ResumeLayout(false);
            controlpanel.PerformLayout();
            voiceBarBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            barBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)voiceIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nextButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)backButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)controlButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)musicIcon).EndInit();
            playlist2.ResumeLayout(false);
            playlist2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playlistImage2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel playlists;
        private Panel playlistContent;
        private Panel controlpanel;
        private Label label1;
        private PictureBox addplaylistbutton;
        private Panel playlist1;
        private Panel playlist4;
        private Label playlistName4;
        private PictureBox playlistImage4;
        private Panel playlist3;
        private Label playlistName3;
        private PictureBox playlistImage3;
        private Label playlistName1;
        private PictureBox playlistImage1;
        private Panel playlist2;
        private Label playlistName2;
        private PictureBox playlistImage2;
        private Label label3;
        private PictureBox musicIcon;
        private Label musicNameLabel;
        private PictureBox nextButton;
        private PictureBox backButton;
        private PictureBox controlButton;
        private PictureBox voiceIcon;
        private Panel barBackground;
        private Panel barProgress;
        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Label totalTimeLabel;
        private Label currentTimeLabel;
        private Label label2;
        private Panel voiceBarBackground;
        private Panel currentVoiceBar;
    }
}
