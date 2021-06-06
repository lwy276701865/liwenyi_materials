using System;
using System.IO;

using HCScanner;//引入词法分析器的名字空间

namespace parser_my
{
    class Program
    {
        static Token token;
        static StreamReader sr;
        static void Main(string[] args)
        {
            //打开源代码文件
            if (args.Length == 0)
            {
                sr = File.OpenText("p89-8-10.draw");//文件必须放在项目的子目录 bin\debug 下
            }
            else
            {
                sr = File.OpenText(args[0].ToString());//允许通过命令行参数，给出源代码文件名
            }

            parse();

            Console.ReadLine();
  
        }

        #region 语法分析器

        //***********语法分析主程序
        public static void parse()
        {
            fetchToken();
            drawProgram();
        }

        #region 递归下降分析函数族

        //***** 非终结符：program
        static void drawProgram() 
        {
            Console.WriteLine("enter program");

            while (token.type != Token_Type.NONTOKEN)
            {
                statement();

                matchToken(Token_Type.SEMICO);
            }

            Console.WriteLine("leave program");
        }

        //******* 非终结符(语法单位)：statement(语句)
        static void statement()
        {
            Console.WriteLine("enter statement");

            switch (token.type)
            {
                case Token_Type.ORIGIN:
                    origin();
                    break;
                case Token_Type.SCALE:
                    scale();
                    break;
                case Token_Type.ROT:
                    rot();
                    break;
                case Token_Type.FOR:
                    drawfor();
                    break;
                default:
                    syntaxError(2,token);
                    break;
            }

            Console.WriteLine("leave statement");
        }

        //*************语法单位：origin
        static void origin()
        {
            Console.WriteLine("enter origin");

            matchToken(Token_Type.ORIGIN);
            matchToken(Token_Type.IS);
            matchToken(Token_Type.L_BRACKET);
            expression();
            matchToken(Token_Type.COMMA);
            expression();
            matchToken(Token_Type.R_BRACKET);

            Console.WriteLine("leave origin");
        }

        //*************语法单位：scale
        static void scale()
        {
            Console.WriteLine("enter scale");

            matchToken(Token_Type.SCALE);
            matchToken(Token_Type.IS);
            matchToken(Token_Type.L_BRACKET);
            expression();
            matchToken(Token_Type.COMMA);
            expression();
            matchToken(Token_Type.R_BRACKET);

            Console.WriteLine("leave scale");
        }

        //*************语法单位：rot
        static void rot()
        {
            Console.WriteLine("enter rot");

            matchToken(Token_Type.ROT);
            matchToken(Token_Type.IS);
            expression();

            Console.WriteLine("leave rot");
        }

        //*************语法单位：for
        static void drawfor()
        {
            Console.WriteLine("enter for");

            matchToken(Token_Type.FOR);
            matchToken(Token_Type.T);
            matchToken(Token_Type.FROM);
            expression();
            matchToken(Token_Type.TO);
            expression();
            matchToken(Token_Type.STEP);
            expression();
            matchToken(Token_Type.DRAW);
            matchToken(Token_Type.L_BRACKET);
            expression();
            matchToken(Token_Type.COMMA);
            expression();
            matchToken(Token_Type.R_BRACKET);
            
            Console.WriteLine("leave for");
        }

        #region 表达式文法
        //********** expression
        static void expression()
        {
            Token_Type tmpType;

            Console.WriteLine("enter expression");

            term();
            while (token.type == Token_Type.PLUS || token.type ==Token_Type.MINUS) 
            {
                Console.WriteLine("当前运算符=" + token.lexeme);
                tmpType = token.type;
                matchToken(tmpType);

                term(); 
            }

            Console.WriteLine("leave expression");
        }

        //********** term
        static void term()
        {
            Token_Type tmpType;

            Console.WriteLine("enter term");

            factor();
            while (token.type == Token_Type.MUL || token.type == Token_Type.DIV)
            {
                Console.WriteLine("当前运算符=" + token.lexeme);
                tmpType = token.type;
                matchToken(tmpType);

                factor(); 
            }

            Console.WriteLine("leave term");
        }

        //********** factor
        static void factor()
        {
            Console.WriteLine("enter factor");

            if (token.type == Token_Type.PLUS)
            {
                Console.WriteLine("当前运算符=" + token.lexeme);
                matchToken(Token_Type.PLUS);

                factor();            
            }
            else if (token.type == Token_Type.MINUS)
            {
                Console.WriteLine("当前运算符=" + token.lexeme);
                matchToken(Token_Type.MINUS);

                factor();

            }
            else
                component();

            Console.WriteLine("leave factor");
        }

        //********** component
        static void component()
        {
            Console.WriteLine("enter component");

            atom();

            if (token.type == Token_Type.POWER)
            {
                Console.WriteLine("当前运算符=" + token.lexeme);
                matchToken(Token_Type.POWER);

                component();
            }

            Console.WriteLine("leave component");
        }

        //********** atom
        static void atom()
        {
            Console.WriteLine("enter atom");

            switch (token.type)
            {
                case Token_Type.CONST_ID:
                    Console.WriteLine("当前常数值=" + token.value);
                    matchToken(Token_Type.CONST_ID);
                    break;

                case Token_Type.T:
                    Console.WriteLine("当前记号=" + token.lexeme);
                    matchToken(Token_Type.T);
                    break;

                case Token_Type.FUNC:
                    Console.WriteLine("当前函数名=" + token.lexeme);
                    matchToken(Token_Type.FUNC);
                    matchToken(Token_Type.L_BRACKET);
                    expression();
                    matchToken(Token_Type.R_BRACKET);                    
                    break;

                case Token_Type.L_BRACKET:
                    Console.WriteLine("当前记号=" + token.lexeme);
                    matchToken(Token_Type.L_BRACKET);
                    expression();
                    matchToken(Token_Type.R_BRACKET);                    
                    break;

                default:
                    syntaxError(2,token);
                    break;
            }

            Console.WriteLine("leave atom");
        }

        #endregion

        #region 辅助函数

        /// 获取token
        static void fetchToken()
        {
            token = Scanner.GetToken(sr);
            if (Token_Type.ERRTOKEN == token.type)
            {
                syntaxError(1,token);
            }
        }
        /// 匹配token
        static void matchToken(Token_Type type)
        {
            if (token.type != type)
            {
                syntaxError(2,token);
            }
            else
                Console.WriteLine(" 当前记号: " + token.lexeme);
            fetchToken();
        }

        //*********错误记录及处理
        static void syntaxError(int caseof,Token token)
        {
            switch (caseof)
            {
                case 1:
                    Console.WriteLine(" 错误记号: " + token.lexeme);
                    //errLog += "行号:" + scanner.LineNum + " 错误记号:_" + token.lexeme + "_\n";
                    break;
                case 2:
                    Console.WriteLine(" 不是预期记号: " + token.lexeme);
                    //errLog += "行号:" + scanner.LineNum + " 不是预期记号:_" + token.lexeme + "_\n";
                    break;
                case 3:
                    Console.WriteLine(" 记号序列未正常结束，当前记号=" + token.lexeme);
                    //errLog += "行号:" + scanner.LineNum + " 不是预期记号:_" + token.lexeme + "_\n";
                    break;
            }
        }

        #endregion

        #endregion

        #endregion

    }//end class : Program

}//end namesapce : parser_my
