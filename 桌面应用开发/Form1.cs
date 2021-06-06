using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicUITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

            string[] alFileNames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            // string mp3FileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            axWindowsMediaPlayer3.currentPlaylist = axWindowsMediaPlayer3.newPlaylist("fy", "");

            foreach (string strFile in alFileNames)
            {
                axWindowsMediaPlayer3.currentPlaylist.appendItem(axWindowsMediaPlayer3.newMedia(strFile));
              
            }
            axWindowsMediaPlayer3.Ctlcontrols.play();
            //   axWindowsMediaPlayer3.URL = alFileNames[0];
            //  axWindowsMediaPlayer3.Ctlcontrols.play();

            userControl12.IsPlaying = true;

          
          


            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer3.currentMedia.duration <= 0)
            {
                return;
            }
            else
            {
                string sTitle = axWindowsMediaPlayer3.currentMedia.getItemInfo("Title");
                string sAuthor = axWindowsMediaPlayer3.currentMedia.getItemInfo("Author");
                lblAuthor.Text = sAuthor;
                lblTitle.Text = sTitle;
                userControl12.MaxValue = axWindowsMediaPlayer3.currentMedia.duration;
            }

            lblCurPlayTime.Text = axWindowsMediaPlayer3.Ctlcontrols.currentPositionString;
            userControl12.CurValue = axWindowsMediaPlayer3.Ctlcontrols.currentPosition;
            userControl12.Refresh();
        }

        private void userControl12_Click(object sender, EventArgs e)
        {
            userControl12.IsPlaying = !userControl12.IsPlaying;

            if (userControl12.IsPlaying)
            {
                axWindowsMediaPlayer3.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer3.Ctlcontrols.pause();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void picNext_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer3.Ctlcontrols.next();
        }

        private void picPrev_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer3.Ctlcontrols.previous();
        }

        private void picLoop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.settings.setMode("loop", true);
        }

        private void picRandom_Click(object sender, EventArgs e)
        {

            
                axWindowsMediaPlayer3.settings.setMode("shuffle", true);
            }

        private void picMute_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.settings.mute = !axWindowsMediaPlayer3.settings.mute;
        }

        private void axWindowsMediaPlayer3_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            //string s1 = axWindowsMediaPlayer3.currentMedia.getAttributeName();
            string s2 = axWindowsMediaPlayer3.currentMedia.getItemInfo("Author");
            if (s2.Equals("陈一发儿"))
            {
                userControl12.AuthorImg = Image.FromFile("AuthorImage\\cyf2.png");
            }
            else if (s2.Equals("大壮"))
            {
                userControl12.AuthorImg = Image.FromFile("AuthorImage\\dz.png");
            }
            else if (s2.Equals("薛之谦"))
            {
                userControl12.AuthorImg = Image.FromFile("AuthorImage\\xzq.png");
            }
            else if (s2.Equals("金南玲"))
            {
                userControl12.AuthorImg = Image.FromFile("AuthorImage\\llch.png");
            }
            else if (s2.Equals("音阙诗听"))
            {
                userControl12.AuthorImg = Image.FromFile("AuthorImage\\yqst.png");
            }
            else 
            {
                userControl12.AuthorImg = Image.FromFile("AuthorImage\\default.png");
            }
        }

        Point startPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            isMoving = true;
        }


        bool isMoving;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                this.Location = new Point(this.Location.X + e.X - startPoint.X,
                    this.Location.Y + e.Y - startPoint.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }
    }
}
