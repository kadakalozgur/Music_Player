using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

/* This is the add playlist section. */
/* Burası çalma listesi ekleme bölümüdür. */

namespace MusicPlayer
{
    public partial class Form2 : Form
    {

        public bool photoSelected = false;
        public string playListName ;
        public Image selectedImage;

        public Form2()
        { 
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

            saveButton.Location = new Point((this.ClientSize.Width - saveButton.Width) / 2, this.ClientSize.Height - saveButton.Height - 20);

        }

        /* In this section, a hover effect has been created for the close button. */
        /* Bu bölümde kapatma butonu için bir gezinme efekti oluşturuldu. */

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {

            closeButton.Image = Resources.closeHoverButton;
            closeButton.Cursor = Cursors.Hand;

        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {

            closeButton.Image = Resources.closeButton;
            closeButton.Cursor = Cursors.Default;

        }

        /* In this section, the playlist adding menu is closed. */
        /* Bu bölümde çalma listesi ekleme menüsü kapatılır. */

        private void closeButton_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        /* In this section, a hover effect has been created for the save button. */
        /* Bu bölümde kaydetme butonu için bir gezinme efekti oluşturuldu. */

        private void saveButton_MouseEnter(object sender, EventArgs e)
        {

            saveButton.Image = Resources.saveButtonHover;
            saveButton.Cursor = Cursors.Hand;

        }

        private void saveButton_MouseLeave(object sender, EventArgs e)
        {

            saveButton.Image = Resources.saveButton;
            saveButton.Cursor = Cursors.Default;

        }

        /* Hover effect for file selection screen. */
        /* Dosya seçim ekranı için gezinme efekti. */

        private void selectPhoto_MouseEnter(object sender, EventArgs e)
        {

            if (!photoSelected)
            {

                selectPhoto.Image = Resources.selectPhoto;

            }

            selectPhoto.Cursor = Cursors.Hand;

        }

        private void selectPhoto_MouseLeave(object sender, EventArgs e)
        {

            if (!photoSelected)
            {

                selectPhoto.Image = Resources.musicPhoto;

            }

            selectPhoto.Cursor = Cursors.Default;

        }

        /* In this section you can select the photo you want to add to the playlist. */
        /* Bu bölümde çalma listesine eklemek istediğiniz fotoğrafı seçebilirsiniz. */

        private void selectPhoto_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    selectPhoto.Image = Image.FromFile(ofd.FileName);

                    photoSelected = true;

                    selectedImage = selectPhoto.Image;

                }

            }

        }

        /* Click Save Button */
        /* Kaydetme Butonu */

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {

                MessageBox.Show("Please Enter A Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

                playListName = nameTextBox.Text;

                if (!photoSelected)
                    selectedImage = Resources.musicPhoto;

                this.DialogResult = DialogResult.OK;
                this.Close();

        }
    }
}
