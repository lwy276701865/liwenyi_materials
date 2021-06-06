using System;
using System.Drawing;
using System.Windows.Forms;

namespace IOS12TestDistance
{
    public partial class FrmDistanceMeasure : Form
    {
        public FrmDistanceMeasure()
        {
            InitializeComponent();
        }
        Graphics g;
        private void FrmDistanceMeasure_Paint(object sender, PaintEventArgs e)
        {
            g =e.Graphics ;
            Image img = Image.FromFile(@"..\..\..\素材\yaoming.jpg");
            g.DrawImage(img, 0, 0);
            g.DrawString(distance.ToString("f0") + "cm", this.Font, Brushes.White, 0, 0);         
        }
        public   Point pMouseDown;
        public  Point pMove;
        int radius=10;
        bool isDown;
        double distance;
        public void drawMyGraphics(Point p)
        {
                g = this.CreateGraphics();
                Pen pen = new Pen(Color.White, 1);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.FillEllipse(Brushes.White, new Rectangle(p.X - radius, p.Y - radius,
              radius * 2, radius * 2));
                g.DrawEllipse(pen, new Rectangle(p.X - radius * 2, p.Y - radius * 2, radius * 4,
                  radius * 4));
        }
        private void FrmDistanceMeasure_MouseDown(object sender, MouseEventArgs e)
        {           
           if (e.Button == System.Windows.Forms.MouseButtons.Left)
                isDown = true;     
                pMouseDown = e.Location;
            this.Refresh();        
        }
        private void FrmDistanceMeasure_MouseMove(object sender, MouseEventArgs e)
        {         
           if (isDown)
            {         
               this.Refresh();
                drawMyGraphics(pMouseDown);
                g = this.CreateGraphics();
                Pen pThead = new Pen(Color.White, 3);
                pMove = e.Location;      
                g.DrawLine(pThead, pMouseDown,pMove);
            //  pStart = e.Location;//将起点重置为当前鼠标所在位置   
                distance = Math.Sqrt(Math.Pow((pMouseDown.X - pMove.X),2 )+Math.Pow( (pMouseDown.Y - pMove.Y),2)) * 0.34f;
                // g.Clear(Color.Transparent);               
            }
        }
        private void FrmDistanceMeasure_MouseUp(object sender, MouseEventArgs e)
        {          
            drawMyGraphics(pMove);       
            isDown = false;
        }
    }
}
