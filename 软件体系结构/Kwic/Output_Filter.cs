using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Kwic
{
    class Output_Filter : Filter
    {
        StreamWriter Sw; //文本文件写流
        public Output_Filter(Pipe input, FileStream fs)
            : base(input, null)
        {
            //用fs初始化 Sw文本文件写流
             Sw = new StreamWriter(fs);
        }
        public override void transform()
        {
            String str;
            //从inpipe输入管道中 读出一个字符串，写入到 Sw流中，直到读取完毕
            //以下为 自己编写代码实现 以上思想
            while ((str =inpipe.Read())!= null)
            {
                Sw.WriteLine(str);
            }
            Sw.Close();
        }

    }
}
