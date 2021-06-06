using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _13_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明Graphics型对象
        Graphics g;
        //创建Rectangle矩形结构，并指定其大小
        Rectangle r = new Rectangle(30, 20, 150, 150);
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化Graphics对象
            g = panel1.CreateGraphics();
            //设置comboBox1控件的DropDownStyle属性，只能从下拉列表项中选择
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //通过下拉列表中项的索引绘制图像
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        //单色画刷
                        SolidBrush SB = new SolidBrush(Color.Green);
                        g.FillRectangle(SB, r);
                        break;
                    }
                case 1:
                    {
                        //纹理画刷
                        HatchBrush HB = new HatchBrush(HatchStyle.Cross, Color.Blue, Color.Orange);
                        g.FillRectangle(HB, r);
                        break;
                    }
                case 2:
                    {
                        //渐变画刷
                        LinearGradientBrush LGB = new LinearGradientBrush(new Point(20, 20), new Point(25, 30), Color.Black, Color.Firebrick);
                        g.FillRectangle(LGB, r);
                        break;
                    }
                default:
                    {
                        //图像画刷，通过打开文件对话框控件，使选择的图像填充到窗体
                        openFileDialog1.Filter = "图形图像(*.jpg)|*.jpg|图像(*.gif)|*.gif";
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            TextureBrush TB = new TextureBrush(Image.FromFile(openFileDialog1.FileName));
                            //设置TranslateTransform属性使图像从坐标30，20开始填充
                            g.TranslateTransform(30, 20);
                            g.FillRectangle(TB, 0,0,150,150);
                        }
                        break;
                    }
            }
        }
    }
}
