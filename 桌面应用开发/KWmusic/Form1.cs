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
namespace KWmusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        List<Label> lstLyric = new List<Label>();
         List<double> lstTime = new List<double>();
        private void Button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "陈一发儿-童话镇.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            
            //把歌词从文件载入进来
            FileStream fs = new FileStream("陈一发儿-童话镇.lrc",FileMode.Open);
            Encoding encode = Encoding.GetEncoding("GB2312");
            StreamReader sr = new StreamReader(fs,encode);
            string str;
            int y = 30;
            while ((str = sr.ReadLine()) != null)
            {
                if (str == "")
                    continue;
                Label lbl = new Label();
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("微软雅黑",12);
                lbl.Height = 19;
                lbl.Width = 200;
                lbl.Text = str.Substring(10);
                int minute = int.Parse(str.Substring(1, 2));
                double second =double.Parse(str.Substring(4,5));
                double totalSeconds = minute * 60 + second;
                lstTime.Add(totalSeconds);
                lbl.Location = new Point(100, y);
                y += 15;
                this.Controls.Add(lbl);
                lstLyric.Add(lbl);
               // sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            timer1.Enabled = true;
          
        }

        private void AxWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        int curLyricIdx = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            label2.Text = axWindowsMediaPlayer1.currentMedia.durationString;
            progressBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
            progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            double curMp3PlayTime=axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            if (curMp3PlayTime > lstTime[curLyricIdx])
            {
                curLyricIdx++;
            }
            for(int i=0;i<lstLyric.Count;i++)
            {
                if(i==curLyricIdx)
                {
                    lstLyric[i].ForeColor = Color.Red;
                    lstLyric[i].Font = new Font("微软雅黑", 15);
                }
               else
                {
                    lstLyric[i].ForeColor = Color.White;
                    lstLyric[i].Font = new Font("微软雅黑", 12);
                }
            }
        for(int i=0;i<lstLyric.Count;i++)
            {
                lstLyric[i].Location = new Point(lstLyric[i].Location.X, lstLyric[i].Location.Y-2);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Lyrics lyrics = new Lyrics();
            lyrics.LoadLyricFromFile("陈一发儿-童话镇.lrc");
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //this.Invalidate();//无效化窗体，可以再调用Paint事件
            g.DrawString("童话镇", new Font("微软雅黑", 12), Brushes.White, new PointF(100, 100));         
        }
    }
}
