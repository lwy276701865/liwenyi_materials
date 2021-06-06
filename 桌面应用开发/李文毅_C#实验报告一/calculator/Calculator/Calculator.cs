using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace calculator
{
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        public int numClick = 0;//点击数字次数
        public int numOperator = 0;//点击运算符次数
        public int count = 0;//累加用于保存运算过程中出现的数字
        public char symbol = ' ';//运算符
        public double[] num = new double[100];
        public string[] tempNum = new string[100];
        public bool isDirectHitOperator = false;//是否直接点击运算符，默认为：否
        public bool isHaveSymbolOrNumber = true;//是否有运算符或被操作数
        public bool isContinue = true;//是否继续运算
        public bool isMoving = false;//是否移动

        public void firstHitNumber()//首次点击数字
        {
            numClick++;//点击数字次数+1
            if (numClick == 1)//点击数字次数为1且未直接点击运算符
            {
                lblResult.Text = null;
            }
        }

        //先点击数字，再点击运算符（可多次，仅保留最后一个运算符），再点击数字时，
        //在第一次点击运算符时会将isDirectHitOperator置为true；但不影响后面firstHitNumber()判断isDirectHitOperator的值

        public void clearOperator()//清除多余运算符，仅保留最后一个运算符
        {
            numOperator++;
            if (numOperator == 1)//点击运算符次数为1
            {
                isDirectHitOperator = true;//则直接点击运算符为：真
            }
            else if (numOperator >= 2)//点击运算符次数大于2次时只保留最后一个有效运算符
            {
                while (lblResult.Text.Last() == '+' || lblResult.Text.Last() == '-' ||
                lblResult.Text.Last() == '×' || lblResult.Text.Last() == '÷')
                {
                    lblResult.Text = lblResult.Text.TrimEnd(new char[] { '+', '-', '×', '÷' });
                }
            }
        }

        private void calculator_Load(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            toolTip1.SetToolTip(picClose, "关闭");
            toolTip1.SetToolTip(picMinisize, "最小化");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "0";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += "9";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                firstHitNumber();
                lblResult.Text += ".";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                symbol = '+';
                clearOperator();
                if (count == 0)
                {
                    tempNum[0] = lblResult.Text;
                    numClick++;//默认被加数为0
                }
                lblResult.Text = tempNum[count] + symbol;
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                symbol = '-';
                clearOperator();
                if (count == 0)
                {
                    tempNum[0] = lblResult.Text;
                    numClick++;//默认被减数为0
                }
                lblResult.Text = tempNum[count] + symbol;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                symbol = '×';
                clearOperator();
                if (count == 0)
                {
                    tempNum[0] = lblResult.Text;
                    numClick++;//默认被乘数为0
                }
                lblResult.Text = tempNum[count] + symbol;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                symbol = '÷';
                clearOperator();
                if (count == 0)
                {
                    tempNum[0] = lblResult.Text;
                    numClick++;//默认被除数为0
                }
                lblResult.Text = tempNum[count] + symbol;
            }
        }

        private void btnEliminate_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            numClick = 0;//点击数字次数
            symbol = ' ';//运算符
            count = 0;
            numOperator = 0;//点击运算符次数
            Array.Clear(num, 0, num.Length);
            Array.Clear(tempNum, 0, tempNum.Length);
            isContinue = true;//是否继续运算
            isDirectHitOperator = false;//是否直接点击运算符
            isHaveSymbolOrNumber = true;//是否有运算符或被操作数

            lblResult.Font = new System.Drawing.Font("DS-Digital", 18);
            lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (isContinue == true && !lblResult.Text.Contains('+')&& !lblResult.Text.Contains('-')&& 
            !lblResult.Text.Contains('×')&& !lblResult.Text.Contains('÷'))
            {
                lblResult.Text = (-double.Parse(lblResult.Text)).ToString();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (isContinue)
            {
                count++;
                tempNum[count] = lblResult.Text.Replace(tempNum[count - 1] + symbol, "");

                if (symbol == ' ' || lblResult.Text.Replace(tempNum[count - 1], "").Contains('=')||
                lblResult.Text.Replace(tempNum[count - 1] + symbol, "").Contains('+')||
                lblResult.Text.Replace(tempNum[count - 1] + symbol, "").Contains('-')||
                lblResult.Text.Replace(tempNum[count - 1] + symbol, "").Contains('×')||
                lblResult.Text.Replace(tempNum[count - 1] + symbol, "").Contains('÷'))//运算符为空格||第二次及以上运算时无运算符
                {
                    isContinue = false;
                    isHaveSymbolOrNumber = false;
                    string fontFamily = "DS-Digital";
                    lblResult.Font = new System.Drawing.Font(fontFamily, 20);
                    lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblResult.Text = "请正确输入运算符和运算数";
                }

                if (tempNum[count] == "")//无被操作数直接点击等于符号
                {
                    isContinue = false;
                    isHaveSymbolOrNumber = false;
                    lblResult.Font = new System.Drawing.Font("DS-Digital", 26);
                    lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    if (symbol == '+')
                    {
                        lblResult.Text = "请输入加数";
                    }
                    else if (symbol == '-')
                    {
                        lblResult.Text = "请输入减数";
                    }
                    else if (symbol == '×')
                    {
                        lblResult.Text = "请输入乘数";
                    }
                    else if (symbol == '÷')
                    {
                        lblResult.Text = "请输入除数";
                    }
                }

                if (tempNum[count - 1].Contains('+'))
                {
                    isContinue = false;
                    isHaveSymbolOrNumber = false;
                    string fontFamily = "DS-Digital";
                    lblResult.Font = new System.Drawing.Font(fontFamily, 20);
                    lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblResult.Text = "请正确输入运算符和运算数";
                }

                if (isHaveSymbolOrNumber == true)
                {
                    lblResult.Text = tempNum[count - 1] + symbol + tempNum[count];
                    lblResult.Text += "=";
                    num[count - 1] = double.Parse(tempNum[count - 1]);
                    num[count] = double.Parse(tempNum[count]);

                    switch (symbol)
                    {
                        case '+':
                            count++;
                            tempNum[count] = (num[count - 2] + num[count - 1]).ToString();//保存计算结果到数组中以便继续下一次运算
                            lblResult.Text += tempNum[count];
                            break;
                        case '-':
                            count++;
                            tempNum[count] = (num[count - 2] - num[count - 1]).ToString();
                            lblResult.Text += tempNum[count];
                            break;
                        case '×':
                            count++;
                            tempNum[count] = (num[count - 2] * num[count - 1]).ToString();
                            lblResult.Text += tempNum[count];
                            break;
                        case '÷':
                            count++;
                            tempNum[count] = (num[count - 2] / num[count - 1]).ToString();
                            lblResult.Text += tempNum[count];
                            break;
                    }
                }
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            //鼠标移动进入，变为红色
            picClose.BackColor = Color.Red;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            //鼠标移动离开，变为透明
            picClose.BackColor = Color.FromArgb(228, 227, 226);
        }

        private void picMinisize_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(50, 255, 255, 255);
        }

        private void picMinisize_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(228, 227, 226);
        }

        private void frmCalculator_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        public Point pMouseDown;
        private void frmCalculator_MouseDown(object sender, MouseEventArgs e)
        {
            pMouseDown = e.Location;
            if(e.Button==System.Windows.Forms.MouseButtons.Left)
            {
                isMoving = true;
            }
        }

        private void frmCalculator_MouseMove(object sender, MouseEventArgs e)
        {
            //窗体位置跟着鼠标位置移动
            //this.Location=Mouse.Location
            if (isMoving)
            {
                this.Location = new Point(this.Location.X + e.X - pMouseDown.X,
                    this.Location.Y + e.Y - pMouseDown.Y);
            }
        }
    }
}