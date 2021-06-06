using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_4
{
    class A
    {
        public virtual void Output()   //使用关键字virtual,说明这是一个虚拟函数
        {
            Console.WriteLine("输出A");
        }
    }
    class B : A   //B继承A
    {
        public override void Output()   //使用关键字override ,说明明重新实现了虚函数
        {
            Console.WriteLine("输出B");
        }
    }
    class C : B   //C继承B
    {
    }
    class D : A   //D继承A
    {
        public new void Output()   //使用关键字new ,隐藏类A的虚方法
        {
            Console.WriteLine("输出D");
        }
    }
    class program
    {
        static void Main()
        {
            A a = new A();   //实例化类A对象a
            A b = new B();   //定义类A的对象b，这个A就是b的申明类，B是b的实例类
            A c = new C();   //定义类A的对象c，这个A就是c的申明类，C是c的实例类
            A d = new D();   //定义类A的对象d，这个A就是d的申明类，D是d的实例类
            a.Output();   //执行a.Output：1.先检查申明类A 2.检查到是虚拟方法 3.转去检查实例类A，就为本身 4.执行实例类A中的方法 5.输出结果 “输出A”
            b.Output();   //执行b.Output：1.先检查申明类A 2.检查到是虚拟方法 3.转去检查实例类B，有重载的 4.执行实例类B中的方法 5.输出结果 “输出B”
            c.Output();   //执行c.Output：1.先检查申明类A 2.检查到是虚拟方法 3.转去检查实例类C，无重载的 4.转去检查类C的父类B，有重载的 5.执行父类B中的Output方法 5.输出结果 “输出B”
            d.Output();   //执行d.Output：1.先检查申明类A 2.检查到是虚拟方法 3.转去检查实例类D，无重载的（这个地方要注意了，虽然D里有实现Output()，但没有使用override关键字，所以不会被认为是重载） 4.转去检查类D的父类A，就为本身 5.执行父类A中的Output方法 5.输出结果 “输出A”
            D d2 = new D();
            d2.Output();   //执行D类里的Output()，输出结果 “输出D”
            Console.ReadLine();
        }
    }

}
