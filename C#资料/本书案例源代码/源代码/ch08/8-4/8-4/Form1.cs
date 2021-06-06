using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.LargeImageList = imageList1;   //设置ListView1的LargeImageList和SmallImageList属性
            listView1.SmallImageList = imageList1;
            imageList1.ImageSize = new Size(36, 35);   //设置imageList1控件图标尺寸
            imageList1.Images.Add((Image.FromFile("1.jpg")));   //向imageList1中添加两个图标
            imageList1.Images.Add((Image.FromFile("1.jpg")));
            listView1.Items.Add("C#");   //向listView1中添加两项
            listView1.Items.Add("C");
            listView1.Items[0].ImageIndex = 0;  //设置listView1中项的图标索引 
            listView1.Items[1].ImageIndex = 1;
        }
    }
}
