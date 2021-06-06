using System;
using System.IO;

namespace HCScanner
{
    #region 全局数据

    //******单词的类别编号
    enum Token_Type
    {
        ORIGIN, SCALE, ROT, IS, TO, //语言保留字(一字一类别)
        STEP, DRAW, FOR, FROM, 		//语言保留字
        T, 							//语言中唯一的变量

        SEMICO, L_BRACKET, R_BRACKET, COMMA, //分隔符(分号、左括号、右括号、逗号)
        PLUS, MINUS, MUL, DIV, POWER, 		 //运算符(加、减、乘、除、乘方)

        FUNC, 								 //(语言提供的标准数学)函数

        CONST_ID, 							//数值常量
        ERRTOKEN,							//错误单词
        NONTOKEN							//专用记号(单词序列结束)
    };

    //******记号（token）的数据类型（记录单词识别信息）
    delegate double MathFunc(double d);//单参数的函数委托类型
    struct Token
    {
        public Token_Type type; 			//单词类别号
        public string lexeme;				//单词文本
        public double value;				//常数的值
        public MathFunc func; 	            //函数的委托

        public Token(Token_Type type = Token_Type.NONTOKEN, string lexeme = "NONTOKEN", double value = 0, MathFunc func = null)
        {
            this.type = type;
            this.lexeme = lexeme;
            this.value = value;
            this.func = func;
        }
    }

    #endregion

    class Scanner
    {
        #region 内部数据
        
        // 预定义单词表(包含语言允许的全部标识符)
        static Token[] TokenTab = {
            //符号常数
            new Token(Token_Type.CONST_ID,  "PI",		3.1415926,	null),
            new Token(Token_Type.CONST_ID,  "E",		2.71828,	null),
            //变量(惟一的)
            new Token(Token_Type.T,			"T",		0.0,		null),
            //数学函数
            new Token(Token_Type.FUNC,		"SIN",		0.0,	    Math.Sin),
            new Token(Token_Type.FUNC,		"COS",		0.0,		Math.Cos),
            new Token(Token_Type.FUNC,		"TAN",		0.0,		Math.Tan),
            new Token(Token_Type.FUNC,		"LN",		0.0,		Math.Log),
            new Token(Token_Type.FUNC,		"EXP",		0.0,		Math.Exp),
            new Token(Token_Type.FUNC,		"SQRT",		0.0,		Math.Sqrt),
            //语句关键字
            new Token(Token_Type.ORIGIN,	"ORIGIN",	0.0,		null),
            new Token(Token_Type.SCALE,		"SCALE",	0.0,		null),
            new Token(Token_Type.ROT,		"ROT",		0.0,		null),
            new Token(Token_Type.IS,		"IS",		0.0,		null),
            new Token(Token_Type.FOR,		"FOR",		0.0,		null),
            new Token(Token_Type.FROM,		"FROM",		0.0,		null),
            new Token(Token_Type.TO,		"TO",		0.0,		null),
            new Token(Token_Type.STEP,		"STEP",		0.0,		null),
            new Token(Token_Type.DRAW,		"DRAW",		0.0,		null)
        };

        static Token ErrorToken = new Token(Token_Type.ERRTOKEN, "ERRTOKEN", -1, null);//错误单词
        #endregion

        #region 辅助函数

        #region //因为 c# 无 ungetc 函数（将一个字符退回输入流），以下代码模拟了 getc、ungetc 两个函数的功能

        static char lastCh;//上一个字符
        static bool ungetFlag = false;//回退标志
        //********读取一个字符
        static char getChar(StreamReader sr)
        {
            if (!ungetFlag)
            {
                lastCh = (char)sr.Read();//若回退标志为假，则读取新字符
            }
            else
                ungetFlag = false;//若回退标志为真，不进行读操作，直接使用上一个字符

            return lastCh;
        }
        //********退回一个字符
        static void ungetChar(StreamReader sr)
        {
            ungetFlag = true;//回退标志设为真
        }
        #endregion

        //********判断标识符是否语言的预定义单词
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

        //********显示单词
        public static void writeToken(Token token)
        {
            if (token.type == Token_Type.FUNC)
                Console.WriteLine("{0,-15}{1, -15}{2, -15}{3, -20}", (int)token.type, token.lexeme, "", (string)token.func.Method.Name);
            else if (token.type == Token_Type.CONST_ID)
                Console.WriteLine("{0,-15}{1, -15}{2, -15}", (int)token.type, token.lexeme, token.value);
            else
                Console.WriteLine("{0,-15}{1, -15}", (int)token.type, token.lexeme);
        }

        #endregion

        #region 接口(方法：GetToken 获取单词)

        //********获取单词(公有静态成员函数)
        public static Token GetToken(StreamReader sr) 
        {
            char c, preCh;//c 新字符，preCh 上一个字符

            //从输入流中，逐个读入源代码字符
            while (true)
            {
                c = getChar(sr);//读取新字符

                #region 过滤行注释
                //当前输入字符是 - 或 /，说明可能遇到注释引导符了
                if (c == '-' || c == '/'){
                    preCh = c;		//暂存已读字符
                    c = getChar(sr);//读取新字符
                    if (c == preCh){	//新字符 = 已读字符：是注释引导 -- 或 //
                        //逐一读入注释文本（以换行符或文件终止符为结束），不作任何处理，即忽略掉注释
                        while (c != '\n' && !sr.EndOfStream) c = getChar(sr);

                    }else{			//新字符 ≠ 已读字符：不是注释引导
                        ungetChar(sr);//将多读的这个字符退回输入流
                        c = preCh;	  //恢复为暂存字符（暂存的 - 或 / 是运算符，需作为记号处理）
                    }
                }
                #endregion

                //过滤空白符
                if (c == '\t' || c == '\n' || c == '\r' || c == ' ') continue;//\t：制表符，\n：换行符，\r：回车符，空格

                #region 识别标点符号
                if (c == ',')return new Token(Token_Type.COMMA, ",");//逗号
                
                if (c == ';')return new Token(Token_Type.SEMICO, ";");//分号
                
                if (c == '(')return new Token(Token_Type.L_BRACKET, "(");//左括号                   
                
                if (c == ')')return new Token(Token_Type.R_BRACKET, ")");//右括号                    
                #endregion

                #region 识别运算符
                if (c == '+') return new Token(Token_Type.PLUS, "+");//加号

                if (c == '-') return new Token(Token_Type.MINUS, "-");//减号                    
                
                if (c == '/')return new Token(Token_Type.DIV, "/");//除号
                    
                if (c == '*'){		//当前输入字符是 *，说明已读出乘号或遇到乘方算符的首字母
                    preCh = c;					//暂存已读的 *
                    c = getChar(sr);//读取新字符

                    //多读的字符也是 *，说明已读出了乘方算符
                    if (c == preCh) return new Token(Token_Type.POWER, "**");

                    //多读的字符不是 *，说明仅仅是乘号
                    ungetChar(sr);	//将多读的字符退回输入流
                    return new Token(Token_Type.MUL, "*");
                }
                #endregion

                #region 识别标识符
                if (char.IsLetter(c)){	//当前输入字符是字母，说明可能遇到了标识符的首字母
                    string buf = ""; //初始化临时串
                    buf = buf + char.ToUpper(c);//首字母转换为大写，存入临时串

                    //循环读取后续字符
                    for (; ; ){
                        c = getChar(sr);//读取新字符
                        if (char.IsLetterOrDigit(c)){	//读入字符仍是字母/数字，说明还在标识符中                            
                            buf = buf + char.ToUpper(c);//读入字符连接到临时串
                        }else         //读入字符不再是字母/数字，说明标识符已读完，并且多读了一个不属于标识符的输入
                            break;
                    }
                    ungetChar(sr);	//将多读的字符退回输入流

                    return IsKeyWords(buf);//判断是否语言的保留字(因本语言不允许自定义标识符，若不是保留字，就出错)
                    //return new Token(Token_Type.ID, buf);

                }
                #endregion

                #region 识别常数
                if (char.IsDigit(c)){	//当前输入字符是数字，说明遇到了常数的首个(数字)字母
                    string buf = ""; //初始化临时串
                    buf = buf + c;//首字母连接入临时串

                    //逐个字符处理常数的整数部分
                    for (; ; ){
                        c = getChar(sr);//读取新字符
                        if (char.IsDigit(c))//读入的仍然是数字字母
                            buf = buf + c;//字母连接入临时串
                        else
                            break;//jump out for
                    }

                    if (c == '.'){		//读入字符是 .，说明遇到了常数的小数部分
                        buf = buf + c;//小数点连接入临时串

                        //逐个字符处理常数的小数部分
                        for (; ; ){
                            c = getChar(sr);//读取新字符
                            if (char.IsDigit(c))//读入的仍然是数字字母
                                buf = buf + c;//字母连接入临时串
                            else
                                break;//jump out for
                        }
                    }
                    ungetChar(sr);//将多读的、不属于常数的(非数字字母的)字符，退回输入流

                    return new Token(Token_Type.CONST_ID, "CONST_ID", Convert.ToDouble(buf));//临时串->浮点数=(常数)单词的值

                }
                #endregion

                //文件读取结束，添加一个结束单词
                if (sr.EndOfStream) return new Token(Token_Type.NONTOKEN);

                return ErrorToken;//若新字符不在以上语言允许的单词类别中，则出错

            }//end while

        }//GetToken 结束

        #endregion

    }//end class
}
