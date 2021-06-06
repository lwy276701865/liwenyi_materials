using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwic
{
    public class Pipe
    {
        Queue<String> q1; //用Queue 来表示管道内的数据结构 ，存放字符串
        public
        Pipe()
        {
            //自己填写代码 实现 对 q1 初始化 即 分配空间，需要了解 Queue泛型类对象的创//建，可通过网络查询  
            q1 = new Queue<string>();

        }
        public void Write(String str1) //将str1写入 管道中
        {
            //自己编写代码，将 str1 加入q1队列中，进行入队操作 
            q1.Enqueue(str1);
        }
        public String Read() //从管道中读取 一个字符串
        {
            String st = null;
            //自己编写代码实现 当q1队列中元素个数>0时，调用q1的出队方法 将字符串存入st中
           if(Empty()==false)
            {
                st = q1.Dequeue();
            }

            return st;
        }
        public Boolean Empty() //判断管道是否为空，如果为空返回 true，否则 返回false
        {
            Boolean b = true;
            //自己编写代码 判断 q1队列是否为空
            if (q1.Count()> 0)
                b = false;
            return b;
        }
    }
}

