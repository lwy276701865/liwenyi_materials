using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Tile;   //设置listview1控件的View属性
            listView1.TileSize = new Size(100, 50);   //设置listview1控件的属性TileSize，设置平铺的宽为100，高50
            listView1.LargeImageList = imageList1;
            imageList1.Images.Add((Image.FromFile("1.jpg")));   //添加图片
            imageList1.Images.Add((Image.FromFile("2.jpg")));
            listView1.Items.Add("C#4.0");
            listView1.Items.Add("C#6.0");
            listView1.Items.Add("C");
            listView1.Items[0].ImageIndex = 0;
            listView1.Items[1].ImageIndex = 0;
            listView1.Items[2].ImageIndex = 1;
        }
    }
}
