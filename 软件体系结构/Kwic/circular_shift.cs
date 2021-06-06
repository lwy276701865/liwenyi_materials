using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Kwic
{
    class Circular_shift : Filter
    {
        public Circular_shift(Pipe input, Pipe output) : base(input, output) //初始化 基类 管道
        {


        }
        public override void transform()
        {
            //循环从input管道中 读取 字符串，
            // 对每个字符串 处理：
            // （1）对每个字符串 分离单词 
            // （2)对分离的单词重新组合
            //直到字符串循环移位完成
            String str1;
            ArrayList al = new ArrayList(); //将每行分离的单词 放入al中
            StringBuilder sb = new StringBuilder();//重新构造字符串 单词间只包含一个空格
            String[] words; //分离单词 可用str1.split(‘ ‘)实现 并存放于words中
            while ((str1 = inpipe.Read()) != null) //对从输入管道中 读取每行进行处理，将移位后的//字符串 写入outpipe 管道中 
            {
                words = str1.Split(' ');
                al.Clear();
                foreach (string s in words)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        al.Add(s);
                    }
                }
                for (int i = 0; i < al.Count; i++)
                {
                    for (int j=i; j < al.Count; j++)
                    {
                        sb.Append(al[j] + " "); 
                    }
                    if(i!=0)
                    {
                        for (int k = 0; k < i; k++)
                            sb.Append(al[k] + " ");
                    }
                    outpipe.Write(sb.ToString());
                    sb.Clear();
                }
            }
        }
    }
}
