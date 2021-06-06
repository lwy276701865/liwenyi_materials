using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace ForceLearnEng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //钩子屏蔽ALT+F4
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x00000000; private const int MF_GRAYED = 0x00000001; private const int MF_DISABLED = 0x00000002;
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);[DllImport("User32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200; CreateParams cp = base.CreateParams; cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE; return cp;
            }
        }
        //开机自启动
        private static RegistryKey HKCU = Registry.CurrentUser;
        private static string name = "DBAnalyzer";
        private static string path = Application.ExecutablePath;
        /// 快捷方式名称-任意自定义
        private const string QuickName = "TCNVMClient";
        /// 自动获取系统自动启动目录
        private string systemStartPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Startup); } }
        /// 自动获取程序完整路径
        private string appAllPath { get { return Process.GetCurrentProcess().MainModule.FileName; } }
        /// 自动获取桌面目录
        private string desktopPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); } }
        /// 设置开机自动启动-只需要调用改方法就可以了参数里面的bool变量是控制开机启动的开关的，默认为开启自启启动
        /// <param name="onOff">自启开关</param>
        public void SetMeAutoStart(bool onOff = true)//调用此函数实现自启动
        {
            if (onOff)//开机启动
            {
                //获取启动路径应用程序快捷方式的路径集合
                List<string> shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                //存在2个以快捷方式则保留一个快捷方式-避免重复多于
                if (shortcutPaths.Count >= 2)
                {
                    for (int i = 1; i < shortcutPaths.Count; i++)
                    {
                        DeleteFile(shortcutPaths[i]);
                    }
                }
                else if (shortcutPaths.Count < 1)//不存在则创建快捷方式
                {
                    CreateShortcut(systemStartPath, QuickName, appAllPath, "中吉售货机");
                }
            }
            else//开机不启动
            {
                //获取启动路径应用程序快捷方式的路径集合
                List<string> shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                //存在快捷方式则遍历全部删除
                if (shortcutPaths.Count > 0)
                {
                    for (int i = 0; i < shortcutPaths.Count; i++)
                    {
                        DeleteFile(shortcutPaths[i]);
                    }
                }
            }
            //创建桌面快捷方式-如果需要可以取消注释
            //CreateDesktopQuick(desktopPath, QuickName, appAllPath);
        }

        /// <summary>
        ///  向目标路径创建指定文件的快捷方式
        /// </summary>
        /// <param name="directory">目标目录</param>
        /// <param name="shortcutName">快捷方式名字</param>
        /// <param name="targetPath">文件完全路径</param>
        /// <param name="description">描述</param>
        /// <param name="iconLocation">图标地址</param>
        /// <returns>成功或失败</returns>
        private bool CreateShortcut(string directory, string shortcutName, string targetPath, string description = null, string iconLocation = null)
        {
            try
            {
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);                         //目录不存在则创建
                //添加引用 Com 中搜索 Windows Script Host Object Model
                string shortcutPath = Path.Combine(directory, string.Format("{0}.lnk", shortcutName));          //合成路径
                WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);    //创建快捷方式对象
                shortcut.TargetPath = targetPath;                                                               //指定目标路径
                shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);                                  //设置起始位置
                shortcut.WindowStyle = 1;                                                                       //设置运行方式，默认为常规窗口
                shortcut.Description = description;                                                             //设置备注
                shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;    //设置图标路径
                shortcut.Save();                                                                                //保存快捷方式
                return true;
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
                temp = "";
            }
            return false;
        }

        /// <summary>
        /// 获取指定文件夹下指定应用程序的快捷方式路径集合
        /// </summary>
        /// <param name="directory">文件夹</param>
        /// <param name="targetPath">目标应用程序路径</param>
        /// <returns>目标应用程序的快捷方式</returns>
        private List<string> GetQuickFromFolder(string directory, string targetPath)
        {
            List<string> tempStrs = new List<string>();
            tempStrs.Clear();
            string tempStr = null;
            string[] files = Directory.GetFiles(directory, "*.lnk");
            if (files == null || files.Length < 1)
            {
                return tempStrs;
            }
            for (int i = 0; i < files.Length; i++)
            {
                //files[i] = string.Format("{0}\\{1}", directory, files[i]);
                tempStr = GetAppPathFromQuick(files[i]);
                if (tempStr == targetPath)
                {
                    tempStrs.Add(files[i]);
                }
            }
            return tempStrs;
        }

        /// <summary>
        /// 获取快捷方式的目标文件路径-用于判断是否已经开启了自动启动
        /// </summary>
        /// <param name="shortcutPath"></param>
        /// <returns></returns>
        private string GetAppPathFromQuick(string shortcutPath)
        {
            //快捷方式文件的路径 = @"d:\Test.lnk";
            if (System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortct = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                //快捷方式文件指向的路径.Text = 当前快捷方式文件IWshShortcut类.TargetPath;
                //快捷方式文件指向的目标目录.Text = 当前快捷方式文件IWshShortcut类.WorkingDirectory;
                return shortct.TargetPath;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 根据路径删除文件-用于取消自启时从计算机自启目录删除程序的快捷方式
        /// </summary>
        /// <param name="path">路径</param>
        private void DeleteFile(string path)
        {
            FileAttributes attr = System.IO.File.GetAttributes(path);
            if (attr == FileAttributes.Directory)
            {
                Directory.Delete(path, true);
            }
            else
            {
                System.IO.File.Delete(path);
            }
        }

        /// <summary>
        /// 在桌面上创建快捷方式-如果需要可以调用
        /// </summary>
        /// <param name="desktopPath">桌面地址</param>
        /// <param name="appPath">应用路径</param>
        public void CreateDesktopQuick(string desktopPath = "", string quickName = "", string appPath = "")
        {
            List<string> shortcutPaths = GetQuickFromFolder(desktopPath, appPath);
            //如果没有则创建
            if (shortcutPaths.Count < 1)
            {
                CreateShortcut(desktopPath, quickName, appPath, "软件描述");
            }
        }
        //创建控件1：听声音选择答案
        public myMP3Player.UserControl1 creatControl1(string a,string b,string c,string d,string e,Point p)
        {
            myMP3Player.UserControl1 us1 = new myMP3Player.UserControl1(a,b,c,d,e);
            us1.Location = p;
            return us1;
        }
        //创建控件2：看英语单词填中文
        public myMP3Player.UserControl2 creatControl2(string a, string b, Point p)
        {
            myMP3Player.UserControl2 us2 = new myMP3Player.UserControl2(a,b);
            us2.Location = p;
            return us2;
        }
        //创建控件3：看图识单词
        public myMP3Player.UserControl3 creatControl3(string a,string b,string c,Point p)
        {
            myMP3Player.UserControl3 us3 = new myMP3Player.UserControl3(a,b,c);
            us3.Location = p;
            return us3;
        }      
        List<myMP3Player.UserControl1> myControl1 = new List<myMP3Player.UserControl1>();
        List<myMP3Player.UserControl2> myControl2 = new List<myMP3Player.UserControl2>();
        List<myMP3Player.UserControl3> myControl3 = new List<myMP3Player.UserControl3>();
 
        private void Form1_Load(object sender, EventArgs e)
        {
                SetMeAutoStart(true);//调用函数实现开机自启动     
            //使用钩子，屏蔽ALT+F4
                IntPtr hMenu = GetSystemMenu(this.Handle, 0);
                EnableMenuItem(hMenu, SC_CLOSE, MF_DISABLED | MF_GRAYED);
              int myWidth = this.Width / 5;
              int myHeight= this.Height / 3;
              FileStream fs = new FileStream(@"..\..\..\单词信息.txt", FileMode.Open);//读取文件获得单词信息
              Encoding encode = Encoding.GetEncoding("GB2312");
              StreamReader sr = new StreamReader(fs,encode);
              ArrayList al = new ArrayList();
              string[] words;
              string s;
              int j = -1;
              while((s=sr.ReadLine())!=null)
              {
                  j++;
                  words = s.Split(' ');
                  if (j<5)//添加第一种控件
                  {                
                  myMP3Player.UserControl1 us = creatControl1(words[0], words[1], words[2], words[3],words[4],
                 new Point(myWidth * j, 0));
                      myControl1.Add(us);
                  this.Controls.Add(us);                
                  }
                  if(j>4&&j<10)//添加第二种控件
                {
                      myMP3Player.UserControl2 us = creatControl2(words[0],words[1],
          new Point(myWidth * (j-5), myHeight));
                      myControl2.Add(us);
                      this.Controls.Add(us);
                  }
                  if(j>9&&j<15)//添加第三种控件
                {
                      myMP3Player.UserControl3 us = creatControl3(words[0],words[2],words[1],
   new Point(myWidth * (j - 10), myHeight*2));
                      myControl3.Add(us);
                      this.Controls.Add(us);
                  }
              }         
        }
             public bool isAllRight1;
             public bool isAllRight2;
             public bool isAllRight3;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            isAllRight1 = myControl1.All(p=>p.IsRight==true);//第一种控件的所有实例的IsRight属性是否为True
            isAllRight2 = myControl2.All(p => p.IsRight == true);//第二种
            isAllRight3 = myControl3.All(p => p.IsRight == true);//第三种
            if (isAllRight1 == true&& isAllRight2==true&& isAllRight3==true)
            {
                timer1.Enabled = false;
                MessageBox.Show("你已经答对全部单词,将进入系统", "恭喜！");                 
                this.Close();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F4) && (e.Alt == true))  //屏蔽ALT+F4，先把Form1的KeyPreview属性置为True（弃用）
            {
               // e.Handled = true;
            }
        }
    }
}
