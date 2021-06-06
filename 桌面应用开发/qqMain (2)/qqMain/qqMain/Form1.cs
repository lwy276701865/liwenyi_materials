using System;
using System.Drawing;
using System.Windows.Forms;

namespace qqMain
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public class NewPanel : Panel
        {
            public NewPanel()
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.UserPaint, true);
            }
        }
        public Point p;
        frmWeather f;
        private void PicbWeather_MouseEnter(object sender, EventArgs e)
        {

            p = new Point(this.Location.X + this.Width, this.Location.Y);//确定天气窗体弹出的位置
            f = new frmWeather(p);
            f.Show();
            f.setFormImgValue += new frmWeather.setBackImgValue(f_setFormImgValue);//添加事件
        }
        void f_setFormImgValue(Image ImgValue)
        {
            //具体实现事件
            this.picbWeather.BackgroundImage = ImgValue;
        }
        private void PicbWeather_MouseLeave(object sender, EventArgs e)
        {
            f.Hide();
        }

        Point pMouseDown;
        bool isMoving;
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isMoving = true;
            }
        }
        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            //窗体位置跟着鼠标位置移动
            if (isMoving)
            {
                this.Location = new Point(this.Location.X + e.X - pMouseDown.X,
                    this.Location.Y + e.Y - pMouseDown.Y);
            }
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(picClose, "关闭");
            toolTip.SetToolTip(pnlClose, "关闭");
            toolTip.SetToolTip(picMinisize, "最小化");
            toolTip.SetToolTip(pnlMinisize, "最小化");
            toolTip.SetToolTip(picSvip, "超级会员中心");
            toolTip.SetToolTip(pnlSvip, "超级会员中心");
            toolTip.SetToolTip(picMail, "QQ邮箱");
            toolTip.SetToolTip(pnlMail, "QQ邮箱");
            toolTip.SetToolTip(picMedal, "勋章墙");
            toolTip.SetToolTip(pnlMedal, "勋章墙");
            toolTip.SetToolTip(picDress, "个性装扮");
            toolTip.SetToolTip(pnlDress, "个性装扮");
            toolTip.SetToolTip(picZone, "QQ空间\n 有新访客\n 有新好友动态");
            toolTip.SetToolTip(pnlZone, "QQ空间\n 有新访客\n 有新好友动态");
            toolTip.SetToolTip(picMenu, "主菜单");
            toolTip.SetToolTip(pnlMenu, "主菜单");
            toolTip.SetToolTip(picAdd, "加好友");
            toolTip.SetToolTip(pnlAdd, "加好友");
            toolTip.SetToolTip(picDocument, "腾讯文档");
            toolTip.SetToolTip(pnlDocument, "腾讯文档");
            toolTip.SetToolTip(picMicroCloud, "微云");
            toolTip.SetToolTip(pnlMicroCloud, "微云");
            toolTip.SetToolTip(picVideo, "腾讯视频");
            toolTip.SetToolTip(pnlVideo, "腾讯视频");
            toolTip.SetToolTip(picMusic, "QQ音乐");
            toolTip.SetToolTip(pnlMusic, "QQ音乐");
            toolTip.SetToolTip(picApplicationCenter, "应用管理器");
            toolTip.SetToolTip(pnlApplicationCenter, "应用管理器");
            toolTip.SetToolTip(lblLv, "我的Q等级\n 等级88级\n 剩余升级天数88天");
            toolTip.SetToolTip(picIsSvip, "你是超级会员SVIP8，等级加速2.8\n倍生效中");
            toolTip.SetToolTip(lblSignature, "个性签名更新:");
        }
        private void picClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pnlClose_MouseEnter(object sender, EventArgs e)
        {
            pnlClose.BackColor = Color.Red;
        }

        private void pnlClose_MouseLeave(object sender, EventArgs e)
        {
            pnlClose.BackColor = Color.Transparent;
        }
        private void picMinisize_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlMinisize_MouseEnter(object sender, EventArgs e)
        {
            ((Panel)sender).BackColor = Color.FromArgb(242, 242, 242);
        }

        private void pnlMinisize_MouseLeave(object sender, EventArgs e)
        {
            ((Panel)sender).BackColor = Color.Transparent;
        }

        private void picMinisize_MouseEnter(object sender, EventArgs e)
        {
            pnlMinisize.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picMinisize_MouseLeave(object sender, EventArgs e)
        {
            pnlMinisize.BackColor = Color.Transparent;
        }

        private void picSvip_MouseEnter(object sender, EventArgs e)
        {
            pnlSvip.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picSvip_MouseLeave(object sender, EventArgs e)
        {
            pnlSvip.BackColor = Color.Transparent;
        }

        private void picMail_MouseEnter(object sender, EventArgs e)
        {
            pnlMail.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picMail_MouseLeave(object sender, EventArgs e)
        {
            pnlMail.BackColor = Color.Transparent;
        }

        private void picMedal_MouseEnter(object sender, EventArgs e)
        {
            pnlMedal.BackColor = Color.FromArgb(242, 242, 242);         
        }

        private void picMedal_MouseLeave(object sender, EventArgs e)
        {
            pnlMedal.BackColor = Color.Transparent;
        }

        private void picDress_MouseEnter(object sender, EventArgs e)
        {
            pnlDress.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picDress_MouseLeave(object sender, EventArgs e)
        {
            pnlDress.BackColor = Color.Transparent;
        }

        private void picZone_MouseEnter(object sender, EventArgs e)
        {
            pnlZone.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picZone_MouseLeave(object sender, EventArgs e)
        {
            pnlZone.BackColor = Color.Transparent;
        }

        private void picDot_MouseEnter(object sender, EventArgs e)
        {
            pnlDot.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picDot_MouseLeave(object sender, EventArgs e)
        {
            pnlDot.BackColor = Color.Transparent;
        }

        private void picMenu_MouseEnter(object sender, EventArgs e)
        {
            pnlMenu.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picMenu_MouseLeave(object sender, EventArgs e)
        {
            pnlMenu.BackColor = Color.Transparent;
        }

        private void picAdd_MouseEnter(object sender, EventArgs e)
        {
            pnlAdd.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picAdd_MouseLeave(object sender, EventArgs e)
        {
            pnlAdd.BackColor = Color.Transparent; 
        }

        private void picDocument_MouseEnter(object sender, EventArgs e)
        {
            pnlDocument.BackColor= Color.FromArgb(242, 242, 242); 
        }

        private void picDocument_MouseLeave(object sender, EventArgs e)
        {
            pnlDocument.BackColor = Color.Transparent;
        }

        private void picMicroCloud_MouseEnter(object sender, EventArgs e)
        {
            pnlMicroCloud.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picMicroCloud_MouseLeave(object sender, EventArgs e)
        {
            pnlMicroCloud.BackColor = Color.Transparent;
        }

        private void picVideo_MouseEnter(object sender, EventArgs e)
        {
            pnlVideo.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picVideo_MouseLeave(object sender, EventArgs e)
        {
            pnlVideo.BackColor = Color.Transparent;
        }

        private void picMusic_MouseEnter(object sender, EventArgs e)
        {
            pnlMusic.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picMusic_MouseLeave(object sender, EventArgs e)
        {
            pnlMusic.BackColor = Color.Transparent; 
        }

        private void picApplicationCenter_MouseEnter(object sender, EventArgs e)
        {
            pnlApplicationCenter.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void picApplicationCenter_MouseLeave(object sender, EventArgs e)
        {
            pnlApplicationCenter.BackColor = Color.Transparent;
        }

        private void lblSignature_Click(object sender, EventArgs e)
        {
            lblSignature.Visible = false;
            txtSignature.Visible = true;
        }

        private void txtSignature_Leave(object sender, EventArgs e)
        {
            lblSignature.Visible = true;
            txtSignature.Visible = false;
        }

        private void pnlPerson_Click(object sender, EventArgs e)
        {
            lblSignature.Visible = true;
            txtSignature.Visible = false;
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            lblSignature.Visible = true;
            txtSignature.Visible = false;
        }

        private void lblSignature_MouseDown(object sender, MouseEventArgs e)
        {
            lblSignature.Visible = false;
            txtSignature.Visible = true;
        }

        private void pnlExpand_Click(object sender, EventArgs e)
        {
            lblSignature.Visible = true;
            txtSignature.Visible = false;
        }
    }
}
