using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AlgoProject_SoundsPacking_
{
    public partial class mainForm : Form
    {
        Point lastLoc;
        List<Audio> audiosList;
        public mainForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void audiosBtn_Click(object sender, EventArgs e)
        {
            audiosFolderBrowser.ShowNewFolderButton = false;
            audiosFolderBrowser.ShowDialog();
            if (audiosFolderBrowser.SelectedPath.ToString() != "")
            {
                audiosTxt.Text = audiosFolderBrowser.SelectedPath.ToString() + '\\';
            }
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            textFileBrowser.FileName = "";
            textFileBrowser.ShowDialog();
            if (textFileBrowser.FileName.ToString() != "")
            {
                textTxt.Text = textFileBrowser.FileName.ToString();

                audiosList = getAudioDetails(textTxt.Text);

                MessageBox.Show("File open successfully and stored the audio files details.", "File Open",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void audiosOutBtn_Click(object sender, EventArgs e)
        {
            audiosFolderBrowser.ShowNewFolderButton = true;
            audiosFolderBrowser.ShowDialog();
            if (audiosFolderBrowser.SelectedPath.ToString() != "")
                audiosOutTxt.Text = audiosFolderBrowser.SelectedPath.ToString() + '\\';
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// To get audio files details and add them in a list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<Audio> getAudioDetails(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            int numOfAudios = Convert.ToInt32(sr.ReadLine());
            List<Audio> audios = new List<Audio>();
            Audio audio;
            while (sr.Peek() != -1)
            {

                string audioDetailsLine = sr.ReadLine();
                string[] audioDetails = audioDetailsLine.Split(' ');
                string[] audioSecs = audioDetails[1].Split(':');
                long totalSecs = (Convert.ToInt32(audioSecs[0]) * 60 * 60) + (Convert.ToInt32(audioSecs[1]) * 60) +
                    Convert.ToInt32(audioSecs[2]);

                audio = new Audio();
                audio.name = audioDetails[0];
                audio.secDuration = totalSecs;
                audios.Add(audio);
            }

            sr.Close();
            return audios;
        }


        /*GUI Events
         */
        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.DimGray;
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.Firebrick;
        }

        private void audiosBtn_MouseEnter(object sender, EventArgs e)
        {
            audiosBtn.ForeColor = Color.Black;
        }

        private void audiosBtn_MouseLeave(object sender, EventArgs e)
        {
            audiosBtn.ForeColor = Color.DimGray;
        }

        private void textBtn_MouseEnter(object sender, EventArgs e)
        {
            textBtn.ForeColor = Color.Black;
        }

        private void textBtn_MouseLeave(object sender, EventArgs e)
        {
            textBtn.ForeColor = Color.DimGray;
        }

        private void controlLbl_MouseDown(object sender, MouseEventArgs e)
        {
            lastLoc = e.Location;
        }

        private void controlLbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point((this.Location.X - lastLoc.X) + e.X, (this.Location.Y - lastLoc.Y) + e.Y);
            }
        }

        private void generateAudios_MouseEnter(object sender, EventArgs e)
        {
            generateAudios.ForeColor = Color.Firebrick;
        }

        private void generateAudios_MouseLeave(object sender, EventArgs e)
        {
            generateAudios.ForeColor = Color.DimGray;
        }

        private void miniBtn_MouseEnter(object sender, EventArgs e)
        {
            miniBtn.ForeColor = Color.Firebrick;
        }

        private void miniBtn_MouseLeave(object sender, EventArgs e)
        {
            miniBtn.ForeColor = Color.DimGray;
        }


        private void audiosTxt_TextChanged(object sender, EventArgs e)
        {
            if (audiosTxt.Text != "Please select the folder contain audio files" &&
                textTxt.Text != "Please select the text file contain audio files details" &&
                audiosOutTxt.Text != "Please select the folder to generate audio files")
                generateAudios.Enabled = true;
            else
                generateAudios.Enabled = false;
        }

        private void textTxt_TextChanged(object sender, EventArgs e)
        {
            if (audiosTxt.Text != "Please select the folder contain audio files" &&
                textTxt.Text != "Please select the text file contain audio files details" &&
                audiosOutTxt.Text != "Please select the folder to generate audio files")
                generateAudios.Enabled = true;
            else
                generateAudios.Enabled = false;
        }

        private void audiosOutTxt_TextChanged(object sender, EventArgs e)
        {
            if (audiosTxt.Text != "Please select the folder contain audio files" &&
                textTxt.Text != "Please select the text file contain audio files details" &&
                audiosOutTxt.Text != "Please select the folder to generate audio files")
                generateAudios.Enabled = true;
            else
                generateAudios.Enabled = false;
        }
    }
}
