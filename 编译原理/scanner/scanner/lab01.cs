using System;
using System.IO;

namespace scanner_my
{
    //记号类别号
    enum Token_Type
    {
        ORIGIN, SCALE, ROT, IS, TO, //语言保留字(一字一类别)
        STEP, DRAW, FOR, FROM,      //语言保留字
        T,                          //语言中唯一的变量
        ID,                         //标识符(若把关键字、变量都看成一种单词，可以使用本类别)

        SEMICO, L_BRACKET, R_BRACKET, COMMA, //分隔符(分号、左括号、右括号、逗号)
        PLUS, MINUS, MUL, DIV, POWER,        //运算符(加、减、乘、除、乘方)

        FUNC,                                //(语言提供的标准数学)函数

        CONST_ID,                           //数值常量
        ERRTOKEN,                           //错误单词
        NONTOKEN							//专用记号(单词序列结束)
    };

    //记号数据类型
    delegate double MathFunc(double d);//单参数的函数委托类型
    struct Token
    {
        public Token_Type type; 			//类别号
        public string lexeme;				//标识符的字符串
        public double value;				//数值常数的值
        public MathFunc func; 	            //函数委托

        public Token(Token_Type type = Token_Type.NONTOKEN, string lexeme = "", double value = 0, MathFunc func = null)
        {
            this.type = type;
            this.lexeme = lexeme;
            this.value = value;
            this.func = func;
        }
    }

    class Program
    {
        // 预定义单词表
        static Token[] TokenTab = {
            //符号常数
            new Token(Token_Type.CONST_ID,  "PI",       3.1415926,  null),
            new Token(Token_Type.CONST_ID,  "E",        2.71828,    null),
            //变量(惟一的)
            new Token(Token_Type.T,         "T",        0.0,        null),
            //数学函数
            new Token(Token_Type.FUNC,      "SIN",      0.0,        Math.Sin),
            new Token(Token_Type.FUNC,      "COS",      0.0,        Math.Cos),
            new Token(Token_Type.FUNC,      "TAN",      0.0,        Math.Tan),
            new Token(Token_Type.FUNC,      "LN",       0.0,        Math.Log),
            new Token(Token_Type.FUNC,      "EXP",      0.0,        Math.Exp),
            new Token(Token_Type.FUNC,      "SQRT",     0.0,        Math.Sqrt),
            //语句关键字
            new Token(Token_Type.ORIGIN,    "ORIGIN",   0.0,        null),
            new Token(Token_Type.SCALE,     "SCALE",    0.0,        null),
            new Token(Token_Type.ROT,       "ROT",      0.0,        null),
            new Token(Token_Type.IS,        "IS",       0.0,        null),
            new Token(Token_Type.FOR,       "FOR",      0.0,        null),
            new Token(Token_Type.FROM,      "FROM",     0.0,        null),
            new Token(Token_Type.TO,        "TO",       0.0,        null),
            new Token(Token_Type.STEP,      "STEP",     0.0,        null),
            new Token(Token_Type.DRAW,      "DRAW",     0.0,        null)
        };
        static Token ErrorToken = new Token(Token_Type.ERRTOKEN, "error token", -1, null);

        //c# 无 ungetc 函数（将一个字符退回输入流），所以用如下代码模拟
        static char lastCh;
        static bool ungetFlag = false;
        //读取一个字符
        static char getChar(StreamReader sr)
        {
            if (!ungetFlag)
            {
                lastCh = (char)sr.Read();
            }
            else
                ungetFlag = false;

            return lastCh;
        }
        //退回一个字符
        static void ungetChar(StreamReader sr)
        {
            ungetFlag = true;
        }
        //c 语言的 ungetc 函数，在 c# 中的模拟

        //判断标识符是否语言的预定义单词
        static Token IsKeyWords(string id)
        {
            int i;
            Token token = new Token();

            for (i = 0; i < TokenTab.Length; i++) if (string.Equals(TokenTab[i].lexeme, id)) break;

            if (i < TokenTab.Length)
                token = TokenTab[i];
            else
                token = ErrorToken;

            return token;
        }

        //显示单词
        static void writeToken(Token token)
        {
            if (token.type == Token_Type.FUNC)
                Console.WriteLine("{0,-15}{1, -15}{2, -15}{3, -20}", (int)token.type, token.lexeme, token.value, (string)token.func.Method.Name);
            else
                Console.WriteLine("{0,-15}{1, -15}{2, -15}{3, -20}", (int)token.type, token.lexeme, token.value, "");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("{0,-11}{1, -12}{2, -12}{3, -20}", "记号类别", "字符串", "常数值", "函数指针");
            Console.WriteLine("-------------------------------------------------------");

            //打开源代码文件
            StreamReader sr;
            if (args.Length == 0)
            {
                sr = File.OpenText("scantest.txt");//文件必须放在项目的子目录 bin\debug 下
            }
            else
            {
                sr = File.OpenText(args[0].ToString());//允许通过命令行参数，给出源代码文件名
            }

            //从源代码文件中逐个读取字符
            Token token;
            char c, preCh;
            GetToken(sr, out token, out c, out preCh);
            writeToken(token);//输出结束记号
            sr.Close();//关闭文件
            Console.ReadLine();
        }

        private static void GetToken(StreamReader sr, out Token token, out char c, out char preCh)
        {
            preCh = char.MinValue;//char的空值
            while (true)
            {
                c = getChar(sr);//读取字符
                //消除注释内容
                if (c == '-' || c == '/')
                {	//当前输入字符是 - 或 /，说明可能遇到注释引导符了
                    preCh = c;		//暂存已读字符
                    c = getChar(sr);//读取新字符
                    if (c == preCh)
                    {	//新字符 = 已读字符：是注释引导 -- 或 //
                        //逐一读入注释文本（以换行符或文件终止符为结束），不作任何处理，即忽略掉注释
                        while (c != '\n' && !sr.EndOfStream) c = getChar(sr);

                    }
                    else
                    {			//新字符 ≠ 已读字符：不是注释引导
                        ungetChar(sr);//将多读的这个字符退回输入流
                        c = preCh;	  //恢复为暂存字符（暂存的 - 或 / 是运算符，需作为记号处理）
                    }
                }
                if (sr.EndOfStream)//文件读取结束，添加一个结束单词
                {
                    token = new Token(Token_Type.NONTOKEN);
                    break;
                }

                if (c == '\t' || c == '\n' || c == '\r' || c == ' ') continue;//过滤空白字符(\t：制表符，\n：换行符，\r：回车符，空格)

                if (c == '+')
                {			//加号
                    token = new Token(Token_Type.PLUS, "+");

                }
                else if (c == ',')
                {			//逗号
                    token = new Token(Token_Type.COMMA, ",");

                }
                else if (c == ';')
                {			//分号
                    token = new Token(Token_Type.SEMICO, ";");

                }
                else if (c == '(')
                {			//左括号
                    token = new Token(Token_Type.L_BRACKET, "(");

                }
                else if (c == ')')
                {			//右括号
                    token = new Token(Token_Type.R_BRACKET, ")");

                }
                else if (c == '-')
                {			//减号
                    token = new Token(Token_Type.MINUS, "-");

                }
                else if (c == '/')
                {	//除号
                    token = new Token(Token_Type.DIV, "/");

                }
                else if (c == '*')
                {		//当前输入字符是 *，说明已读出乘号或遇到乘方算符的首字母
                    preCh = c;					//暂存已读的 *
                    c = getChar(sr);//读取新字符

                    if (c == preCh)
                    {		//多读的字符也是 *，说明已读出了乘方算符
                        token = new Token(Token_Type.POWER, "**");

                    }
                    else
                    {				//多读的字符不是 *，说明仅仅是乘号
                        ungetChar(sr);	//将多读的字符退回输入流
                        token = new Token(Token_Type.MUL, "*");
                    }

                }
                else if (char.IsLetter(c))
                {	//当前输入字符是字母，说明可能遇到了标识符的首字母
                    string buf = ""; //初始化临时串
                    buf = buf + char.ToUpper(c);//首字母转换为大写，存入临时串

                    //循环读取后续字符
                    for (; ; )
                    {
                        c = getChar(sr);//读取新字符
                        if (char.IsLetterOrDigit(c))
                        {	//读入字符仍是字母/数字，说明还在标识符中                            
                            buf = buf + char.ToUpper(c);//读入字符连接到临时串

                        }
                        else         //读入字符不再是字母/数字，说明标识符已读完，并且多读了一个不属于标识符的输入
                            break;
                    }
                    ungetChar(sr);	//将多读的字符退回输入流

                    token = IsKeyWords(buf);
                    //token = new Token(Token_Type.ID, buf);

                }
                else if (char.IsDigit(c))
                {	//当前输入字符是数字，说明遇到了数值常量的首个数字字母
                    string buf = ""; //初始化临时串
                    buf = buf + c;//首数字存入临时串

                    //逐个字符处理数值常量的整数部分
                    for (; ; )
                    {
                        c = getChar(sr);//读取新字符
                        if (char.IsDigit(c))
                            //读入的仍然是数字
                            buf = buf + c;//数字存入临时串
                        else
                            break;
                    }
                    if (c == '.')
                    {		//读入字符= .，说明遇到数值常量的小数部分
                        buf = buf + c;//小数点连接到临时串后
                        //逐个字符处理数值常量的小数部分
                        for (; ; )
                        {
                            c = getChar(sr);//读取新字符
                            if (char.IsDigit(c))
                                //读入的仍然是数字
                                buf = buf + c;//数字存入临时串
                            else
                                break;
                        }
                    }
                    ungetChar(sr);//将多读的、不属于数值常量的字符，退回输入流

                    token = new Token(Token_Type.CONST_ID, "", Convert.ToDouble(buf));//记号值=临时串转换成的浮点数
                }
                else
                    token = ErrorToken;

                //Console.Write(c);
                writeToken(token);//输出单词

            }
        }
    }
}
