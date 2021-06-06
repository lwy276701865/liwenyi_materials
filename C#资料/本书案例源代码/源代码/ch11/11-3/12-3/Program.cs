using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义数组man
            var man = new[]
            {
                new{name="张三",age="15",sex="男"},
                new{name="李四",age="17",sex="男"},
                new{name="王五",age="19",sex="女"},
                new{name="张丹",age="18",sex="女"},
            };
            //创建查询query
            var query = from s in man
                        group s by s.sex;   //使用性别进行分组
            //执行查询并输出
            foreach(var grp in query)
            {
                //输出分组依据
                Console.WriteLine(grp.Key);
                //输出每组成员
                foreach (var m in grp)
                {
                    Console.WriteLine(m);
                }
            }            
            Console.ReadLine();
        }
    }
}

