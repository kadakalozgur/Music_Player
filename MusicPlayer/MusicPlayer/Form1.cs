
/* This is the home page of the app. */
/* Bu uygulamanýn ana sayfasýdýr. */

using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MusicPlayer
{

    public partial class Form1 : Form
    {

        private List<Panel> playlistPanels;
        private List<Label> playlistLabels;
        private List<PictureBox> playlistPictures;
        private List<List<string>> playlistMusics;
        private List<string> playlistImagePaths;

        private string appFolder;
        private string musicFolder;

        private bool isMusicPlay = false;
        private bool isDraggingVolume = false;
        private bool isMuted = false;

        public int numberOfPlaylists = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            playlistPanels = new List<Panel> { playlist1, playlist2, playlist3, playlist4 };
            playlistLabels = new List<Label> { playlistName1, playlistName2, playlistName3, playlistName4 };
            playlistPictures = new List<PictureBox> { playlistImage1, playlistImage2, playlistImage3, playlistImage4 };
            playlistMusics = new List<List<string>> { new List<string>(), new List<string>(), new List<string>(), new List<string>() };
            playlistImagePaths = new List<string> { "", "", "", "" };

            /* The for loops in this section allow the delete menu to open when we right-click on each element in the panel. */
            /* Bu bölümdeki for döngüleri paneldeki her bir elemana sað týkladýðýmýzda silme menüsünün açýlmasýný saðlar. */

            for (int i = 0; i < playlistPanels.Count; i++)
                playlistPanels[i].MouseClick += deletePlaylist;

            for (int i = 0; i < playlistPictures.Count; i++)
            {

                var picture = playlistPictures[i];
                picture.MouseClick += (s, e) => deletePlaylist(picture.Parent, e);

            }

            for (int i = 0; i < playlistLabels.Count; i++)
            {

                var label = playlistLabels[i];
                label.MouseClick += (s, e) => deletePlaylist(label.Parent, e);

            }

            /* In this section, an event is written that will open the contents of the playlists when clicked. */
            /* Bu bölümde, týklandýðýnda çalma listelerinin içeriklerinin açýlmasýný saðlayacak bir event yazýlýr. */

            for (int i = 0; i < playlistPanels.Count; i++)
            {

                int index = i;

                playlistPanels[i].Click += (s, e) => openPlaylist(index);

                playlistLabels[i].Click += (s, e) => openPlaylist(index);

                playlistPictures[i].Click += (s, e) => openPlaylist(index);

            }

            /* Hover effect for playlists. */
            /* Çalma listeleri için gezinme efekti. */

            hoverEffect();

            hoverEffectControlsButton(controlButton);
            hoverEffectControlsButton(nextButton);
            hoverEffectControlsButton(backButton);

            /* We create a special folder in the documents folder to save data. */
            /* Verileri kaydetmek için belgeler klasöründe özel bir klasör oluþturuyoruz. */

            string documentsFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            appFolder = Path.Combine(documentsFile, "Music Player");
            musicFolder = Path.Combine(appFolder, "MusicFiles");

            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            if (!Directory.Exists(musicFolder))
                Directory.CreateDirectory(musicFolder);

            loadPlaylists();

            /* Set a default sound and updated the soundbar */
            /* Varsayýlan bir ses ayarladým ve ses çubuðunu güncelledim. */

            axWindowsMediaPlayer1.settings.volume = 50;

            updateVolume();

            voiceBarBackground.SizeChanged += (s, e) => updateVolume();

            /* Automatically skips to the next song when the song ends. */
            /* Þarký bittiðinde otomatik olarak bir sonraki þarkýya atlama. */

            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

        }

        /* We store data with file operations. */
        /* Verileri dosya iþlemleriyle saklýyoruz. */

        private void savePlaylists()
        {
            string playlistFile = Path.Combine(appFolder, "playlists.txt");

            string musicFile = Path.Combine(appFolder, "musics.txt");

            using (StreamWriter writer = new StreamWriter(playlistFile))
            {

                for (int i = 0; i < playlistLabels.Count; i++)
                {

                    string name = playlistLabels[i].Text;
                    string imagePath = "default";

                    if (!string.IsNullOrEmpty(playlistImagePaths[i]) && playlistImagePaths[i] != "default")
                    {
                        imagePath = playlistImagePaths[i];
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        writer.WriteLine($"{name}|{imagePath}");
                    }
                    else
                    {
                        writer.WriteLine("empty|empty");
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(musicFile))
            {
                for (int i = 0; i < playlistMusics.Count; i++)
                {
                    if (playlistMusics[i] != null && playlistMusics[i].Count > 0)
                    {

                        writer.WriteLine($"Playlist{i}:" + string.Join(";", playlistMusics[i]));

                    }

                    else
                    {

                        writer.WriteLine($"Playlist{i}:");

                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            savePlaylists();

        }

        private void loadPlaylists()
        {
            string playlistFile = Path.Combine(appFolder, "playlists.txt");
            string musicFile = Path.Combine(appFolder, "musics.txt");

            if (File.Exists(playlistFile))
            {
                string[] lines = File.ReadAllLines(playlistFile);

                numberOfPlaylists = 0;

                for (int i = 0; i < playlistLabels.Count; i++)
                {
                    if (i < lines.Length)
                    {
                        string[] parts = lines[i].Split('|');

                        if (parts[0] != "empty")
                        {
                            playlistLabels[i].Text = parts[0];

                            if (parts[1] == "default" || !File.Exists(parts[1]))
                            {
                                playlistPictures[i].Image = Resources.musicPhoto;
                                playlistImagePaths[i] = "default";
                            }
                            else
                            {
                                playlistPictures[i].Image = Image.FromFile(parts[1]);
                                playlistImagePaths[i] = parts[1];
                            }

                            numberOfPlaylists++;
                        }
                        else
                        {
                            playlistLabels[i].Text = "";
                            playlistPictures[i].Image = null;
                            playlistImagePaths[i] = "";
                        }
                    }
                }
            }

            if (File.Exists(musicFile))
            {
                string[] lines = File.ReadAllLines(musicFile);

                for (int i = 0; i < 4; i++)
                {

                    playlistMusics[i] = new List<string>();

                }

                foreach (string line in lines)
                {
                    if (line.Contains(":"))
                    {
                        string[] parts = line.Split(new char[] { ':' }, 2);

                        if (parts[0].StartsWith("Playlist"))
                        {
                            string indexStr = parts[0].Substring(8);

                            if (int.TryParse(indexStr, out int playlistIndex) && playlistIndex >= 0 && playlistIndex < 4)
                            {
                                if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
                                {

                                    string[] musics = parts[1].Split(';');

                                    foreach (string music in musics)
                                    {

                                        if (!string.IsNullOrEmpty(music.Trim()))
                                        {

                                            playlistMusics[playlistIndex].Add(music.Trim());

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /* In this section, a hover effect has been created for the add playlist button. */
        /* Bu bölümde çalma listesi ekle butonu için bir gezinme efekti oluþturuldu. */

        private void addplaylistbutton_MouseEnter(object sender, EventArgs e)
        {

            addplaylistbutton.Image = Resources.addhoverbutton;
            addplaylistbutton.Cursor = Cursors.Hand;

        }

        private void addplaylistbutton_MouseLeave(object sender, EventArgs e)
        {

            addplaylistbutton.Image = Resources.addbutton;
            addplaylistbutton.Cursor = Cursors.Default;

        }

        /* In this section, the menu for adding a new playlist opens. */
        /* Bu bölümde yeni çalma listesi ekleme menüsü açýlýr. */

        private void addplaylistbutton_Click(object sender, EventArgs e)
        {

            if (numberOfPlaylists >= 4)
            {

                MessageBox.Show("Up To 4 Playlists Can Be Created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            /* We added elements to this restriction list and made the default photo a picture if the user did not enter a photo. */
            /* Bu kýsýtlama listesine öðeler ekledik ve kullanýcý fotoðraf girmediyse varsayýlan fotoðrafý resim yaptýk. */

            using (Form2 addPlaylistForm = new Form2())
            {
                if (addPlaylistForm.ShowDialog() == DialogResult.OK)
                {

                    string playlistName = addPlaylistForm.playListName;
                    Image playlistImage = addPlaylistForm.selectedImage ?? Resources.musicPhoto;

                    for (int i = 0; i < playlistPanels.Count; i++)
                    {
                        if (string.IsNullOrEmpty(playlistLabels[i].Text))
                        {
                            playlistLabels[i].Text = playlistName;
                            playlistPictures[i].Image = playlistImage;


                            if (playlistImage != Resources.musicPhoto)
                            {

                                string destinationPath = Path.Combine(appFolder, $"playlist_{i}.png");

                                if (addPlaylistForm.GetType().GetProperty("selectedImagePath") != null)
                                {

                                    string sourcePath = (string)addPlaylistForm.GetType().GetProperty("selectedImagePath").GetValue(addPlaylistForm);

                                    if (!string.IsNullOrEmpty(sourcePath) && File.Exists(sourcePath))
                                    {

                                        File.Copy(sourcePath, destinationPath, true);

                                    }

                                    else
                                    {

                                        playlistImage.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Png);

                                    }
                                }

                                else
                                {
                                    playlistImage.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Png);

                                }

                                playlistImagePaths[i] = destinationPath;
                            }

                            else
                            {

                                playlistImagePaths[i] = "default";

                            }

                            numberOfPlaylists++;

                            break;
                        }
                    }
                }
            }
        }

        private void deletePlaylist(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Right)
                return;

            int indexPlaylist = playlistPanels.IndexOf((Panel)sender);

            if (indexPlaylist == -1 || string.IsNullOrEmpty(playlistLabels[indexPlaylist].Text))
                return;

            if (playlistMusics[indexPlaylist].Contains(axWindowsMediaPlayer1.URL))
            {
                MessageBox.Show("Cannot delete a playlist while one of its songs is playing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            if (MessageBox.Show("Are you sure you want to delete the playlist?", "Delete Playlist", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                playlistContent.Controls.Clear();

                if (playlistMusics[indexPlaylist] != null)
                {

                    foreach (string musicPath in playlistMusics[indexPlaylist])
                    {
                        if (File.Exists(musicPath))
                        {

                            File.Delete(musicPath);

                        }
                    }
                }

                if(!string.IsNullOrEmpty(playlistImagePaths[indexPlaylist]) && playlistImagePaths[indexPlaylist] != "default" && File.Exists(playlistImagePaths[indexPlaylist]))
                {

                    try
                    {
                        if (playlistPictures[indexPlaylist].Image != null)
                        {

                            playlistPictures[indexPlaylist].Image.Dispose();

                            playlistPictures[indexPlaylist].Image = null;

                        }

                        GC.Collect();

                        GC.WaitForPendingFinalizers();

                        System.Threading.Thread.Sleep(100);

                        File.Delete(playlistImagePaths[indexPlaylist]);
                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show($"There was a problem deleting the image file: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }

                /* Listeyi kaydýrma iþlemi */

                for (int i = indexPlaylist; i < 3; i++)
                {

                    playlistLabels[i].Text = playlistLabels[i + 1].Text;
                    playlistPictures[i].Image = playlistPictures[i + 1].Image;
                    playlistImagePaths[i] = playlistImagePaths[i + 1];
                    playlistMusics[i] = playlistMusics[i + 1];

                }

                playlistLabels[3].Text = "";
                playlistImagePaths[3] = "";
                playlistPictures[3].Image = null;
                playlistMusics[3] = new List<string>();

                numberOfPlaylists--;

                savePlaylists();

            }
        }

        /* This section contains functions that display the contents of playlists. */
        /* Bu bölüm, çalma listelerinin içeriklerini görüntüleyen fonksiyonlarý içerir. */

        private void openPlaylist(int index)
        {

            if (string.IsNullOrEmpty(playlistLabels[index].Text))
                return;

            showPlaylists(index);

        }

        private void showPlaylists(int index)
        {

            playlistContent.Controls.Clear();

            /* Playlist Picture */
            /* Playlist Fotoðrafý */

            PictureBox picturePlaylist = new PictureBox();
            picturePlaylist.Image = playlistPictures[index].Image;
            picturePlaylist.SizeMode = PictureBoxSizeMode.StretchImage;
            picturePlaylist.Size = new Size(250, 250);
            picturePlaylist.Location = new Point(20, 20);

            playlistContent.Controls.Add(picturePlaylist);

            /* Playlist Name */
            /* Playlist Adý */

            Label namePlaylist = new Label();
            namePlaylist.Text = playlistLabels[index].Text;
            namePlaylist.Font = new Font("Arial", 60, FontStyle.Bold);
            namePlaylist.ForeColor = Color.White;
            namePlaylist.AutoSize = true;
            namePlaylist.Location = new Point(picturePlaylist.Right + 10, picturePlaylist.Top + 65);

            playlistContent.Controls.Add(namePlaylist);

            /* Add Music Button */
            /* Müzik Ekleme Butonu */

            PictureBox addMusicButton = new PictureBox();
            addMusicButton.Image = Resources.addMusicButton;
            addMusicButton.SizeMode = PictureBoxSizeMode.StretchImage;
            addMusicButton.Size = new Size(250, 70);
            addMusicButton.Location = new Point(picturePlaylist.Left, picturePlaylist.Bottom + 20);

            addMusicButton.MouseEnter += (s, e) =>
            {

                addMusicButton.Image = Resources.addMusicButtonHover;
                addMusicButton.Cursor = Cursors.Hand;

            };

            addMusicButton.MouseLeave += (s, e) =>
            {

                addMusicButton.Image = Resources.addMusicButton;
                addMusicButton.Cursor = Cursors.Default;

            };

            addMusicButton.Click += (s, e) =>
            {

                addMusic(index);

            };

            playlistContent.Controls.Add(addMusicButton);

            if (playlistMusics[index] != null)
            {

                for (int i = 0; i < playlistMusics[index].Count; i++)
                {
                    string musicPath = playlistMusics[index][i];
                    string musicName = Path.GetFileNameWithoutExtension(musicPath);

                    if (musicName.Contains("_playlist") && musicName.Contains("_"))
                    {

                        int playlistIndex = musicName.IndexOf("_playlist");

                        musicName = musicName.Substring(0, playlistIndex);
                    }

                    addMusicToPlaylistDisplay(index, musicName, musicPath, i + 1);
                }
            }

            playlistContent.AutoScroll = true;

        }

        /* Add music to playlist. */
        /* Çalma listesine müzik ekleme */

        private void addMusic(int index)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Music File";
                openFileDialog.Filter = "MP3 Files|*.mp3";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;
                    string originalMusicName = Path.GetFileNameWithoutExtension(sourcePath); 

                    if (string.IsNullOrEmpty(originalMusicName))
                    {

                        MessageBox.Show("Selected music file has no name. Please choose a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if (isMusicAlreadyExists(sourcePath, index))
                    {

                        MessageBox.Show("The song with the same name cannot be re-uploaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    }
                    
                    string fileExtension = Path.GetExtension(sourcePath);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string uniqueFileName = $"{originalMusicName}_playlist{index}_{timestamp}{fileExtension}";
                    string destinationPath = Path.Combine(musicFolder, uniqueFileName);
                   
                    File.Copy(sourcePath, destinationPath, true);

                    playlistMusics[index].Add(destinationPath);

                    addMusicToPlaylistDisplay(index, originalMusicName, destinationPath, playlistMusics[index].Count);

                    savePlaylists();

                    showPlaylists(index);

                    MessageBox.Show("Music Added Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addMusicToPlaylistDisplay(int playlistIndex, string musicName, string musicPath, int musicNumber)
        {

            Panel musicPanel = new Panel();
            musicPanel.Size = new Size(1050, 50);
            musicPanel.BackColor = Color.FromArgb(18, 18, 18);
            musicPanel.Location = new Point(20, 400 + (musicNumber - 1) * 55);

            Label numberLabel = new Label();
            numberLabel.Text = musicNumber.ToString();
            numberLabel.Font = new Font("Arial", 12, FontStyle.Regular);
            numberLabel.ForeColor = Color.Gray;
            numberLabel.AutoSize = true;
            numberLabel.Location = new Point(10, 15);

            Label musicNameLabel = new Label();
            musicNameLabel.Text = musicName;
            musicNameLabel.Font = new Font("Arial", 12, FontStyle.Regular);
            musicNameLabel.ForeColor = Color.White;
            musicNameLabel.AutoSize = true;
            musicNameLabel.Location = new Point(50, 15);
            musicNameLabel.MaximumSize = new Size(700, 0);

            Label deleteButton = new Label();
            deleteButton.Text = "X";
            deleteButton.Font = new Font("Arial", 12, FontStyle.Bold);
            deleteButton.ForeColor = Color.Gray;
            deleteButton.AutoSize = true;
            deleteButton.Location = new Point(1000, 15);
            deleteButton.Cursor = Cursors.Hand;

            deleteButton.MouseEnter += (s, e) =>
            {

                deleteButton.ForeColor = Color.Red;

            };

            deleteButton.MouseLeave += (s, e) =>
            {

                deleteButton.ForeColor = Color.Gray;

            };

            deleteButton.Click += (s, e) =>
            {

                if (musicPath == axWindowsMediaPlayer1.URL)
                {
                    MessageBox.Show("Cannot delete the currently playing song", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }

                if (MessageBox.Show("Are you sure you want to remove this music?", "Delete Music", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int musicIndex = musicNumber - 1;

                    if (File.Exists(playlistMusics[playlistIndex][musicIndex]))
                    {

                        File.Delete(playlistMusics[playlistIndex][musicIndex]);

                    }

                    playlistMusics[playlistIndex].RemoveAt(musicIndex);

                    showPlaylists(playlistIndex);

                    savePlaylists();
                }
            };

            musicPanel.MouseEnter += (s, e) =>
            {
                if (musicPath != axWindowsMediaPlayer1.URL)
                {

                    musicPanel.BackColor = Color.FromArgb(40, 40, 40);
                    musicPanel.Cursor = Cursors.Hand;

                }
            };

            musicPanel.MouseLeave += (s, e) =>
            {
                if (musicPath != axWindowsMediaPlayer1.URL)
                {

                    musicPanel.BackColor = Color.FromArgb(18, 18, 18);
                    musicPanel.Cursor = Cursors.Default;

                }                
            };

            musicNameLabel.MouseEnter += (s, e) =>
            {
                if (musicPath != axWindowsMediaPlayer1.URL)
                {

                    musicPanel.BackColor = Color.FromArgb(40, 40, 40);
                    musicPanel.Cursor = Cursors.Hand;

                }
            };

            musicNameLabel.MouseLeave += (s, e) =>
            {
                if (musicPath != axWindowsMediaPlayer1.URL)
                {

                    musicPanel.BackColor = Color.FromArgb(18, 18, 18);
                    musicPanel.Cursor = Cursors.Default;

                }
            };

            numberLabel.MouseEnter += (s, e) =>
            {
                if (musicPath != axWindowsMediaPlayer1.URL)
                {

                    musicPanel.BackColor = Color.FromArgb(40, 40, 40);
                    musicPanel.Cursor = Cursors.Hand;

                }
            };

            numberLabel.MouseLeave += (s, e) =>
            {
                if (musicPath != axWindowsMediaPlayer1.URL)
                {

                    musicPanel.BackColor = Color.FromArgb(18, 18, 18);
                    musicPanel.Cursor = Cursors.Default;

                }
            };

            musicPanel.DoubleClick += (s, e) => playMusic(musicPath, musicName);
            musicNameLabel.DoubleClick += (s, e) => playMusic(musicPath, musicName);

            musicPanel.Controls.Add(numberLabel);
            musicPanel.Controls.Add(musicNameLabel);
            musicPanel.Controls.Add(deleteButton);

            playlistContent.Controls.Add(musicPanel);

        }

        /* Control adding music with the same name. */
        /* Ayný isimde müzik ekleme kontrolü. */

        private bool isMusicAlreadyExists(string originalPath, int playlistIndex)
        {
            string originalName = Path.GetFileNameWithoutExtension(originalPath);

            if (playlistMusics[playlistIndex] != null)
            {

                foreach (string existingPath in playlistMusics[playlistIndex])
                {

                    string existingName = Path.GetFileNameWithoutExtension(existingPath);
                  
                    if (existingName.Contains("_playlist") && existingName.Contains("_"))
                    {

                        int playlistIdx = existingName.IndexOf("_playlist");

                        existingName = existingName.Substring(0, playlistIdx);
                    }

                    if (existingName.Equals(originalName, StringComparison.OrdinalIgnoreCase))
                    {

                        return true;

                    }
                }
            }

            return false;
        }

        /* Hover effect for playlists. */
        /* Çalma listeleri için gezinme efekti. */

        private void hoverEffect()
        {

            for (int i = 0; i < playlistPanels.Count; i++)
            {

                playlistPanels[i].MouseEnter += Panel_MouseEnter;
                playlistPanels[i].MouseLeave += Panel_MouseLeave;

                playlistPictures[i].MouseEnter += (s, e) =>
                {

                    PictureBox picture = s as PictureBox;
                    Panel_MouseEnter(picture.Parent, e);

                };

                playlistPictures[i].MouseLeave += (s, e) =>
                {

                    PictureBox picture = s as PictureBox;
                    Panel_MouseLeave(picture.Parent, e);

                };

                playlistLabels[i].MouseEnter += (s, e) =>
                {

                    Label label = s as Label;
                    Panel_MouseEnter(label.Parent, e);

                };

                playlistLabels[i].MouseLeave += (s, e) =>
                {

                    Label label = s as Label;
                    Panel_MouseLeave(label.Parent, e);

                };
            }
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel != null)
            {
                int panelIndex = playlistPanels.IndexOf(panel);

                if (panelIndex != -1 && !string.IsNullOrEmpty(playlistLabels[panelIndex].Text))
                {

                    panel.BackColor = Color.FromArgb(64, 64, 64);
                    panel.Cursor = Cursors.Hand;

                }
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel != null)
            {
                int panelIndex = playlistPanels.IndexOf(panel);

                if (panelIndex != -1 && !string.IsNullOrEmpty(playlistLabels[panelIndex].Text))
                {

                    panel.BackColor = Color.FromArgb(18, 18, 18);
                    panel.Cursor = Cursors.Default;

                }
            }
        }

        /* Control Buttons Hover Effects */
        /* Kontrol Butonlarý Ýçn Hover Efekteri */

        private void hoverEffectControlsButton(PictureBox controlsButton)
        {

            Size originalSize = controlsButton.Size;
            Point originalLocation = controlsButton.Location;

            controlsButton.MouseEnter += (s, e) =>
            {

                controlsButton.Size = new Size((int)(originalSize.Width * 1.1f), (int)(originalSize.Height * 1.1f));

                controlsButton.Location = new Point(
                    originalLocation.X - (controlsButton.Width - originalSize.Width) / 2,
                    originalLocation.Y - (controlsButton.Height - originalSize.Height) / 2
                );

                controlsButton.Cursor = Cursors.Hand;

            };

            controlsButton.MouseLeave += (s, e) =>
            {

                controlsButton.Size = originalSize;
                controlsButton.Location = originalLocation;
                controlsButton.Cursor = Cursors.Default;

            };

        }

        /* In this section, the necessary steps to play music are taken. */
        /* Bu bölümde müzik çalmak için gerekli adýmlar atýlmaktadýr. */

        private void playMusic(string path, string name)
        {

            axWindowsMediaPlayer1.URL = path;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            musicNameLabel.Text = name;

            controlButton.Image = Resources.pauseButton;

            isMusicPlay = true;

            timer1.Enabled = true;

            for (int i = 0; i < playlistContent.Controls.Count; i++)
            {
                if (playlistContent.Controls[i] is Panel panel)
                {

                    panel.BackColor = Color.FromArgb(18, 18, 18); 

                }
            }

            for (int i = 0; i < playlistContent.Controls.Count; i++)
            {
                if (playlistContent.Controls[i] is Panel panel)
                {
                    foreach (Control ctl in panel.Controls)
                    {

                        if (ctl is Label lbl && lbl.Text == name)
                        {

                            panel.BackColor = Color.FromArgb(64, 64, 64); 

                            break;
                        }
                    }
                }
            }

            /* Assigning the image of the currently playing music list to the music icon. */
            /* Þu anda çalýnan müzik listesinin görüntüsünü müzik simgesine atama. */

            for (int i = 0; i < playlistMusics.Count; i++)
            {
                if (playlistMusics[i].Contains(path))
                {

                    if (!string.IsNullOrEmpty(playlistImagePaths[i]) && playlistImagePaths[i] != "default")
                    {

                        musicIcon.Image = Image.FromFile(playlistImagePaths[i]);

                    }
                    else
                    {

                        musicIcon.Image = Resources.musicPhoto;

                    }

                    break;
                }
            }

        }

        private void controlButton_Click(object sender, EventArgs e)
        {

            if (musicNameLabel.Text == "")
                return;

            if (isMusicPlay)
            {

                axWindowsMediaPlayer1.Ctlcontrols.pause();

                controlButton.Image = Resources.playButton;

                isMusicPlay = false;

                timer1.Enabled = false;

            }

            else
            {

                axWindowsMediaPlayer1.Ctlcontrols.play();

                controlButton.Image = Resources.pauseButton;

                isMusicPlay = true;

                timer1.Enabled = true;

            }
        }

        /* A progress bar has been created in this section. */
        /* Bu bölümde bir ilerleme çubuðu oluþturuldu. */

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (axWindowsMediaPlayer1.currentMedia != null)
            {

                double musicDuration = axWindowsMediaPlayer1.currentMedia.duration;
                double currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

                if (musicDuration > 0)
                {

                    int totalWidth = barBackground.Width;
                    int newWidth = (int)((currentPosition / musicDuration) * totalWidth);

                    barProgress.Width = newWidth;

                }
            }

            updateBarLabel();

        }

        private void updateBarLabel()
        {

            if (axWindowsMediaPlayer1.currentMedia != null)
            {

                double musicDuration = axWindowsMediaPlayer1.currentMedia.duration;
                double currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

                TimeSpan currentTime = TimeSpan.FromSeconds(currentPosition);
                TimeSpan totalTime = TimeSpan.FromSeconds(musicDuration);

                currentTimeLabel.Text = $"{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";
                totalTimeLabel.Text = $"{totalTime.Minutes:D2}:{totalTime.Seconds:D2}";

            }
        }

        /* Hover effect for progress bar. */
        /* Ýlerleme çubuðu için hover efekti. */

        private void barBackground_MouseEnter(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                barBackground.Cursor = Cursors.Hand;

        }

        private void barBackground_MouseLeave(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                barBackground.Cursor = Cursors.Default;

        }

        private void barProgress_MouseEnter(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                barProgress.Cursor = Cursors.Hand;

        }

        private void barProgress_MouseLeave(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                barProgress.Cursor = Cursors.Default;

        }

        /* The act of wrapping the song wherever we want. */
        /* Þarkýyý istediðimiz yere sarma eylemi. */

        private void barBackground_MouseClick(object sender, MouseEventArgs e)
        {

            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                double ratio = Math.Max(0, Math.Min(1, (double)e.X / barBackground.Width));
                double musicDuration = axWindowsMediaPlayer1.currentMedia.duration;

                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = musicDuration * ratio;

                barProgress.Width = (int)(ratio * barBackground.Width);

                updateBarLabel();

            }

        }

        private void barProgress_MouseClick(object sender, MouseEventArgs e)
        {

            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                double ratio = Math.Max(0, Math.Min(1, (double)e.X / barBackground.Width));
                double musicDuration = axWindowsMediaPlayer1.currentMedia.duration;

                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = musicDuration * ratio;

                barProgress.Width = (int)(ratio * barBackground.Width);

                updateBarLabel();
            }

        }

        /* A progress voice bar has been created in this section. */
        /* Bu bölümde bir ses ilerleme çubuðu oluþturuldu. */

        private void updateVolume()
        {

            int vol = axWindowsMediaPlayer1.settings.volume;

            if (voiceBarBackground.Width <= 0)
                return;

            int newWidth = (int)Math.Round(vol / 100.0 * voiceBarBackground.Width);
            newWidth = Math.Max(0, Math.Min(voiceBarBackground.Width, newWidth));

            currentVoiceBar.Left = 0;
            currentVoiceBar.Width = newWidth;

            if (vol == 0)
            {

                isMuted = true;

                voiceIcon.Image = Resources.Mute;

            }

            else
            {
                isMuted = false;

                voiceIcon.Image = Resources.voiceIcon;
            }

        }

        /* Hover effect for progress voice bar. */
        /* Ses ilerleme çubuðu için hover efekti. */

        private void voiceBarBackground_MouseEnter(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                voiceBarBackground.Cursor = Cursors.Hand;

        }

        private void voiceBarBackground_MouseLeave(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                voiceBarBackground.Cursor = Cursors.Default;

        }

        private void currentVoiceBar_MouseEnter(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                currentVoiceBar.Cursor = Cursors.Hand;

        }

        private void currentVoiceBar_MouseLeave(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                currentVoiceBar.Cursor = Cursors.Default;

        }

        /* Change the volume by clicking on the volume bar. */
        /* Ses çubuðuna týklayarak ses seviyesini deðiþtirme. */

        private void voiceBarBackground_MouseClick(object sender, MouseEventArgs e)
        {

            if (musicNameLabel.Text != "")
            {

                int x = Math.Max(0, Math.Min(voiceBarBackground.Width, e.X));

                axWindowsMediaPlayer1.settings.volume = x * 100 / voiceBarBackground.Width;

                updateVolume();

            }
        }

        private void currentVoiceBar_MouseClick(object sender, MouseEventArgs e)
        {

            if (musicNameLabel.Text != "")
            {

                int x = Math.Max(0, Math.Min(voiceBarBackground.Width, e.X + currentVoiceBar.Left));

                axWindowsMediaPlayer1.settings.volume = x * 100 / voiceBarBackground.Width;

                updateVolume();

            }
        }

        /* Click on the event to instantly mute the song. */
        /* Þarkýyý anýnda sessize almak için týklama eventi. */

        private void voiceIcon_Click(object sender, EventArgs e)
        {

            if (musicNameLabel.Text == "")
                return;

            if (!isMuted)
            {

                axWindowsMediaPlayer1.settings.volume = 0;
                currentVoiceBar.Width = 0;

                voiceIcon.Image = Resources.Mute;

                isMuted = true;

            }

            else
            {

                axWindowsMediaPlayer1.settings.volume = 50;

                currentVoiceBar.Width = (int)(voiceBarBackground.Width * 0.5);

                voiceIcon.Image = Resources.voiceIcon;

                isMuted = false;

            }
        }

        private void voiceIcon_MouseEnter(object sender, EventArgs e)
        {
            if (musicNameLabel.Text != "")
                voiceIcon.Cursor = Cursors.Hand;

        }

        private void voiceIcon_MouseLeave(object sender, EventArgs e)
        {

            if (musicNameLabel.Text != "")
                voiceIcon.Cursor = Cursors.Default;

        }

        /* The function of the next and back buttons has been done. */
        /* Sonraki ve geri butonlarýnýn iþlevi yapýldý. */

        private void backButton_Click(object sender, EventArgs e)
        {
            if (musicNameLabel.Text == "")
                return;

            string currentMusic = axWindowsMediaPlayer1.URL;

            int playlistIndex = -1;
            int musicIndex = -1;

            for (int i = 0; i < playlistMusics.Count; i++)
            {

                if (playlistMusics[i].Contains(currentMusic))

                {
                    playlistIndex = i;

                    musicIndex = playlistMusics[i].IndexOf(currentMusic);

                    break;

                }
            }

            if (playlistIndex == -1 || musicIndex == -1)
                return;

            double currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

            if (musicIndex == 0 || currentPosition > 1.0)
            {

                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0;

            }

            else
            {

                string previousMusic = playlistMusics[playlistIndex][musicIndex - 1];
                string musicName = Path.GetFileNameWithoutExtension(previousMusic);

                if (musicName.Contains("_playlist") && musicName.Contains("_"))
                {

                    int playlistIdx = musicName.IndexOf("_playlist");

                    musicName = musicName.Substring(0, playlistIdx);

                }

                playMusic(previousMusic, musicName);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (musicNameLabel.Text == "")
                return;

            string currentMusic = axWindowsMediaPlayer1.URL;

            int playlistIndex = -1;
            int musicIndex = -1;

            for (int i = 0; i < playlistMusics.Count; i++)
            {

                if (playlistMusics[i].Contains(currentMusic))
                {

                    playlistIndex = i;

                    musicIndex = playlistMusics[i].IndexOf(currentMusic);

                    break;
                }
            }

            if (playlistIndex == -1 || musicIndex == -1)
                return;

            int nextIndex = musicIndex + 1;

            if (nextIndex >= playlistMusics[playlistIndex].Count)
            {

                nextIndex = 0;

            }

            string nextMusic = playlistMusics[playlistIndex][nextIndex];

            string musicName = Path.GetFileNameWithoutExtension(nextMusic);

            if (musicName.Contains("_playlist") && musicName.Contains("_"))
            {

                int playlistIdx = musicName.IndexOf("_playlist");

                musicName = musicName.Substring(0, playlistIdx);

            }

            playMusic(nextMusic, musicName);
        }

        /* Automatically skips to the next song when the song ends. */
        /* Þarký bittiðinde otomatik olarak bir sonraki þarkýya atlama. */

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            
            if (e.newState == 8) 
            {
                
                System.Windows.Forms.Timer delayTimer = new System.Windows.Forms.Timer();

                delayTimer.Interval = 500; 

                delayTimer.Tick += (s, args) =>
                {
                    delayTimer.Stop();
                    delayTimer.Dispose();

                    if (this.InvokeRequired)
                    {

                        this.Invoke(new Action(() => nextButton_Click(null, null)));

                    }

                    else
                    {

                        nextButton_Click(null, null);

                    }
                };

                delayTimer.Start();
            }
        }
    }
}

