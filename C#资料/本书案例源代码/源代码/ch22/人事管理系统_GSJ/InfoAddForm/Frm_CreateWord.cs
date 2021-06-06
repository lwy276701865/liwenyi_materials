using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.IO;
namespace 人事管理系统_GSJ
{
    public partial class Frm_CreateWord : Form
    {
        public Frm_CreateWord()
        {
            InitializeComponent();
        }
        private string stuId;

        public string StuId//当前选中的员工编号
        {
            get { return stuId; }
            set { stuId = value; }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            # region 产生sql语句
                        StringBuilder sqlSB=new StringBuilder("select Stu_id," +
                                                            "StuffName   ," +
                                                            "Folk   ," +
                                                            "Birthday   ," +
                                                            "Age   ," +
                                                            "Kultur   ," +
                                                            "Marriage    ," +
                                                            "Sex    ," +
                                                            "Visage    ," +
                                                            "IDCard    ," +
                                                            "WorkDate    ," +
                                                            "WorkLength    ," +
                                                            "Employee    ," +
                                                            "Business    ," +
                                                            "Laborage    ," +
                                                            "Branch    ," +
                                                            "Duthcall    ," +
                                                            "Phone    ," +
                                                            "Handset    ," +
                                                            "School    ," +
                                                            "Speciality    ," +
                                                            "GraduateDate    ," +
                                                            "Address    ," +
                                                            "Photo    ," +
                                                            "BeAware    ," +
                                                            "City    ," +
                                                            "M_Pay    ," +
                                                            "Bank    ," +
                                                            "Pact_B    ," +
                                                            "Pact_E    ," +
                                                            "Pact_Y " +
                                                            "from tb_Stuffbusic ");
                        if (rbn_one.Checked)//判断是单个还是全部
                        {
                            sqlSB.Append(" where Stu_id ='" + StuId + "'");
                        }
            #endregion
            DataSet MyDS_Grid;
            #region 读取数据
            try
            {
                MyDBControls.GetConn();
                MyDS_Grid = MyDBControls.GetDataSet(sqlSB.ToString());
                MyDBControls.CloseConn();
            }
            catch 
            {

                MessageBox.Show("数据读取出错，导出失败！");
                return;
            } 
            #endregion
            object Nothing = System.Reflection.Missing.Value;
            object missing = System.Reflection.Missing.Value;
            //创建Word文档
            Word.Application wordApp = new Word.ApplicationClass();
            Word.Document wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordApp.Visible = true;

            //设置文档宽度
            wordApp.Selection.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2"));
            wordApp.ActiveWindow.ActivePane.HorizontalPercentScrolled = 11;
            wordApp.Selection.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2"));

            Object start = Type.Missing;
            Object end = Type.Missing;

            PictureBox pp = new PictureBox();   //新建一个PictureBox控件
            int p1 = 0;
            for (int i = 0; i < MyDS_Grid.Tables[0].Rows.Count; i++)
            {
                try
                {
                    byte[] pic = (byte[])(MyDS_Grid.Tables[0].Rows[i][23]); //将数据库中的图片转换成二进制流
                    MemoryStream ms = new MemoryStream(pic);			//将字节数组存入到二进制流中
                    pp.Image = Image.FromStream(ms);   //二进制流Image控件中显示
                    pp.Image.Save(@"C:\22.bmp");    //将图片存入到指定的路径
                }
                catch
                {
                    p1 = 1;
                }
                object rng = Type.Missing;
                string strInfo = "职工基本信息表" + "(" + MyDS_Grid.Tables[0].Rows[i][1].ToString() + ")";
                start = 0;
                end = 0;
                wordDoc.Range(ref start, ref end).InsertBefore(strInfo);    //插入文本
                wordDoc.Range(ref start, ref end).Font.Name = "Verdana";    //设置字体
                wordDoc.Range(ref start, ref end).Font.Size = 20;   //设置字体大小
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中

                start = strInfo.Length;
                end = strInfo.Length;
                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车

                object missingValue = Type.Missing;
                object location = strInfo.Length; //如果location超过已有字符的长度将会出错。一定要比"明细表"串多一个字符
                Word.Range rng2 = wordDoc.Range(ref location, ref location);

                wordDoc.Tables.Add(rng2, 14, 6, ref missingValue, ref missingValue);
                wordDoc.Tables.Item(1).Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAtLeast;
                wordDoc.Tables.Item(1).Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));
                wordDoc.Tables.Item(1).Range.Font.Size = 10;
                wordDoc.Tables.Item(1).Range.Font.Name = "宋体";

                //设置表格样式
                wordDoc.Tables.Item(1).Borders.Item(Word.WdBorderType.wdBorderLeft).LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wordDoc.Tables.Item(1).Borders.Item(Word.WdBorderType.wdBorderLeft).LineWidth = Word.WdLineWidth.wdLineWidth050pt;
                wordDoc.Tables.Item(1).Borders.Item(Word.WdBorderType.wdBorderLeft).Color = Word.WdColor.wdColorAutomatic;
                wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐

                //第5行显示
                wordDoc.Tables.Item(1).Cell(1, 5).Merge(wordDoc.Tables.Item(1).Cell(5, 6));
                //第6行显示
                wordDoc.Tables.Item(1).Cell(6, 5).Merge(wordDoc.Tables.Item(1).Cell(6, 6));
                //第9行显示
                wordDoc.Tables.Item(1).Cell(9, 4).Merge(wordDoc.Tables.Item(1).Cell(9, 6));
                //第12行显示
                wordDoc.Tables.Item(1).Cell(12, 2).Merge(wordDoc.Tables.Item(1).Cell(12, 6));
                //第13行显示
                wordDoc.Tables.Item(1).Cell(13, 2).Merge(wordDoc.Tables.Item(1).Cell(13, 6));
                //第14行显示
                wordDoc.Tables.Item(1).Cell(14, 2).Merge(wordDoc.Tables.Item(1).Cell(14, 6));

                //第1行赋值
                wordDoc.Tables.Item(1).Cell(1, 1).Range.Text = "职工编号：";
                wordDoc.Tables.Item(1).Cell(1, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][0].ToString();
                wordDoc.Tables.Item(1).Cell(1, 3).Range.Text = "职工姓名：";
                wordDoc.Tables.Item(1).Cell(1, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][1].ToString();

                //插入图片

                if (p1 == 0)
                {
                    string FileName = @"C:\22.bmp";//图片所在路径
                    object LinkToFile = false;
                    object SaveWithDocument = true;
                    object Anchor = wordDoc.Tables.Item(1).Cell(1, 5).Range;    //指定图片插入的区域
                    //将图片插入到单元格中
                    wordDoc.Tables.Item(1).Cell(1, 5).Range.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                }
                p1 = 0;

                //第2行赋值
                wordDoc.Tables.Item(1).Cell(2, 1).Range.Text = "民族类别：";
                wordDoc.Tables.Item(1).Cell(2, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][2].ToString();
                wordDoc.Tables.Item(1).Cell(2, 3).Range.Text = "出生日期：";
                try
                {
                    wordDoc.Tables.Item(1).Cell(2, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][3]).ToShortDateString());
                }
                catch { wordDoc.Tables.Item(1).Cell(2, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][3]);
                //第3行赋值
                wordDoc.Tables.Item(1).Cell(3, 1).Range.Text = "年龄：";
                wordDoc.Tables.Item(1).Cell(3, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][4]);
                wordDoc.Tables.Item(1).Cell(3, 3).Range.Text = "文化程度：";
                wordDoc.Tables.Item(1).Cell(3, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][5].ToString();
                //第4行赋值
                wordDoc.Tables.Item(1).Cell(4, 1).Range.Text = "婚姻：";
                wordDoc.Tables.Item(1).Cell(4, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][6].ToString();
                wordDoc.Tables.Item(1).Cell(4, 3).Range.Text = "性别：";
                wordDoc.Tables.Item(1).Cell(4, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][7].ToString();
                //第5行赋值
                wordDoc.Tables.Item(1).Cell(5, 1).Range.Text = "政治面貌：";
                wordDoc.Tables.Item(1).Cell(5, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][8].ToString();
                wordDoc.Tables.Item(1).Cell(5, 3).Range.Text = "单位工作时间：";
                try
                {
                    wordDoc.Tables.Item(1).Cell(5, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[0][10]).ToShortDateString());
                }
                catch { wordDoc.Tables.Item(1).Cell(5, 4).Range.Text = ""; }
                //第6行赋值
                wordDoc.Tables.Item(1).Cell(6, 1).Range.Text = "籍贯：";
                wordDoc.Tables.Item(1).Cell(6, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][24].ToString();
                wordDoc.Tables.Item(1).Cell(6, 3).Range.Text = MyDS_Grid.Tables[0].Rows[i][25].ToString();
                wordDoc.Tables.Item(1).Cell(6, 4).Range.Text = "身份证：";
                wordDoc.Tables.Item(1).Cell(6, 5).Range.Text = MyDS_Grid.Tables[0].Rows[i][9].ToString();
                //第7行赋值
                wordDoc.Tables.Item(1).Cell(7, 1).Range.Text = "工龄：";
                wordDoc.Tables.Item(1).Cell(7, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][11]);
                wordDoc.Tables.Item(1).Cell(7, 3).Range.Text = "职工类别：";
                wordDoc.Tables.Item(1).Cell(7, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][12].ToString();
                wordDoc.Tables.Item(1).Cell(7, 5).Range.Text = "职务类别：";
                wordDoc.Tables.Item(1).Cell(7, 6).Range.Text = MyDS_Grid.Tables[0].Rows[i][13].ToString();
                //第8行赋值
                wordDoc.Tables.Item(1).Cell(8, 1).Range.Text = "工资类别：";
                wordDoc.Tables.Item(1).Cell(8, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][14].ToString();
                wordDoc.Tables.Item(1).Cell(8, 3).Range.Text = "部门类别：";
                wordDoc.Tables.Item(1).Cell(8, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][15].ToString();
                wordDoc.Tables.Item(1).Cell(8, 5).Range.Text = "职称类别：";
                wordDoc.Tables.Item(1).Cell(8, 6).Range.Text = MyDS_Grid.Tables[0].Rows[i][16].ToString();
                //第9行赋值
                wordDoc.Tables.Item(1).Cell(9, 1).Range.Text = "月工资：";
                wordDoc.Tables.Item(1).Cell(9, 2).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][26]);
                wordDoc.Tables.Item(1).Cell(9, 3).Range.Text = "银行账号：";
                wordDoc.Tables.Item(1).Cell(9, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][27].ToString();
                //第10行赋值
                wordDoc.Tables.Item(1).Cell(10, 1).Range.Text = "合同起始日期：";
                try
                {
                    wordDoc.Tables.Item(1).Cell(10, 2).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][28]).ToShortDateString());
                }
                catch { wordDoc.Tables.Item(1).Cell(10, 2).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][28]);
                wordDoc.Tables.Item(1).Cell(10, 3).Range.Text = "合同结束日期：";
                try
                {
                    wordDoc.Tables.Item(1).Cell(10, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][29]).ToShortDateString());
                }
                catch { wordDoc.Tables.Item(1).Cell(10, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][29]);
                wordDoc.Tables.Item(1).Cell(10, 5).Range.Text = "合同年限：";
                wordDoc.Tables.Item(1).Cell(10, 6).Range.Text = Convert.ToString(MyDS_Grid.Tables[0].Rows[i][30]);
                //第11行赋值
                wordDoc.Tables.Item(1).Cell(11, 1).Range.Text = "电话：";
                wordDoc.Tables.Item(1).Cell(11, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][17].ToString();
                wordDoc.Tables.Item(1).Cell(11, 3).Range.Text = "手机：";
                wordDoc.Tables.Item(1).Cell(11, 4).Range.Text = MyDS_Grid.Tables[0].Rows[i][18].ToString();
                wordDoc.Tables.Item(1).Cell(11, 5).Range.Text = "毕业时间：";
                try
                {
                    wordDoc.Tables.Item(1).Cell(11, 6).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][21]).ToShortDateString());
                }
                catch { wordDoc.Tables.Item(1).Cell(11, 6).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][21]);
                //第12行赋值
                wordDoc.Tables.Item(1).Cell(12, 1).Range.Text = "毕业学校：";
                wordDoc.Tables.Item(1).Cell(12, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][19].ToString();
                //第13行赋值
                wordDoc.Tables.Item(1).Cell(13, 1).Range.Text = "主修专业：";
                wordDoc.Tables.Item(1).Cell(13, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][20].ToString();
                //第14行赋值
                wordDoc.Tables.Item(1).Cell(14, 1).Range.Text = "家庭地址：";
                wordDoc.Tables.Item(1).Cell(14, 2).Range.Text = MyDS_Grid.Tables[0].Rows[i][22].ToString();

                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中

                //清除临时文件
                File.Delete(@"C:\22.bmp");
            }
            MessageBox.Show("导出成功!");
            this.Close();

        }
    }
}