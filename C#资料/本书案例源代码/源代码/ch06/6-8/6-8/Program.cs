using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_8
{
    //定义泛型接口, 约束参数只能存取class类或派生类
    public interface Ianimal<T, U> where T : class
    {
        void a1(T t);

        void a2(U u);
    }
    //定义实体类
    public class Dog1
    {
        public string Content { get; set; }
    }
    //定义实体类
    public class Cat1
    {
        public string Content { get; set; }
    }
    //定义实体类
    public class Dog2
    {
        public string Content { get; set; }
    }
    //定义实体类
    public class Cat2
    {
        public string Content { get; set; }
    }
    //实现泛型接口中的方法1
    public class Say1 : Ianimal<Dog1, Cat1>   //继承并实现接口
    {
        public void a1(Dog1 D)
        {
            Console.WriteLine(D.Content);
        }

        public void a2(Cat1 C)
        {
            Console.WriteLine(C.Content);
        }
    }
    //实现泛型接口中的方法2
    public class Say2 : Ianimal<Dog2, Cat2>   //继承并实现接口
    {
        public void a1(Dog2 D)
        {
            Console.WriteLine(D.Content);
        }

        public void a2(Cat2 C)
        {
            Console.WriteLine(C.Content);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog1 D1 = new Dog1();
            D1.Content = "Know-Wow";
            Cat1 C1 = new Cat1();
            C1.Content = "Meow";
            Dog2 D2 = new Dog2();
            D2.Content = "汪汪";
            Cat2 C2 = new Cat2();
            C2.Content = "喵喵";
            //通过传不同的类型实现调用不同的方法,分别调用相同接口不同类型的实现方法
            Ianimal<Dog1, Cat1> Is = new Say1();
            Is.a2(C1);
            Is.a1(D1);
            Ianimal<Dog2, Cat2> Is2 = new Say2();
            Is2.a2(C2);
            Is2.a1(D2);
            Console.ReadLine();
        }
    }
}
