using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
namespace myControl
{
    public partial class WordRain : UserControl
    {
        private Timer m_timer;  //重绘定时器
        private Timer m_newtimer;   //新建字符定时器
        private Graphics m_g;     //画布
        private ArrayList m_charlist;//保存当前显示在控件中的WordInfo对象
        //（超出控件范围的对象要及时删除）。
        private ArrayList m_selectlist;//显示要绘制的字符
        //（每次重绘控件的时候都会随机获取m_charlist中的一个字符用于显示）
        private WordInfoSorter m_sorter;
        private Random m_random;     
        public WordRain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.BackColor = Color.Black;
            m_charlist = new ArrayList();
            WordInfo wordinfo = new WordInfo();
            wordinfo.SetValue();
            m_charlist.Add(wordinfo);
            m_sorter = new WordInfoSorter();
            string s = "Welcome To The World of Hackers!";
            string[] arr = new string[] { "+", "-", "。", "a", "v", "，", "？", "7", "8", "9" };
            char[] CHARACTERS ={ '`', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
            '-', '=', '\\', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', '[', ']', 'a', 's',
            'd', 'f', 'g', 'h', 'j', 'k', 'l', ';', '\'', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ','
                , '.', '/', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '|'
                , 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', '{', '}', 'A', 'S', 'D', 'F',
            'G', 'H', 'J', 'K', 'L', ':', '"', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '<', '>', '?' };
        m_selectlist = new ArrayList(CHARACTERS);
            m_random = new Random();
            m_timer = new Timer();
            m_newtimer = new Timer();
            m_timer.Interval = 30;
            m_newtimer.Interval = 30;
            m_timer.Enabled = true;
            m_newtimer.Enabled = true;
            m_timer.Tick += new EventHandler(m_timer_Tick);
            m_newtimer.Tick += new EventHandler(m_newtimer_Tick);
        }
        public class WordInfo//每条显示的字符串
        {
            public int m_fontsize;      //字体大小
            public float m_runspeed;    //移动速度
            public Color m_charcolor;   //最下面的字的颜色，最上面的字的颜色为背景色
            public float m_posx;        //横坐标
            public float m_posy;        //纵坐标
            public int m_count;         //字符个数
            public ArrayList m_charList;  //要显示的字符列表

            public static int m_max_xpos = 600;
            public static int m_min_count = 10;
            public static int m_max_count = 20;
            public static int m_min_fontsize = 4;
            public static int m_max_fontsize = 20;
            public static float m_min_runspeed = 0.6F;
            public static float m_max_runspeed = 4.2F;
            public static Color m_min_charcolor = Color.FromArgb(0, 255, 0);//浅绿
            public static Color m_max_charcolor = Color.FromArgb(0, 55, 0);//深绿
            public static Random m_random = new Random();

            public WordInfo()//构造函数
            {//初始化字符个数1，字体大小0，速度0，横纵坐标0，
                this.m_count = 1;
                this.m_fontsize = 0;
                this.m_runspeed = 0;
                this.m_posx = 0;
                this.m_posy = 0;
                this.m_charcolor = Color.FromArgb(0, 255, 0);
            }


            //获取字体大小的随机值
            private int GetFontSize()
            {
                int i = m_random.Next();
                return i % (m_max_fontsize - m_min_fontsize) + m_min_fontsize;
            }

            //获取速度的随机值
            private float GetSpeed()
            {
                int i = m_random.Next();
                int j = m_random.Next();
                return i % (m_max_runspeed - m_min_runspeed) + m_min_runspeed + (j % 10) / 10.0F;
            }

            //获取颜色的随机值
            private Color GetColor()
            {
                int min_r = m_min_charcolor.R;
                int min_g = m_min_charcolor.G;
                int min_b = m_min_charcolor.B;
                int max_r = m_max_charcolor.R;
                int max_g = m_max_charcolor.G;
                int max_b = m_max_charcolor.B;
                int r = m_random.Next((min_r > max_r ? max_r : min_r), (min_r < max_r ? max_r : min_r));
                int g = m_random.Next((min_g > max_g ? max_g : min_g), (min_g < max_g ? max_g : min_g));
                int b = m_random.Next((min_b > max_b ? max_b : min_b), (min_b < max_b ? max_b : min_b));
                return Color.FromArgb(r, g, b);
            }

            //设置字体和颜色(字体越小，颜色越接近m_max_charcolor)
            private void SetFontAndColor()
            {
                int i = m_random.Next();
                int fontpart = i % (m_max_fontsize - m_min_fontsize);
                this.m_fontsize = m_min_fontsize + fontpart;
                float percent = ((float)fontpart) / ((float)(m_max_fontsize - m_min_fontsize));
                int min_r = m_min_charcolor.R;
                int min_g = m_min_charcolor.G;
                int min_b = m_min_charcolor.B;
                int max_r = m_max_charcolor.R;
                int max_g = m_max_charcolor.G;
                int max_b = m_max_charcolor.B;
                int rpart = (int)(Math.Abs(min_r - max_r) * percent);
                int gpart = (int)(Math.Abs(min_g - max_g) * percent);
                int bpart = (int)(Math.Abs(min_b - max_b) * percent);
                int r = min_r > max_r ? (max_r + rpart) : (max_r - rpart);
                int g = min_g > max_g ? (max_g + gpart) : (max_g - gpart);
                int b = min_b > max_b ? (max_b + bpart) : (max_b - bpart);
                this.m_charcolor =Color.FromArgb(r, g, b);
            }

            //获取x轴坐标
            private float GetXPos()
            {
                int i = m_random.Next(m_max_xpos - 1);
                return (float)(i + m_random.Next(10) / 10.0F);

            }

            //获取随机个数
            private int GetCount()
            {
                return m_random.Next(m_min_count, m_max_count);
            }

            //设置相关值
            public void SetValue()
            {
                this.m_count = this.GetCount();
                this.SetFontAndColor();
                this.m_runspeed = this.GetSpeed();
                this.m_posy = m_count * m_fontsize * (-1.0F);
                this.m_posx = this.GetXPos();
            }
            //获取颜色
            public Color GetColor(int index)
            {
                if (this.m_count == 1)
                    return this.m_charcolor;
                if (index == 0)
                    return this.m_charcolor;
                int rpart = (Math.Abs(m_charcolor.R - m_max_charcolor.R)) / m_count * index;
                int gpart = (Math.Abs(m_charcolor.G - m_max_charcolor.G)) / m_count * index;
                int bpart = (Math.Abs(m_charcolor.B - m_max_charcolor.B)) / m_count * index;
                int r = m_charcolor.R > m_max_charcolor.R ? (m_charcolor.R - rpart) : (m_charcolor.R + rpart);
                int g = m_charcolor.G > m_max_charcolor.G ? (m_charcolor.G - gpart) : (m_charcolor.G + gpart);
                int b = m_charcolor.B > m_max_charcolor.B ? (m_charcolor.B - bpart) : (m_charcolor.B + bpart);
                return Color.FromArgb(255 - index * 255 / m_count, m_charcolor);
            }
        }
        /*1. 字体较大字符串的必需在字体小的字符串之后画，避免字体小的字符串遮住字体大的字符串，影响效果。
    要达到这样的效果必须在每次重绘的时候，对m_charlist中的所有WordInfo对象按字体大小从小到大排序。*/
        public class WordInfoSorter : IComparer
        {
            int IComparer.Compare(object x, object y)//比较字体大小
            {
                if (((WordInfo)x).m_fontsize < ((WordInfo)y).m_fontsize)
                    return -1;
                else if (((WordInfo)x).m_fontsize == ((WordInfo)y).m_fontsize)
                    return 0;
                else
                    return 1;
            }
        }

        private char GetStringFromArrayList()//随机获取一个字符显示
        {
            return (char)m_selectlist[m_random.Next(m_selectlist.Count)];
        }

        void m_newtimer_Tick(object sender, EventArgs e)//定时创建新的字符串对象
        {
            WordInfo wordinfo = new WordInfo();
            wordinfo.SetValue();
            m_charlist.Add(wordinfo);
        }

        void m_timer_Tick(object sender, EventArgs e)//重绘控件
        {
            this.Invalidate();
            ArrayList ObjToDel = new ArrayList();
            foreach (WordInfo temp in m_charlist)
            {
                temp.m_posy += temp.m_runspeed;
                if (temp.m_posy > this.Height + temp.m_fontsize * temp.m_count)
                    ObjToDel.Add(temp);
            }
           // 删除超出控件范围的对象
            foreach (WordInfo temp in ObjToDel)
            {
                m_charlist.Remove(temp);
            }
            ObjToDel.Clear();
        }

        private void WordRain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);//获取屏幕大小
            this.Height = ScreenArea.Height;
            this.Width = ScreenArea.Width;
            m_g = e.Graphics;
            m_charlist.Sort(m_sorter);//排序
            SetXRange(this.Width);
            foreach (WordInfo temp in m_charlist)
            {
                using (Font font = new Font("Arial", temp.m_fontsize, GraphicsUnit.Pixel))
                {
                    using (SolidBrush brush = new SolidBrush(Color.Red))//(temp.m_charcolor))
                    {
                        for (int i = 0; i < temp.m_count; i++)
                        {
                            brush.Color = temp.GetColor(i);
                            m_g.DrawString(GetStringFromArrayList().ToString(), font, brush, temp.m_posx, temp.m_posy - temp.m_fontsize * i);
                        }
                    }
                }
            }
        }
        public void SetXRange(int value)
        {
            WordInfo.m_max_xpos = value;
        }
        //设置字体大小范围
        /*  public void SetFontSizeRange(int minsize, int maxsize)
          {
              if (minsize > maxsize)
              {
                  throw new ArgumentException("参数minsize必须小于等于参数maxsize");
              }
              if (minsize < 1 || maxsize > 50)
              {
                  throw new ArgumentException("参数minsize和maxsize必须在区间[1,50]内");
              }
              WordInfo.m_min_fontsize = minsize;
              WordInfo.m_max_fontsize = maxsize;
          }
        //设置字体渐变颜色范围
         public void SetFontColorRange(Color firstColor, Color lastColor)
         {
             WordInfo.m_min_charcolor = firstColor;
             WordInfo.m_max_charcolor = lastColor;
         }
        //设置X轴所能到达的最大长度(即控件的宽度)

        //设置速度
          public void SetSpeedRange(float minspeed, float maxspeed)
          {
              if (minspeed > maxspeed)
              {
                  throw new ArgumentException("参数minspeed必须小于等于参数maxspeed");
              }
              if (minspeed < 0.1 || maxspeed > 100.0)
              {
                  throw new ArgumentException("参数minspeed和maxspeed必须在区间[0.1,100.0]内");
              }
              WordInfo.m_min_runspeed = minspeed;
              WordInfo.m_min_runspeed = maxspeed;
          }
        //设置字符个数范围
         public void SetCountRange(int mincount, int maxcount)
          {
              if (mincount > maxcount)
              {
                  throw new ArgumentException("参数mincount必须小于等于参数maxcount");
              }
              if (mincount < 1 || maxcount > 100)
              {
                  throw new ArgumentException("参数mincount和maxcount必须在区间[1,100]内");
              }
              WordInfo.m_min_count = mincount;
              WordInfo.m_max_count = maxcount;
          }
          //设置字符列表
          public void SetArrayValue(ArrayList list)
          {
              if (list.Count == 0)
              {
                  throw new ArgumentException("参数list中的元素个数不能为0");
              }
              m_selectlist.Clear();
              m_selectlist = list;
          }*/
    }
}
